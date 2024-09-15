using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] 
    AudioSource musicSource;
    [SerializeField]
    AudioMixer audioMixer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
