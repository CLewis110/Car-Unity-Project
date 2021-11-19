using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    [SerializeField] public Transform _highlightedObject;
    [SerializeField] public Transform _selectedObject;

    private ISelectionResponse _selectionResponse;
    private GameObjectFromName _UIGameObject;
    public CameraController _camController;
    public Labeler _labeler;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        _UIGameObject = GetComponent<GameObjectFromName>();
        _labeler = GetComponent<Labeler>();
    }
    private void Update()
    {
        if(_highlightedObject != null)
        {
            ClearHighlight();
        }

        if (_UIGameObject.HasUIObject())
        {
            SelectObject();
            _camController.SetCurrentView(_selectedObject);
            _labeler.SetText(_selectedObject.name);
        }
//TODO: This is not my job
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var selection = hit.transform;

            //If object is not the current selected object and layer is selectable layer 
            if (LayerCheck(selection))
            {
                //highlight hovered object
                _selectionResponse.OnHighlight(selection);
                _highlightedObject = selection;

                if (Input.GetMouseButtonDown(0))
                {
                    if (_selectedObject != null)
                    {
                        ClearSelection();
                    }
//TODO: This could be a function
                    //Add new selected object
                    _selectedObject = selection;
                    _highlightedObject = null;
                    _selectionResponse.OnSelect(_selectedObject);
                    _camController.SetCurrentView(_selectedObject);
                    _labeler.SetText(_selectedObject.name);
                }
            }
            else
            {
                //Duplication
                if (Input.GetMouseButtonDown(0))
                {
                    if (_selectedObject != null)
                    {
                        ClearSelection();
                        _camController.ClearCurrentView();
                        _labeler.ClearText();
                    }
                }
            }
        }
        else
        {
            //Duplication
            if (Input.GetMouseButtonDown(0))
            {
                if (_selectedObject != null)
                {
                    ClearSelection();
                    _camController.ClearCurrentView();
                    _labeler.ClearText();
                }
            }
        }
    }

    //This is not my job
    private bool LayerCheck(Transform selection)
    {
        return (selection.gameObject.transform != _selectedObject && (layer & (1 << selection.gameObject.layer)) > 0);
    }

    private void ClearHighlight()
    {
        _selectionResponse.OnDehighlight(_highlightedObject);
        _highlightedObject = null;
    }

    private void ClearSelection()
    {
        _selectionResponse.OnDeselect(_selectedObject);
        _selectedObject = null;
    }

//TODO: Fix this to be more versatile
    private void SelectObject()
    {
        //Clear any selected objects
        if (_selectedObject != null)
        {
            ClearSelection();
        }
        //Add new UI selected object
        _selectedObject = _UIGameObject.GetUIObject();
        _selectionResponse.OnSelect(_selectedObject);
    }
}

