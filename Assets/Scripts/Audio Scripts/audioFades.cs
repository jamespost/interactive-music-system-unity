using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioFades : MonoBehaviour
{
    ///a class to handle all audio amplitude fades
    ///

    public AudioMixer musicMixer;
    [SerializeField] string exposedParam;


    private void Start()
    {
        //debug testing
        FadeInMixerGroup(musicMixer);
    }

    //fade in an audio mixer group
    public void FadeInMixerGroup(AudioMixer audioMixer)
    {
        //set the audioMixer group volume to 0
        audioMixer.SetFloat(exposedParam, 0);
        //fade in the volume of the mixer group over the specified time
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, exposedParam, 2, 1));
    }
    

















































    ////the project audio sample rate
    //private int projectSampleRate;  //this should be handled in a parent class eventually
    ////the project audio thread time
    //private double dspTime; //this should be handled in a parent class eventually
    ////[SerializeField] float minAmplitude = 0;
    ////[SerializeField] float maxAmplitude = 1;
    ////values for ADSR points
    //[SerializeField] float attackTime;
    //[SerializeField] float decayTime;    
    //[SerializeField] float releaseTime;

    //private void Start()
    //{
    //    projectSampleRate = AudioSettings.outputSampleRate;
    //    dspTime = AudioSettings.dspTime;

    //    //Debug.Log(dspTime);
    //}


    ////a method to start an audio sources playback with a user defined fade in time
    //public static IEnumerator FadeIn(AudioSource audioSource, float fadeInTime)
    //{
    //    float startVolume = 0.002f;
    //    audioSource.volume = 0;
    //    audioSource.Play();

    //    while (audioSource.volume < 1)
    //    {
    //        audioSource.volume += startVolume * Time.deltaTime / fadeInTime;
    //        Debug.Log(audioSource.volume);
    //    }
    //    audioSource.volume = 1;
    //    yield return null;
    //}

    ////debug method to print sample rate
    //private void printSampleRate()
    //{
    //    Debug.Log(projectSampleRate);
    //}
}
