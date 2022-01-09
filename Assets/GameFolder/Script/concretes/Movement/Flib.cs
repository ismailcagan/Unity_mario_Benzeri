using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flib : MonoBehaviour
{
    public void FlibChacter(float horizontal)
    {
        if (horizontal > 0)
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }
}
