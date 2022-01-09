using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterExitOnTrigger(collision, 0.0f, true);
        Debug.Log("temas sağlandı");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnterExitOnTrigger(collision, 1.0f, false);
    }
    public void EnterExitOnTrigger(Collider2D collision, float gravityForce, bool isClimbing)
    {
        Climbing playerClimbing = collision.GetComponent<Climbing>();
        if (playerClimbing != null)
        {
            playerClimbing.Rigidbody.gravityScale = gravityForce;
            playerClimbing.IsClimbing = isClimbing;// yer çekimi sıfır 0 oluyor
        }
    }
}
