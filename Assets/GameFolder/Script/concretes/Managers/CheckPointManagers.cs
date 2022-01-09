using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointManagers : MonoBehaviour
{
    CheckPointController[] _checkPointControllers;
    Health _health;
    private void Awake()
    {
       _checkPointControllers = GetComponentsInChildren<CheckPointController>();
        // Player bul ardından ondan healt componentini al
        _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
    }

    private void Start()
    {
        _health.OnHealtChanged += _handleHealtChanged;
    }

    private void _handleHealtChanged(int currentHealth)
    {
       _health.transform.position = _checkPointControllers.LastOrDefault(x => x.IsPassed == true).transform.position;
    }
}
