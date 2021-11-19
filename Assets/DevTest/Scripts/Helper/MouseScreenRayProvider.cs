using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour
{
    public Ray CreateRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}