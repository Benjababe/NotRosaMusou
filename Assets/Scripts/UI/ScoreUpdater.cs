using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private Score _scoreCounter;

    void Start()
    {
        _scoreCounter = GameObject.Find("ScoreCounter").GetComponent<Score>();
    }

    void Update()
    {
        _text.SetText("<align=right>Score: " + _scoreCounter.GetScore().ToString());
    }

    private void OnDestroy()
    {
        AddScore(_scoreCounter.GetScore());
    }

    private void AddScore(int score)
    {
        if (PlayerPrefs.HasKey("HScore"))
        {
            if (score > PlayerPrefs.GetInt("HScore"))
            {
                PlayerPrefs.SetInt("HScore", score);
            }
        }

        else
        {
            PlayerPrefs.SetInt("HScore", score);
        }
    }
}
