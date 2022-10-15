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
    public GameObject Attack = null;
    private Animator Attackanimator = null;
    private Rigidbody2D controllerRigibody;

    [Header("移动参数")]
    public float maxSpeed = 1.0f;
    public float Speed = 1.0f;
    public float Flashspeed = 1.0f;
    public float MoveForce = 1.0f;
    public float jumpForce = 1.0f;

    public float maxGravityVelocity = 10.0f;
    public float jumpGravityScale = 1.0f;
    public float fallGravityScale = 1.0f;
    public float groundedGravityScale = 1.0f;

    public Vector2 vectorInput;
    public bool JumpInput;
    public int jumpCount;
    public bool enableGravity;
    static public bool AttackInput;
    public bool FlashInput;

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
    private int animatorFlashTrigger;

    public float counter;
    public bool canMove;
    public bool canAttack;

    #endregion

    #region CallBackFunctions

    private void Awake()
    {
        controllerRigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Attackanimator = Attack.GetComponent<Animator>();
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
        InputManager.InputControl.GamePlayer.Flash.started += Flash_started;
        InputManager.InputControl.GamePlayer.Flash.performed += Flash_performed;
        InputManager.InputControl.GamePlayer.Flash.canceled += Flash_canceled;
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
        InputManager.InputControl.GamePlayer.Flash.started -= Flash_started;
        InputManager.InputControl.GamePlayer.Flash.performed -= Flash_performed;
        InputManager.InputControl.GamePlayer.Flash.canceled -= Flash_canceled;
    }

    private void Start()
    {
        animatorGroundedBool = Animator.StringToHash("Grounded");
        animatorStopBool = Animator.StringToHash("Stop");
        animatorMovementSpeed = Animator.StringToHash("Movement");
        animatorVelocitySpeed = Animator.StringToHash("Velocity");
        animatorJumpTrigger = Animator.StringToHash("Jump");
        animatorAttackTrigger = Animator.StringToHash("Attack");
        animatorFlashTrigger = Animator.StringToHash("Flash");

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
    ///控制玩家的移动
    /*    private void UpdateVelocity()
        {
            Vector2 velocity = controllerRigibody.velocity;
            velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity, maxGravityVelocity);
            animator.SetFloat(animatorVelocitySpeed, controllerRigibody.velocity.y);
            if (canMove)
            {
                controllerRigibody.velocity = new Vector2(vectorInput.x * maxSpeed, velocity.y);
                animator.SetInteger(animatorMovementSpeed, (int)controllerRigibody.velocity.x);
            }
            if (vectorInput.x == 0)
                animator.SetBool(animatorStopBool, true);
            else
                animator.SetBool(animatorStopBool, false);
        }*/

    ///控制玩家的移动(加力的方式)
    private void UpdateVelocity()
    {
        int x = 1;
        if (isFacingLeft) x = -1;
        controllerRigibody.AddForce(new Vector2(vectorInput.x * MoveForce, 0), ForceMode2D.Impulse);
        if (vectorInput.x == 0 && FlashInput) { controllerRigibody.AddForce(new Vector2(x * MoveForce, 0), ForceMode2D.Impulse); }
        Vector2 velocity = controllerRigibody.velocity;
        if (vectorInput.x == 0 && !FlashInput){velocity.x = 0;}
        if (FlashInput) { velocity.y = 0; }
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity, maxGravityVelocity);
        controllerRigibody.velocity = velocity;
        animator.SetFloat(animatorVelocitySpeed, controllerRigibody.velocity.y);
        animator.SetInteger(animatorMovementSpeed, (int)controllerRigibody.velocity.x);
        if (vectorInput.x == 0)
            animator.SetBool(animatorStopBool, true);
        else
            animator.SetBool(animatorStopBool, false);
    }

    ///控制玩家的旋转
    private void UpdateDirection()
    {
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
    }

    ///控制玩家的跳跃
    private void UpdateJump()
    {
        if (JumpInput && jumpCount == 0)
        {
            StartCoroutine(Jump());
            //controllerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //animator.SetTrigger(animatorJumpTrigger);
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

    IEnumerator Jump()
    {
        ++jumpCount;
        animator.SetTrigger(animatorJumpTrigger);
        yield return new WaitForSeconds(0.05f);
        controllerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
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

    private void FlashCancel()
    {
        animator.ResetTrigger(animatorFlashTrigger);
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
    ///跳跃键输入
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

    ///攻击键输入
    private void Attack_started(InputAction.CallbackContext context)
    {
        if (!FlashInput)
        {
            AttackInput = true;
            Attackanimator.SetTrigger(animatorAttackTrigger);
        }
        //Attackanimator.Play("Player_Attack");
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {

    }

    private void Attack_canceled(InputAction.CallbackContext context)
    {
        AttackCancel();
    }

    ///瞬移键输入
    private void Flash_started(InputAction.CallbackContext context)
    {
        if(!FlashInput)
            StartCoroutine(Flash());
        //FlashInput = true;
        //animator.Play("Player_Flash");
    }

    IEnumerator Flash()
    {
        FlashInput = true;
        animator.SetTrigger(animatorFlashTrigger);
        yield return new WaitForSeconds(0.1f);
        maxSpeed = Flashspeed;
        controllerRigibody.AddForce(new Vector2(10* vectorInput.x * MoveForce, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        maxSpeed = Speed;
        yield return new WaitForSeconds(0.02f);
        FlashInput = false;
    }

    private void Flash_performed(InputAction.CallbackContext context)
    {

    }

    private void Flash_canceled(InputAction.CallbackContext context)
    {
        animator.ResetTrigger(animatorFlashTrigger);
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