using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FartSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] fartSounds;

    [SerializeField] AudioSource playFartSound;

    float waitForFart;

    bool isFarting;
    bool canFart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFarting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFarting == false)
        {
            canFart = true;
        }
        else
        {
            canFart = false;
        }

        if (canFart)
        {
            StartCoroutine(PlayFartSound());
        }
    }

    IEnumerator PlayFartSound()
    {
        var clip = fartSounds[Random.Range(0, fartSounds.Length)];
        playFartSound.clip = clip;
        playFartSound.Play();
        isFarting = true;
        yield return new WaitForSeconds(clip.length);
        isFarting = false;
    }
}
