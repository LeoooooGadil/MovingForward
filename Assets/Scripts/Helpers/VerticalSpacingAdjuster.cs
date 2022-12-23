using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalSpacingAdjuster : MonoBehaviour
{
    public VerticalLayoutGroup _layoutGroup;

    public Canvas _canvas;

    public float heightOffset = 50;
    public float spacing = 10;
    public float spacingMultiplier = 1;

    [SerializeField, HideInInspector]

    Vector2 _cachedScreenSize;

    private void OnValidate()
    {
        _layoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    void Update()
    {
        // Get the screen size, and adjust it for the UI canvas scale and rect transform offset and size.
        Vector2 screenSize = new Vector2(_canvas.GetComponent<RectTransform>().rect.width, _canvas.GetComponent<RectTransform>().rect.height - heightOffset);

        // Avoid dirtying the layout if the screen size has not changed.
        if (_cachedScreenSize == screenSize)
            return;

        _layoutGroup.spacing = spacing * spacingMultiplier * (screenSize.y / 1080);

        // Save our current screen size, so we can react only when it changes.
        _cachedScreenSize = screenSize;
    }
}
