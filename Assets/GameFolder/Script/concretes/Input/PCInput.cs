using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");
    public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
    
}
