using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;

        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore");

        GameObject scoreGO = GameObject.Find("ScoreCounter");
        TextMeshProUGUI scoreCounterText = scoreGO.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Your score: " + scoreCounterText.text;
    }
}
