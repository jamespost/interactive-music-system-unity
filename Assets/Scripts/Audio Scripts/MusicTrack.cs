using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicTrack : MonoBehaviour
{
    [SerializeField] int parentCurrentMeasure;
    [SerializeField] AudioSource trackSource;
    [SerializeField] List<AudioClip> audioClips;


    //taken from https://forum.unity.com/threads/do-people-not-realize-how-bad-audiosource-dsptime-is-can-someone-explain-how-it-works.402308/
    private void OnEnable()
    {
        Metronome.OnBeat += Beat;
        Metronome.OnDownBeat += DownBeat;

        trackSource = GetComponent<AudioSource>();
        //parentCurrentMeasure = gameObject.GetComponentInParent<InteractiveMusicSystem>().currentMeasure;
    }

    private void OnDisable()
    {
        Metronome.OnBeat -= Beat;
        Metronome.OnDownBeat -= DownBeat;
    }

    void Beat()
    {
        //Do something here
    }

    void DownBeat()
    {
        //Do something else here
        parentCurrentMeasure = gameObject.GetComponentInParent<InteractiveMusicSystem>().currentMeasure;
        Debug.Log("music track is reading parent IMS current measure as: " + parentCurrentMeasure);
        
        //testing out ability to play child objects audio clips at a specific measure
        if(parentCurrentMeasure == 1)
        {
            trackSource.PlayOneShot(audioClips[0]);
        }
    }
}
