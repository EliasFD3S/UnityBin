//Adjust a canva to fit safe area (mobile devices)
using UnityEngine;

public class SafeAreaHandler : MonoBehaviour
{
    private RectTransform rectTransform;
    private Rect safeArea;
    private Vector2 minAnchor;
    private Vector2 maxAnchor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ApplySafeArea();
    }

    private void ApplySafeArea()
    {
        safeArea = Screen.safeArea;
        
        //anchors calculations based on screensize
        minAnchor = safeArea.position;
        maxAnchor = minAnchor + safeArea.size;

        //normalize the values (0-1)
        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        //apply the anchors
        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }

    private void Update()
    {
        // checks a safearea movement (phone rotation)
        if (safeArea != Screen.safeArea)
        {
            ApplySafeArea();
        }
    }
} 
