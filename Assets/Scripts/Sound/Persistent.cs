using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    public AudioSource openingBell;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        openingBell = GetComponent<AudioSource>();
    }

    public void Play()
    {
        openingBell.Play();
    }
}
