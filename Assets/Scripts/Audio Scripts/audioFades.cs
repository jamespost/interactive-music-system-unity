using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class audioFades : MonoBehaviour
{
    ///a class to handle all audio amplitude fades
    ///


    //the project audio sample rate
    private int projectSampleRate;  //this should be handled in a parent class eventually
    //the project audio thread time
    private double dspTime; //this should be handled in a parent class eventually
    //[SerializeField] float minAmplitude = 0;
    //[SerializeField] float maxAmplitude = 1;
    //values for ADSR points
    [SerializeField] float attackTime;
    [SerializeField] float decayTime;
    
    [SerializeField] float releaseTime;

    private void Start()
    {
        projectSampleRate = AudioSettings.outputSampleRate;
        dspTime = AudioSettings.dspTime;

        Debug.Log(dspTime);
    }


    //a method to start an audio sources playback with a user defined fade in time
    public void FadeIn(AudioSource audioSource, float fadeInTime)
    {
        float startVolume = 0.002f;
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeInTime;
            Debug.Log(audioSource.volume);
        }
        audioSource.volume = 1;
        
    }

    //debug method to print sample rate
    private void printSampleRate()
    {
        Debug.Log(projectSampleRate);
    }
}
