using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material selectMaterial;

    public Material highlightDefaultMaterial;
    public Material selectedDefaultMaterial;

    public void OnDeselect(Transform selection)
    {
        //Change highlighted object's material back to default
        var renderer = selection.GetComponent<Renderer>();
        renderer.material = selectedDefaultMaterial;

        //Clear unused
        selectedDefaultMaterial = null;
    }

    public void OnDehighlight(Transform selection)
    {
        //Change highlighted object's material back to default
        var renderer = selection.GetComponent<Renderer>();
        renderer.material = highlightDefaultMaterial;

        //Clear unused
        highlightDefaultMaterial = null;
    }

    public void OnSelect(Transform selection)
    {
        var selectRenderer = selection.GetComponent<Renderer>();

        //selectedDefaultMaterial = selectRenderer.material;
        selectedDefaultMaterial = (highlightDefaultMaterial == null) ? selectRenderer.material : highlightDefaultMaterial;
        selectRenderer.material = selectMaterial;
        
        //This line is causing problems
        highlightDefaultMaterial = null;
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
}
