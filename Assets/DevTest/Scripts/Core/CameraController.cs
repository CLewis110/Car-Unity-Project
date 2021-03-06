using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    public GameObject rootObject;
    public Transform currentView;

    [SerializeField] float transitionSpeed = 0.05f;

    private Vector3 homeView;
    private PlaneDeactivator planeDeactivator;
    private string components = "SkyCarComponents";
    

    private void Awake()
    {
        homeView = this.gameObject.transform.position;
        planeDeactivator = GetComponent<PlaneDeactivator>();
    }
    void LateUpdate()
    {
        if(transform.position == homeView && currentView == null)
        {
            return;
        }
        //If there is a current view, but cam not at that position
        else if(currentView != null && transform.position != currentView.position)
        {
            if (currentView.parent.name == components)
            {
                planeDeactivator.DeactivatePlane();
            }
            ZoomIn();
        }
        //If there is no current view, return to home position
        else if(currentView == null && transform.position != homeView)
        {
            planeDeactivator.ActivatePlane();
            ZoomOut();
        }
    }

    public void SetCurrentView(Transform view)
    {
        currentView = view.Find("CameraPosition");
    }

    public void ClearCurrentView()
    {
        currentView = null;
    }

    private void ZoomOut()
    {
        transform.position = Vector3.Lerp(transform.position, homeView, transitionSpeed);
        transform.LookAt(rootObject.transform, Vector3.up);
    }

    private void ZoomIn()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, transitionSpeed);
        transform.LookAt(currentView.parent.transform, Vector3.up);
    }
}
