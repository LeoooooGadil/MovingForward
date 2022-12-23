using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekdayComponent : MonoBehaviour
{

    public GameObject[] weekdaysButton = new GameObject[7];
    public bool[] activatedWeekdays = new bool[7];

    string[] weekdays = new string[7];

    public Sprite buttonDisabledSprite;
    public Sprite buttonEnabledSprite;

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
            Image _button = weekdaysButton[i].GetComponent<Image>();
            Button _buttonComponent = weekdaysButton[i].GetComponent<Button>();
            TextMeshProUGUI _text = weekdaysButton[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (activatedWeekdays[i])
            {
                //enable button
                _button.sprite = buttonEnabledSprite;
                _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1f);
                //change selected sprite
                _buttonComponent.spriteState = new SpriteState
                {
                    highlightedSprite = buttonEnabledSprite,
                    pressedSprite = buttonEnabledSprite,
                    selectedSprite = buttonEnabledSprite
                };
            }
            else
            {
                //disable button
                _button.sprite = buttonDisabledSprite;
                _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0.5f);
                //change selected sprite
                _buttonComponent.spriteState = new SpriteState
                {
                    highlightedSprite = buttonDisabledSprite,
                    pressedSprite = buttonDisabledSprite,
                    selectedSprite = buttonDisabledSprite
                };
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
