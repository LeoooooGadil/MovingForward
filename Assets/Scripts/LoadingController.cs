using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public GameObject loadingPanel;
    Image fadeImage;
    
    [InspectorButton("FadeIn")]
    public bool fadeIn = false;

    [InspectorButton("FadeOut")]
    public bool fadeOut = false;

    void Start()
    {
        fadeImage = loadingPanel.GetComponent<Image>();
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
    }

	public async Task Wait(float seconds)
	{
		await Task.Delay((int)(seconds * 1000));
	}

	public async Task FadeIn()
	{
		fadeImage.raycastTarget = true;
		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
		fadeImage.canvasRenderer.SetAlpha(0.0f);
		fadeImage.CrossFadeAlpha(1.0f, 0.3f, false);
		await Task.Delay(300);
	}

	public async Task FadeOut()
	{
		fadeImage.canvasRenderer.SetAlpha(1.0f);
		fadeImage.CrossFadeAlpha(0.0f, 0.5f, false);
		await Task.Delay(300);
		fadeImage.raycastTarget = false;
	}
}
