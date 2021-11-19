using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChecker : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    public bool CheckLayer(Transform selection)
    {
        return  (layer & (1 << selection.gameObject.layer)) > 0;
    }
}
