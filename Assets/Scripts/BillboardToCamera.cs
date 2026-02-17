using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    [SerializeField] private Transform cam;

    void LateUpdate()
    {
        if (cam == null && Camera.main != null) cam = Camera.main.transform;
        if (cam == null) return;

        transform.LookAt(transform.position + cam.forward, cam.up);
    }
}
