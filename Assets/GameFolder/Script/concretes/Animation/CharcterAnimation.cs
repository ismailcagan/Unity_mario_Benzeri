using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animation))]
public class CharcterAnimation : MonoBehaviour
{
    Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void MoveAnimator(float horizontal)
    {
        if (_animator.GetFloat("moveSpeed") == horizontal) return;
        _animator.SetFloat("moveSpeed", Mathf.Abs(horizontal)); // Animasyon
    }

    public void DyingAnimation()
    {
        _animator.SetTrigger("dying");
    }

    public void JumpAnimtion(bool isJump)
    {
        if (isJump == _animator.GetBool("isJump")) return;
         _animator.SetBool("isJump",isJump);
    }

    public void ClimbingAnimation(bool isClimbing)
    {
        if (_animator.GetBool("isClimb") == isClimbing) return;

        _animator.SetBool("İSClimb", isClimbing);
    }

}
