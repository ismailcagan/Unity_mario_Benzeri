using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    [SerializeField] bool isOnGround = false;
    [SerializeField] float maxDistance = 0.15f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform[] translates;
    public bool IsOnGround => isOnGround;
    private void Update()
    {
        foreach(Transform footTransform in translates)
        {
            checkFootOnGround(footTransform);
            if (isOnGround) break;
        }
    }
    private void checkFootOnGround(Transform footTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
        // forward = z ekseninde 1 birim demek. nesne rotation.x 90 yaptık ve aşağıya doğru baktı
        // forward ile ışın z yönünde aşağı işaret etti
        // maxDistance = mesafe demek, 
        Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);
        if(hit.collider != null)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
}
