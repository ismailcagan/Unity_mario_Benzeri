using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisPlayHealth : MonoBehaviour
{
    TextMeshProUGUI _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    public void WriteHealt(int currentHealth)
    {
        _healthText.text = currentHealth.ToString();
    }
}
