using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // SelectExitEventArgs etc :contentReference[oaicite:1]{index=1}
using UnityEngine.XR.Interaction.Toolkit.Interactables; // XRGrabInteractable :contentReference[oaicite:2]{index=2}

[RequireComponent(typeof(XRGrabInteractable))]
public class SnapToGroundOnRelease : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform feetAnchor;       // coloque o FeetAnchor aqui
    [SerializeField] private Rigidbody rb;               // opcional (pega automático se vazio)

    [Header("Ground")]
    [SerializeField] private LayerMask groundMask;       // layer do chão/quadra
    [SerializeField] private float castUp = 0.3f;        // começa um pouco acima do pé
    [SerializeField] private float castDown = 2.0f;      // distancia pra baixo
    [SerializeField] private float footOffset = 0.01f;   // evita ficar “z-fighting” no chão

    [Header("Upright")]
    [SerializeField] private bool keepUpright = true;    // mantém em pé
    [SerializeField] private bool keepYaw = true;        // mantém rotação Y

    private XRGrabInteractable grab;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        if (rb == null) rb = GetComponent<Rigidbody>();

        // evento disparado quando solta
        grab.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        if (grab != null)
            grab.selectExited.RemoveListener(OnReleased);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (feetAnchor == null) return;

        // opcional: endireitar (sem mexer no yaw)
        if (keepUpright)
        {
            float y = keepYaw ? transform.eulerAngles.y : 0f;
            transform.rotation = Quaternion.Euler(0f, y, 0f);
        }

        Vector3 origin = feetAnchor.position + Vector3.up * castUp;

        if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, castUp + castDown, groundMask, QueryTriggerInteraction.Ignore))
        {
            // queremos que o FeetAnchor fique no hit.point (com offset)
            Vector3 desiredFeetPos = hit.point + Vector3.up * footOffset;
            Vector3 delta = desiredFeetPos - feetAnchor.position;

            if (rb != null && rb.isKinematic)
                rb.position += delta;   // move via rb (bom pra kinematic)
            else
                transform.position += delta;
        }
    }
}
