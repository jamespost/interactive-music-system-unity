using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMusicSystem : MonoBehaviour
{
    ///a class to handle all interactive music in game
    ///

    //has access to the audioFades class
    private audioFades audioFades;
    //has an audio source for testing purposes
    [SerializeField] AudioSource testAudioSource;

    private void Start()
    {
        audioFades.FadeIn(testAudioSource, 10);
    }

}
