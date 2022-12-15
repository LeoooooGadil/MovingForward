using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class LayoutElementAdjuster : MonoBehaviour
{

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
        Vector2 screenSize = new Vector2(transform.root.transform.FindChild("Canvas").GetComponent<RectTransform>().rect.width, transform.root.transform.FindChild("Canvas").GetComponent<RectTransform>().rect.height - heightOffset);

        // Avoid dirtying the layout if the screen size has not changed.
        if (_cachedScreenSize == screenSize)
            return;

        _layout.minHeight = screenSize.y;

        // Save our current screen size, so we can react only when it changes.
        _cachedScreenSize = screenSize;
    }
}