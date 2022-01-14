using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelActivator : MonoBehaviour
{
    private Transform partLabels;

    public void ActivateLabels(Transform part)
    {
        GetLabels(part);
        partLabels.gameObject.SetActive(true);
    }

    public void DeactivateLabels(Transform part)
    {
        partLabels.gameObject.SetActive(false);
        partLabels = null;
    }

    public void GetLabels(Transform part)
    {
        partLabels = part.Find("Sub Part Labels");
    }

}
