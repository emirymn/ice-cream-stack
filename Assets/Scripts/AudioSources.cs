using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSources : MonoBehaviour
{
    public static AudioSources instance;
    public AudioSource audioS;
    public AudioClip loss, win, collect, upgrade, sell;
    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
    }
}
