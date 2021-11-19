using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameObjectFromName : MonoBehaviour
{
    private Transform selectedObject;

    private void Update()
    {
        if(EventSystem.current.currentSelectedGameObject != null)
        {
            FindUIObjectByName(EventSystem.current.currentSelectedGameObject.name);
        }
        else
        {
            selectedObject = null;
        }
    }

    public bool HasUIObject()
    {
        return selectedObject != null;
    }

    public Transform GetUIObject()
    {
        return selectedObject;
    }

    //Get button by name
    private void FindUIObjectByName(string name)
    {
        selectedObject = GameObject.Find("SkyCar/" + name).transform;
    }
}
