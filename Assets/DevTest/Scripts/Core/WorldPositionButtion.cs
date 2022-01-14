using UnityEngine;
using UnityEngine.UI;

public class WorldPositionButtion : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;

        var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        var show = true;
        image.enabled = show;

    }
}
