using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDeactivator : MonoBehaviour
{
    public GameObject plane;

    public void ActivatePlane()
    {
        plane.SetActive(true);
    }

    public void DeactivatePlane()
    {
        plane.SetActive(false);
    }
}
