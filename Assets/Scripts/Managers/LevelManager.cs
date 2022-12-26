using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Image fadeImage;
    public AudioClip transitionSound;

    public string lastSceneName = "MainMenu";
    
    public bool isFancyLoading = false;

    public string[] notToGoBackTo = new string[] { "Settings", "Credits" };

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Set the fade image to be transparent
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
    }

    public async Task LoadScene(string sceneName)
    {
        lastSceneName = (System.Array.IndexOf(notToGoBackTo, sceneName) == -1) ? sceneName : lastSceneName;

        fadeImage.raycastTarget = true;

        var scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        scene.allowSceneActivation = false;
 
        await Wait(0.1f);

        PlaySound();
        await FadeIn();

        // Wait for the scene to load
        while(!scene.isDone)
        {
            if(scene.progress >= 0.9f)
			{
				scene.allowSceneActivation = true;
                fadeImage.raycastTarget = false;
				await FancyLoading();
				await FadeOut();
			}

			await Task.Yield();
        }


    }

    public async Task LoadLastScene()
    {
        await LoadScene(lastSceneName);
    }

    private async Task Wait(float seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }

	private async Task FancyLoading()
	{
		if (isFancyLoading)
		{
			await Task.Delay(500);
		}
	}

    private void PlaySound()
	{
		if (transitionSound != null)
		{
			SoundManager.instance.PlaySFXOneShot(transitionSound);
		}
	}

	public async Task FadeIn()
    {
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
    }
}
