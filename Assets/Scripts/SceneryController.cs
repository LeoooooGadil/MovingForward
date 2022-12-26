using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneryController : MonoBehaviour
{
    public string[] sceneries;
    public GameObject sceneryContainer;
    public GameObject sceneryButtonPrefab;
    public MainWorldMenuSystem mainWorldMenuSystem;

    int currentSceneryIndex = 0;

    public Scene currentScenery;

    void Start()
    {
        UpdateScenery();
    }

    public async Task setScenery(int index)
    {
        currentSceneryIndex = index;
        Debug.Log("Scenery set to " + sceneries[currentSceneryIndex]);
        UpdateScenery();
        await Task.Delay(50);
        mainWorldMenuSystem.CloseMenu();
    }

    public void UpdateList()
    {
        foreach (Transform child in sceneryContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (string scenery in sceneries)
        {
            GameObject sceneryButton = Instantiate(sceneryButtonPrefab, sceneryContainer.transform);
            SceneryButton sceneryButtonScript = sceneryButton.GetComponent<SceneryButton>();
            sceneryButtonScript.sceneryController = this;
            sceneryButtonScript.sceneryNameString = TextTransformer.SplitCamelCase(scenery);
            sceneryButtonScript.sceneryIndex = System.Array.IndexOf(sceneries, scenery);

            if (scenery == currentScenery.name)
            {
                sceneryButtonScript.isCurrentScenery = true;
            }
        }
    }

    void UpdateScenery() {
        var scene = SceneManager.LoadSceneAsync(sceneries[currentSceneryIndex], LoadSceneMode.Additive);
        scene.completed += (AsyncOperation op) => {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneries[currentSceneryIndex]));

            if (currentScenery.name != null)
                SceneManager.UnloadSceneAsync(currentScenery);

            currentScenery = SceneManager.GetSceneByName(sceneries[currentSceneryIndex]);
        };
    }

    
}
