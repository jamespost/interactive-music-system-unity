using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrack : MonoBehaviour
{


    //taken from https://forum.unity.com/threads/do-people-not-realize-how-bad-audiosource-dsptime-is-can-someone-explain-how-it-works.402308/
    private void OnEnable()
    {
        Metronome.OnBeat += Beat;
        Metronome.OnDownBeat += DownBeat;
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
    }
}
