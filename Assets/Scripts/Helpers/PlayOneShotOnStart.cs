using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShotOnStart : MonoBehaviour
{
    public AudioClip ClickSound;

    void Start()
    {
        PlayOneShot(ClickSound);
    }

    public void PlayOneShot(AudioClip clip)
    {
        if(clip != null)
        {
            SoundManager.instance.PlaySFXOneShot(clip);
        }
    }
}
