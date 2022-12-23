using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class LayoutElementAdjuster : MonoBehaviour
{

    public Canvas _canvas;
    public float heightOffset = 50;
    
    [SerializeField, HideInInspector]
    LayoutElement _layout;
    Vector2 _cachedScreenSize;

    private void OnValidate() {
        _layout = GetComponent<LayoutElement>();
    }

	[System.Obsolete]
	void Update()
    {  
        // Get the screen size, and adjust it for the UI canvas scale and rect transform offset and size.
        Vector2 screenSize = new Vector2(_canvas.GetComponent<RectTransform>().rect.width, _canvas.GetComponent<RectTransform>().rect.height - heightOffset);

        // Avoid dirtying the layout if the screen size has not changed.
        if (_cachedScreenSize == screenSize)
            return;

        _layout.minHeight = screenSize.y;

        // Save our current screen size, so we can react only when it changes.
        _cachedScreenSize = screenSize;
    }
}