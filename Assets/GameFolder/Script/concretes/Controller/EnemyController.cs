using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Health _health;
    Damage _damage;
    CharcterAnimation _charcterAnimation;
    Mover _mover;
    Flib _flib;
    OnReachedEdge _onReachedEdge;
    bool _isOnEdge;
    float _direction = 1f;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _damage = GetComponent<Damage>();
        _charcterAnimation = GetComponent<CharcterAnimation>();
        _mover = GetComponent<Mover>();
        _flib = GetComponent<Flib>();

        _onReachedEdge = GetComponent<OnReachedEdge>();
    }
    private void OnEnable()
    {
        _health.OnDead += DeadAction;
    }
    private void FixedUpdate()
    {
        if (_health.IsDead) return;
        _mover.MoverAction(_direction); // mover sağa ve sola hareket etmesini sağlamak için
        _charcterAnimation.MoveAnimator(_direction);
    }
    private void LateUpdate()
    {
        if (_health.IsDead) return;

       if(_onReachedEdge.RachedEdge())
        {
            _direction *= -1;
            _flib.FlibChacter(_direction);
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage damage = collision.collider.GetComponent<Damage>();

        if(collision.HasHitPlayer() && collision.WasHitBottomSide())
        {
            damage.HitTarget(_health);
        }
    }

    private void DeadAction()
    {
       // Destroy(this.gameObject);
        StartCoroutine(DeadActionAsync());
    }

    private IEnumerator DeadActionAsync()
    {
        _charcterAnimation.DyingAnimation();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
