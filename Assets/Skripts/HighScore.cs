using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int Score = 1000;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Score = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", Score);
    }

    private void Update()
    {
        TextMeshProUGUI gt = GetComponent<TextMeshProUGUI>();
        gt.text = "High Score: " + Score;

        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
