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
        
        // Calcul des anchors en pourcentage de l'écran
        minAnchor = safeArea.position;
        maxAnchor = minAnchor + safeArea.size;

        // Conversion en valeurs normalisées (0-1)
        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        // Application des anchors
        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }

    private void Update()
    {
        // Vérifie si la safe area a changé (rotation de l'écran par exemple)
        if (safeArea != Screen.safeArea)
        {
            ApplySafeArea();
        }
    }
} 
