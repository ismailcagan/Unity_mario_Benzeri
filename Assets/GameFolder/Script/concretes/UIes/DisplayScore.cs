using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI _scoreText;
    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += HandleScoreChanged;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        GameManager.Instance.IncreaseScore();
    }
    private void HandleScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
