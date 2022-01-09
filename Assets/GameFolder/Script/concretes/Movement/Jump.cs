using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] float JumpForce = 5f;
    public bool _isJump;
    Rigidbody2D _rigidbody2D;
    public bool IsJump => _rigidbody2D.velocity != Vector2.zero;
    //public bool IsJumpAction => _rigidbody2D.velocity != Vector2.zero; // x ve y sıfır(0) dan büyükse true dö
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void JumpAction()
    {
        // Zıplama
        if (_isJump)
        {
            // _rigidbody2D.AddForce(Vector2.up * JumpForce);
            // _isJump = false;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity = Vector2.up * JumpForce;
            _isJump = false;
        }
    }
}
