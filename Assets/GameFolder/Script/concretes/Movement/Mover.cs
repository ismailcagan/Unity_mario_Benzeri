using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    public void MoverAction(float horizontal)
    {
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * Speed); // Hareket yürüme
    }
}
