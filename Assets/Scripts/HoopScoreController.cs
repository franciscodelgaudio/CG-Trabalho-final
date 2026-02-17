using System.Collections.Generic;
using UnityEngine;

public class HoopScoreController : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private float maxTimeBetweenGates = 0.6f;
    [SerializeField] private int pointsPerBasket = 2;

    private readonly Dictionary<int, float> enteredTopAt = new();

    public void OnTopEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;
        enteredTopAt[other.GetInstanceID()] = Time.time;
    }

    public void OnBottomEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        int id = other.GetInstanceID();
        if (!enteredTopAt.TryGetValue(id, out float tTop)) return;

        // janela de tempo pra confirmar que foi de cima pra baixo
        if (Time.time - tTop > maxTimeBetweenGates)
        {
            enteredTopAt.Remove(id);
            return;
        }

        // extra: garante que está descendo
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null && rb.velocity.y > 0f) return;

        enteredTopAt.Remove(id);
        if (scoreManager != null) scoreManager.AddPoints(pointsPerBasket);
    }
}
