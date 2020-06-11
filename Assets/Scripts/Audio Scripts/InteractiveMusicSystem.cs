using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InteractiveMusicSystem : MonoBehaviour
{
    [SerializeField] public int currentBeat;
    [SerializeField] public int currentMeasure;

    [SerializeField] List<AudioSource> audioSources;

    //adapted from https://forum.unity.com/threads/do-people-not-realize-how-bad-audiosource-dsptime-is-can-someone-explain-how-it-works.402308/

    private void OnEnable()
    {
        Metronome.OnBeat += Beat;
        Metronome.OnDownBeat += DownBeat;

        currentBeat = 1;
        //there seems to be a "buffer" time of the first beat for the timing to be accurate- resulting in the first OnDownBeat() method being called twice within a frame update- so a "count in" measure is needed before the system starts measure 1 to correct this error. this is acheived by initializing currentMeasure to -1 OnEnable()
        currentMeasure = -1;


    }

    private void OnDisable()
    {
        Metronome.OnBeat -= Beat;
        Metronome.OnDownBeat -= DownBeat;
    }

    void Beat()
    {
        //Do something here
        currentBeat++;
        if(currentBeat != 1)
        {
            //Debug.Log("current beat: " + currentBeat);
        }
        
    }

    void DownBeat()
    {
        //reset currentBeat to 1
        currentBeat = 1;
        
        //increment currentMeasure
        currentMeasure++;
        //Debug.Log("current beat: " + currentBeat);
        //Debug.Log("current measure: " + currentMeasure);

        //testing out playing random audiosources at specified rhythmic intervals
        if(currentMeasure >= 1 && currentMeasure % 8 == 0)
        {

            List<int> randomAudioSourcesToPlay;
            randomAudioSourcesToPlay = new List<int>();

            for (int i = 0; i < audioSources.Count/ 2; i++)
            {
                int randomResult = new int();
                randomResult = (int)UnityEngine.Random.Range(0, audioSources.Count);

                randomAudioSourcesToPlay.Add(randomResult);
                //if (!audioSources[randomResult].isPlaying)
                //{
                //    audioSources[randomResult].Play();
                //}

                audioSources[randomResult].Play();
                Debug.Log("random source selected: " + randomResult);
            }

            //int randomAudioSourceElement = (int)UnityEngine.Random.Range(0, audioSources.Count);
            //audioSources[randomAudioSourceElement].Play();
        }


        ////testing accurate playback of audiosources
        ////at the start of the "song"
        //if(currentMeasure == 1)
        //{
        //    //play the first audio source
        //    //audioSources[0].Play();
        //}
        ////at bar 5 of the "song"
        //if(currentMeasure == 5)
        //{
        //    //play the second audio source
        //    //audioSources[1].Play();
        //}
    }













































    ////a method to update currentBeatCount and currentBarCount off of dspTime (most accurate method)
    //IEnumerator updateBeatCountDSPTime()
    //{



    //    samplesPerTick = sampleRate * 60.0F / bpm * timeSigNumerator / timeSigDenominator;
    //    double sample = AudioSettings.dspTime * sampleRate;
    //    int n = 0;
    //    while(n < 32)
    //    {
    //        while (sample + n >= nextTick)
    //        {
    //            nextTick += samplesPerTick;

    //            if (currentBeatCount < 4)
    //            {
    //                currentBeatCount++;
    //            }
    //            else
    //            {
    //                currentBeatCount = 1;
    //            }


    //            if ((currentBeatCount - 1) % timeSigNumerator == 0)
    //            {
    //                currentBarCount++;
    //                Debug.Log("bar = " + currentBarCount);
    //            }
    //        }
    //        n++;
    //        yield return null;
    //    }



    //}


    ////a method to update currentBeatCount based off of scaled time in seconds(very innacurate and causes wobbly timings)
    //IEnumerator updateBeatCountScaledTime()
    //{
    //    currentBeatCount = 0;
    //    currentBarCount = 0;

    //    for (; ; )
    //    {
    //        //get the current dsptime
    //        startTick = AudioSettings.dspTime;
    //        ////testing
    //        //Debug.Log("beat = " + currentBeatCount);
    //        ////Debug.Log("bar = " + currentBarCount);
    //        if (playClickTrack)
    //        {
    //            audioSources[0].Play();
    //            //audioSources[1].Play();
    //        }

    //        if(currentBeatCount < 4)
    //        {
    //            currentBeatCount++;
    //        }
    //        else
    //        {
    //            currentBeatCount = 1;
    //        }


    //        if ((currentBeatCount - 1) % timeSigNumerator == 0)
    //        {
    //            currentBarCount++;
    //            Debug.Log("bar = " + currentBarCount);
    //        }

    //        //test out playing a source at a certain bars downbeat
    //        if (currentBarCount == 5 && currentBeatCount == 1)
    //        {
    //            //audioSources[1].PlayScheduled();
    //        }
    //        if (currentBarCount == 9 && currentBeatCount == 1)
    //        {
    //            audioSources[2].Play();
    //        }

    //        yield return new WaitForSeconds((float)beatInSeconds);
    //    }

    //}

    ////debugging methods
    ////a method to print dspTime
    //public void PrintDSPTime()
    //{
    //    Debug.Log(AudioSettings.dspTime);
    //}
}
