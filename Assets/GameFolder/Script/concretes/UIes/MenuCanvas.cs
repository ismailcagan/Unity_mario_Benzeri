using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] MenuPanel menuPanel;

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
        if (isActive == menuPanel.gameObject.activeSelf) return;
        menuPanel.gameObject.SetActive(isActive);
    }
}
