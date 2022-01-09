using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PCInput _input;
    public Mover _mover;
    public Jump _jump;
    public float horizontal;
    CharcterAnimation _characterAnimator;
    Flib _flib;
    OnGround _onGround;
 //   Climbing _climbing;
    Health _health;
    //LadderController _ladderController;
    float _vertical;
    private void Awake()
    {
        _input = new PCInput(); // intance
        _characterAnimator = GetComponent<CharcterAnimation>();
        _jump = GetComponent<Jump>();
        _flib = GetComponent<Flib>();
        _onGround = GetComponent<OnGround>();
    //    _climbing = GetComponent<Climbing>();
        //_ladderController = GetComponent<LadderController>();
        _health = GetComponent<Health>();
        
    }
    private void OnEnable()
    {
        GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

        if(gameCanvas != null)
        {
            _health.OnDead += gameCanvas.ShowGameOverPanel;
            DisPlayHealth disPlayHealth= gameCanvas.GetComponentInChildren<DisPlayHealth>();
            _health.OnHealtChanged += disPlayHealth.WriteHealt;
           // disPlayHealth.WriteHealt(_health.MaxHealth);
        }
    }
    private void Update()
    {
        
        if (_health.IsDead) return;
         // Hareket
        horizontal = _input.Horizontal;
        _vertical = _input.Vertical;

        if (_input.IsJumpButtonDown && _onGround.IsOnGround )//&& //!_climbing.IsClimbing) //Input.GetButtonDown("Jump")) // Zıplama
        {
            _jump._isJump = true;
           // _isJump = true;
        }
        // yürüme animasyonu
        _characterAnimator.MoveAnimator(horizontal);
        // zıplama animasyonu
        _characterAnimator.JumpAnimtion(!_onGround.IsOnGround && _jump.IsJump);
        // tırmanma animasyonu
    //    _characterAnimator.ClimbingAnimation(_climbing.IsClimbing);
    }
    private void FixedUpdate()
    {

    //    _climbing.ClimbAction(_vertical);
        // ZIPLAMA
        _jump.JumpAction();
        // zıplama animasyonu
       // Debug.Log(_jump.IsJumpAction);
        //_characterAnimator.JumpAnimtion(_jump.IsJumpAction);
        // hareket, sağa ve sola yürüme
        _mover.MoverAction(horizontal);

        //Yön Değiştirme
        diversion();
    }
    public void diversion()
    {
        // Yön Değiştirme
        if (horizontal != 0)
        {
            _flib.FlibChacter(horizontal);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage damage = collision.collider.GetComponent<Damage>();
        if (
            collision.HasHitEnemy() && collision.WasHitLeftOrRightSide())
        {
            //_health.TakeHit(damage);
            //return;
            damage.HitTarget(_health);
            return; 
        }
        if(damage != null && collision.HasHitEnemy())
        {
            damage.HitTarget(_health);
            _jump.JumpAction();
        }
    }
}
