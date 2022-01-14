using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{    
    public CameraController _camController;

    [SerializeField] public Transform _highlightedObject;
    [SerializeField] public Transform _selectedObject;    

    private ISelectionResponse _selectionResponse;
    private MouseScreenRayProvider _rayProvider;
    private UIToGameObject _UIGameObject;
    private LayerChecker _layerChecker;
    private LabelActivator _labelActivator;
    private Labeler _labeler;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        _rayProvider = GetComponent<MouseScreenRayProvider>();
        _UIGameObject = GetComponent<UIToGameObject>();
        _layerChecker = GetComponent<LayerChecker>();
        _labelActivator = GetComponent<LabelActivator>();
        _labeler = GetComponent<Labeler>();
    }
    private void Update()
    {
        if (_highlightedObject != null)
        {
            ClearHighlight();
        }

        if (_UIGameObject.HasUIObject())
        {
            SelectObject(_UIGameObject.GetUIObject());
        }
        Ray ray = _rayProvider.CreateRay();

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var selection = hit.transform;

            if (selection.gameObject.transform != _selectedObject && _layerChecker.CheckLayer(selection))
            {
                //highlight hovered object
                HighlightObject(selection);

                //Select mouse clicked object
                if (Input.GetMouseButtonDown(0))
                {
                    SelectObject(selection);
                    _highlightedObject = null;
                }
            }
            else
            {
                //Clicking on object in wrong layer
                if (Input.GetMouseButtonDown(0))
                {
                    if (_selectedObject != null)
                    {
                        ClearSelection();
                    }
                }
            }
        }
        else
        {
            //Clicking off in space
            if (Input.GetMouseButtonDown(0))
            {
                if (_selectedObject != null)
                {
                    ClearSelection();
                }
            }
        }
    }

    private void SelectObject(Transform selection)
    {
        if (_selectedObject != null)
        {
            ClearSelection();
        }

        _selectedObject = selection;
        _selectionResponse.OnSelect(_selectedObject);
        _camController.SetCurrentView(_selectedObject);
        _labelActivator.ActivateLabels(_selectedObject);
        _labeler.SetText(_selectedObject.name);
    }

    private void ClearSelection()
    {
        _selectionResponse.OnDeselect(_selectedObject);
        _labelActivator.DeactivateLabels(_selectedObject);
        _selectedObject = null;
        _camController.ClearCurrentView();
        _labeler.ClearText();
    }

    private void HighlightObject(Transform selection)
    {
        _selectionResponse.OnHighlight(selection);
        _highlightedObject = selection;
    }

    private void ClearHighlight()
    {
        _selectionResponse.OnDehighlight(_highlightedObject);
        _highlightedObject = null;
    }
}

