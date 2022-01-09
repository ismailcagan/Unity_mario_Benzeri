using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCanvas : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LoadMenuAndUi(5);
    }
}
