//using Com.LuisPedroFonseca.ProCamera2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Propertries

    readonly Vector3 flippedScale = new Vector3(-1, 1, 1);

    [Header("依赖组件")]
    private Animator animator = null;
    private Rigidbody2D controllerRigibody;
    public GameObject sword;

    [Header("移动参数")]
    [SerializeField] float maxSpeed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;

    [SerializeField] float maxGravityVelocity = 10.0f;
    [SerializeField] float jumpGravityScale = 1.0f;
    [SerializeField] float fallGravityScale = 1.0f;
    [SerializeField] float groundedGravityScale = 1.0f;

    public Vector2 vectorInput;
    public bool JumpInput;
    public int jumpCount;
    public bool enableGravity;
    public bool AttackInput;

    public bool isOnGround;
    public bool isFacingLeft;
    public bool isJumping;
    public bool isFalling;

    [Header("其它参数")]
    private int animatorGroundedBool;
    private int animatorStopBool;
    private int animatorMovementSpeed;
    private int animatorVelocitySpeed;
    private int animatorJumpTrigger;
    private int animatorAttackTrigger;


    public float counter;
    public bool canMove;

    #endregion

    #region CallBackFunctions

    private void Awake()
    {
        controllerRigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sword = GameObject.Find("Sword");
    }

    private void OnEnable()
    {
        InputManager.InputControl.GamePlayer.Movement.performed += ctx => vectorInput = ctx.ReadValue<Vector2>();
        InputManager.InputControl.GamePlayer.Jump.started += Jump_Started;
        InputManager.InputControl.GamePlayer.Jump.performed += Jump_Performed;
        InputManager.InputControl.GamePlayer.Jump.canceled += Jump_Canceled;
        InputManager.InputControl.GamePlayer.Attack.started += Attack_started;
        InputManager.InputControl.GamePlayer.Attack.performed += Attack_performed;
        InputManager.InputControl.GamePlayer.Attack.canceled += Attack_canceled;
    }

    private void OnDisable()
    {
        InputManager.InputControl.GamePlayer.Movement.performed -= ctx => vectorInput = ctx.ReadValue<Vector2>();
        InputManager.InputControl.GamePlayer.Jump.started -= Jump_Started;
        InputManager.InputControl.GamePlayer.Jump.performed -= Jump_Performed;
        InputManager.InputControl.GamePlayer.Jump.canceled -= Jump_Canceled;
        InputManager.InputControl.GamePlayer.Attack.started -= Attack_started;
        InputManager.InputControl.GamePlayer.Attack.performed -= Attack_performed;
        InputManager.InputControl.GamePlayer.Attack.canceled -= Attack_canceled;
    }

    private void Start()
    {
        animatorGroundedBool = Animator.StringToHash("Grounded");
        animatorStopBool = Animator.StringToHash("Stop");
        animatorMovementSpeed = Animator.StringToHash("Movement");
        animatorVelocitySpeed = Animator.StringToHash("Velocity");
        animatorJumpTrigger = Animator.StringToHash("Jump");
        animatorAttackTrigger = Animator.StringToHash("Attack");

        enableGravity = true;
        canMove = true;
    }

    private void FixedUpdate()
    {
        UpdateVelocity();
        UpdateDirection();
        UpdateJump();
        UpdateGravityScale();
    }

    #endregion

    #region Movement

    //控制玩家的移动
    private void UpdateVelocity()
    {
        Vector2 velocity = controllerRigibody.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity, maxGravityVelocity);
        animator.SetFloat(animatorVelocitySpeed, controllerRigibody.velocity.y);
        if (canMove)
        {
            controllerRigibody.velocity = new Vector2(vectorInput.x * maxSpeed, velocity.y);
            animator.SetInteger(animatorMovementSpeed, (int)vectorInput.x);
        }
        if (vectorInput.x == 0)
            animator.SetBool(animatorStopBool, true);
        else
            animator.SetBool(animatorStopBool, false);
    }

    //控制玩家的旋转
    private void UpdateDirection()
    {
        if (controllerRigibody.velocity.x > 1f && isFacingLeft)
        {
            isFacingLeft = false;
            transform.localScale = Vector3.one;
        }
        else if (controllerRigibody.velocity.x < -1f && !isFacingLeft)
        {
            isFacingLeft = true;
            transform.localScale = flippedScale;
        }
    }

    //控制玩家的跳跃
    private void UpdateJump()
    {
        if (JumpInput && jumpCount == 0)
        {
            ++jumpCount;
            controllerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger(animatorJumpTrigger);
            isJumping = true;
        }
        if (isOnGround && jumpCount != 0) //如果已经落地了，则重置跳跃计数器
        {
            jumpCount = 0;
            counter = Time.time - counter;
        }
        //判断下落
        if (isJumping && controllerRigibody.velocity.y < 0)
        {
            isFalling = true;
        }
    }

    //控制玩家的重力
    private void UpdateGravityScale()
    {
        var gravityScale = groundedGravityScale;

        if (!isOnGround)
        {
            gravityScale = controllerRigibody.velocity.y > 0.0f ? jumpGravityScale : fallGravityScale;
        }

        if (!enableGravity)
        {
            gravityScale = 0;
        }

        controllerRigibody.gravityScale = gravityScale;
    }

    private void JumpCancel()
    {
        JumpInput = false;
        isJumping = false;
        animator.ResetTrigger(animatorJumpTrigger);
    }

    private void AttackCancel()
    {
        AttackInput = false;
        animator.ResetTrigger(animatorAttackTrigger);
    }

    private void UpdateGrounding(Collision2D collision, bool exitState)
    {
        if (exitState)
        {
            //判断不在地面
            if (collision.gameObject.tag == "Ground" && isOnGround)
            {
                isOnGround = false;
            }
        }
        else
        {
            //判断为落地状态
            if (collision.gameObject.tag == "Ground"  && !isOnGround)
            {
                isOnGround = true;
                isJumping = false;
                isFalling = false;
            }
        }
        animator.SetBool(animatorGroundedBool, isOnGround);
    }
    #endregion

    #region Combat
    private void Jump_Started(InputAction.CallbackContext context)
    {
        counter = Time.time;
        JumpInput = true;
    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {

    }

    private void Jump_Canceled(InputAction.CallbackContext context)
    {
        JumpCancel();
    }

    private void Attack_started(InputAction.CallbackContext context)
    {
        AttackInput = true;
        //animator.SetTrigger(animatorAttackTrigger);
        animator.Play("Player_Attack");
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {

    }

    private void Attack_canceled(InputAction.CallbackContext context)
    {
        AttackCancel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateGrounding(collision, false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        UpdateGrounding(collision, false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        UpdateGrounding(collision, true);
    }
    #endregion
}