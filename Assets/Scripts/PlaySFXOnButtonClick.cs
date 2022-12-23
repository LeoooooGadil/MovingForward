using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlaySFXOnButtonClick : MonoBehaviour
{
    public int sfxIndex = 0;

    Button button;

    void OnValidate()
    {
        if (sfxIndex < 0)
        {
            Debug.LogError("SFX index is less than 0");
            return;
        }
    }

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => PlaySFX());
    }

    void PlaySFX()
    {
        SoundManager.instance.PlaySFX(sfxIndex);
    }
}
