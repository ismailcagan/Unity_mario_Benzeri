using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionExtensionMethods
{
    public static bool WasHitLeftOrRightSide(this Collision2D collision)
    {
        return collision.contacts[0].normal.x > 0.6f || collision.contacts[0].normal.x < 0.6f;
    } 
    public static bool WasHitBottomSide(this Collision2D collision)
    {
        return collision.contacts[0].normal.y < -0.6f;
    }
    public static bool WasHitTopSide(this Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.6f;
    }

    public static bool HasHitPlayer(this Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerController>() != null;
    }

    public static bool HasHitEnemy(this Collision2D collision)
    {
        return collision.collider.GetComponent<EnemyController>() != null;
    }
}
