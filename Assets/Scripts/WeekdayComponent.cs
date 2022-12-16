using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekdayComponent : MonoBehaviour
{

    public GameObject[] weekdaysButton = new GameObject[7];
    public bool[] activatedWeekdays = new bool[7];

    string[] weekdays = new string[7];

    public Color32 deactivatedColor = new Color32(255, 255, 255, 255);
    public Color32 activatedColor = new Color32(100, 100, 100, 255);

    public GameObject weekdaysDisplayText;
    TextMeshProUGUI weekdaysDisplayTextComponent;

    public AudioClip buttonClickSound;

    void Start()
    {
        weekdays = new string[] {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};

        for (int i = 0; i < weekdaysButton.Length; i++)
        {
            Button _button = weekdaysButton[i].GetComponent<Button>();
            int _index = i;
            _button.onClick.AddListener(() => OnWeekdayButtonClicked(_index));

            activatedWeekdays[i] = false;
        }

        weekdaysDisplayTextComponent = weekdaysDisplayText.GetComponent<TextMeshProUGUI>();
        DisplayWeekdays();
    }

    void DisplayWeekdays()
    {
        for (int i = 0; i < weekdaysButton.Length; i++)
        {
            Image _image = weekdaysButton[i].GetComponent<Image>();
            TextMeshProUGUI _text = weekdaysButton[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (activatedWeekdays[i])
            {
                _image.color = activatedColor;
                _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0.5f);
                
            }
            else
            {
                _image.color = deactivatedColor;
                _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1f);
            }
        }

        weekdaysDisplayTextComponent.text = WeekdayConverter.ConvertWeekdayIntToString(activatedWeekdays);
    }

    void OnWeekdayButtonClicked(int index)
    {
        activatedWeekdays[index] = !activatedWeekdays[index];
        PlaySound(buttonClickSound);
        DisplayWeekdays();
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            SoundManager.instance.PlaySFXOneShot(clip);
        }
    }
}
