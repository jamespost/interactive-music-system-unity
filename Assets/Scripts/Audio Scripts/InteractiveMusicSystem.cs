using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InteractiveMusicSystem : MonoBehaviour
{
    ///a class to handle all interactive music in game
    ///

    //Rhymthmical data
    //bpm of current song
    [SerializeField] int bpm;
    //meter of current song
    [SerializeField] int beatsPerBar;
    [SerializeField] int lengthOfBar;
    [SerializeField] int currentBeatCount;
    [SerializeField] int currentBarCount;
    //Sample/clip Data
    //has a list of audio clips
    [SerializeField] List<AudioClip> musicClips;
    

    //a method to loop audio clips based off of audio clip bpm rather than audio clip length






    //a method to update currentBeatCount based off of DSPTime
    IEnumerator updateBeatCount()
    {
        //get the current dsptime
        double currentDSPTime = AudioSettings.dspTime;

        yield return null;
    }




    //debugging methods
    //a method to print dspTime
    public void PrintDSPTime()
    {
        Debug.Log(AudioSettings.dspTime);
    }
}
