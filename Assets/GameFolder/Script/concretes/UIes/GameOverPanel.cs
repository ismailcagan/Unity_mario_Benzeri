using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void YesButonClick()
    {
        GameManager.Instance.LoadScene();
        this.gameObject.SetActive(false);
    }
    public void NoButtonClick()
    {
        GameManager.Instance.LoadMenuAndUi(2);
    }
}
