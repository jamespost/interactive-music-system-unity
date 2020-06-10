using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InteractiveMusicSystem : MonoBehaviour
{
    ///a class to handle all interactive music in game
    ///

    //Rhymthmical data
    //bpm of current song (default is 120bpm)
    [SerializeField] private double bpm = 120;

    //meter of current song    
    [SerializeField] private int timeSigNumerator;
    [SerializeField] private int timeSigDenominator;

    [SerializeField] private int beatsPerBar;
    [SerializeField] private int lengthOfBar;

    [SerializeField] private int currentBeatCount;
    [SerializeField] private int currentBarCount;
    
    [SerializeField] private double beatInSeconds;
    [SerializeField] private double beatInSamples;

    [SerializeField] private double initialDSPTime;
    [SerializeField] private double currentDSPTime;

    [SerializeField] private bool playClickTrack;

    private double secondsInAMinute;
    private double sampleRate;

    //Sample/clip Data
    //has a list of audio clips
    [SerializeField] List<AudioClip> musicClips;
    [SerializeField] List<AudioSource> audioSources;

    private bool musicIsPlaying = false;

    private void Awake()
    {
        //initialize 
        initialDSPTime = AudioSettings.dspTime;

        sampleRate = AudioSettings.outputSampleRate;

        secondsInAMinute = 60;

        beatInSeconds = secondsInAMinute / bpm;
        beatInSamples = sampleRate / beatInSeconds;

        //currentBeatCount = 1;
        //currentBarCount = 1;
        
    }
    
    private void Start()
    {
        musicIsPlaying = true;
        //start updating currentBeatCount
        StartCoroutine(updateBeatCountScaledTime());
    }

    

    //a method to update currentBeatCount and currentBarCount off of dspTime (most accurate method)
    private void updateBeatCountDSPTime()
    {
        //get the current dsptime
        currentDSPTime = AudioSettings.dspTime;

        //initialize variables
        currentBeatCount = 0;
        currentBarCount = 1;

        double samplesPerTick = sampleRate * 60.0F / bpm * timeSigNumerator / timeSigDenominator;
        double sample = AudioSettings.dspTime * sampleRate;

    }


    //a method to update currentBeatCount based off of scaled time in seconds(very innacurate and causes wobbly timings)
    IEnumerator updateBeatCountScaledTime()
    {
        currentBeatCount = 0;
        currentBarCount = 1;

        for (; ; )
        {
            //get the current dsptime
            currentDSPTime = AudioSettings.dspTime;
            ////testing
            //Debug.Log("beat = " + currentBeatCount);
            ////Debug.Log("bar = " + currentBarCount);
            if (playClickTrack)
            {
                audioSources[0].Play();
                //audioSources[1].Play();
            }

            currentBeatCount++;

            if ((currentBeatCount - 1) % timeSigNumerator == 0)
            {
                currentBarCount++;
                Debug.Log("bar = " + currentBarCount);
            }

            yield return new WaitForSeconds((float)beatInSeconds);
        }

    }

    //debugging methods
    //a method to print dspTime
    public void PrintDSPTime()
    {
        Debug.Log(AudioSettings.dspTime);
    }
}
