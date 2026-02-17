using UnityEngine;

public class MovingBonusTarget : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 1.0f;

    [Header("Bonus Action")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int bonusMultiplier = 2;
    [SerializeField] private float bonusDuration = 5f;
    [SerializeField] private float hitCooldown = 0.5f;

    private float nextHitTime;

    private void Update()
    {
        if (pointA == null || pointB == null) return;

        float t = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time < nextHitTime) return;
        if (!other.CompareTag("Ball")) return;

        nextHitTime = Time.time + hitCooldown;

        // AÇÃO: ativa multiplicador por alguns segundos
        if (scoreManager != null)
            scoreManager.SetMultiplierTemporarily(bonusMultiplier, bonusDuration);

        // Opcional: desabilitar o alvo por um tempo (pra ficar claro que foi "ativado")
        gameObject.SetActive(false);
        Invoke(nameof(Reenable), 2f);
    }

    private void Reenable() => gameObject.SetActive(true);
}
