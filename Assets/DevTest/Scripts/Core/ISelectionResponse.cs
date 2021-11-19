using UnityEngine;

public interface ISelectionResponse
{
    void OnDeselect(Transform selection);
    void OnSelect(Transform selection);
    void OnDehighlight(Transform highlightedObject);
    void OnHighlight(Transform selection);
}