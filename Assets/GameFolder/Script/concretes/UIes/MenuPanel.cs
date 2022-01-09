using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void StartButtonClick()
    {
        GameManager.Instance.LoadScene(1);
    }
    public void ExitButtonClick()
    {
        GameManager.Instance.ExitGame();
    }
}
