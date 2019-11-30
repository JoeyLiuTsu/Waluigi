using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip brick;
    public static bool brickCheck;
    public AudioClip coin;
    public static bool coinCheck;

    private void Update()
    {
        if (brickCheck)
        {
            GetComponent<AudioSource>().clip = brick;
            GetComponent<AudioSource>().Play();
            brickCheck = false;
        }

        if (coinCheck)
        {
            GetComponent<AudioSource>().clip = coin;
            GetComponent<AudioSource>().Play();
            coinCheck = false;
        }
    }
}
