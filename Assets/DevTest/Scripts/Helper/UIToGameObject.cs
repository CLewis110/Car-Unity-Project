using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIToGameObject : MonoBehaviour
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

    //Get GameObject by button name
    //TODO: Get Gameobject by child array number
    private void FindUIObjectByName(string name)
    {
        selectedObject = GameObject.Find("SkyCar/" + name).transform;

    }
}
