using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] GameObject gamePlayObject;
    [SerializeField] GameOverPanel gameOverPanel;

    private void OnEnable()
    {
        GameManager.Instance.OnsceneChange += HandleSceneChanged;    
    }

    private void OnDisable()
    {
        GameManager.Instance.OnsceneChange += HandleSceneChanged;
    }
    private void HandleSceneChanged(bool isActive)
    {
        if (!isActive == gamePlayObject.activeSelf) return;
        gamePlayObject.SetActive(!isActive);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

}
