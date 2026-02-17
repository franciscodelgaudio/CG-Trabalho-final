using UnityEngine;

public class HoopGateTrigger : MonoBehaviour
{
    public enum GateType { Top, Bottom }

    [SerializeField] private HoopScoreController controller;
    [SerializeField] private GateType gateType;

    private void OnTriggerEnter(Collider other)
    {
        if (controller == null) return;

        if (gateType == GateType.Top) controller.OnTopEnter(other);
        else controller.OnBottomEnter(other);
    }
}
