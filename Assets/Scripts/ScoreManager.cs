using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;
    private int multiplier = 1;
    private Coroutine multRoutine;

    private void Start() => Refresh();

    public void AddPoints(int basePoints)
    {
        score += basePoints * multiplier;
        Refresh();
    }

    public void SetMultiplierTemporarily(int newMultiplier, float duration)
    {
        if (multRoutine != null) StopCoroutine(multRoutine);
        multRoutine = StartCoroutine(MultCoroutine(newMultiplier, duration));
    }

    private IEnumerator MultCoroutine(int newMultiplier, float duration)
    {
        multiplier = Mathf.Max(1, newMultiplier);
        Refresh();

        yield return new WaitForSeconds(duration);

        multiplier = 1;
        Refresh();
        multRoutine = null;
    }

    private void Refresh()
    {
        if (scoreText != null)
            scoreText.text = $"Pontos: {score}  (x{multiplier})";
    }
}
