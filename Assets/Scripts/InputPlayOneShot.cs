using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownPlayOneShot : MonoBehaviour
{
    public AudioClip ClickSound;
    
    TMP_Dropdown dropdownField;

    void Start()
    {
        dropdownField = GetComponent<TMP_Dropdown>();
        
    }

    public void PlayOneShot(AudioClip clip)
    {
        if(clip != null)
        {
            SoundManager.instance.PlaySFXOneShot(clip);
        }
    }
    
}
