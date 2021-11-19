using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material selectMaterial;

    private Material highlightDefaultMaterial;
    private Material selectedDefaultMaterial;

    public void OnSelect(Transform selection)
    {
        var selectRenderer = selection.GetComponent<Renderer>();

        selectedDefaultMaterial = (highlightDefaultMaterial == null) ? selectRenderer.material : highlightDefaultMaterial;
        selectRenderer.material = selectMaterial;

        highlightDefaultMaterial = null;
    }

    public void OnDeselect(Transform selection)
    {
        var renderer = selection.GetComponent<Renderer>();
        renderer.material = selectedDefaultMaterial;

        selectedDefaultMaterial = null;
    }

    public void OnHighlight(Transform selection)
    {
        var highlightRenderer = selection.GetComponent<Renderer>();

        if (highlightRenderer != null)
        {
            highlightDefaultMaterial = highlightRenderer.material;
            highlightRenderer.material = highlightMaterial;
        }
    }

    public void OnDehighlight(Transform selection)
    {
        var renderer = selection.GetComponent<Renderer>();
        renderer.material = highlightDefaultMaterial;

        highlightDefaultMaterial = null;
    }
}
