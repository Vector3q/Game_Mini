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

    [Header("移动参数")]
    [SerializeField] float maxSpeed = 0.0f;
    [SerializeField] float jumpForce = 0.0f;

    [SerializeField] float maxGravityVelocity = 10.0f;
    [SerializeField] float jumpGravityScale = 1.0f;
    [SerializeField] float fallGravityScale = 1.0f;
    [SerializeField] float groundedGravityScale = 1.0f;

    public Vector2 vectorInput;
    public bool JumpInput;
    public int jumpCount;
    public bool enableGravity;

    private bool isOnGround;
    private bool isFacingLeft;
    public bool isJumping;
    private bool isFalling;

    [Header("其它参数")]
    [SerializeField] private bool firstLanding;

    private int animatorFirstLandingBool;
    private int animatorGroundedBool;
    private int animatorMovementSpeed;
    private int animatorVelocitySpeed;
    private int animatorJumpTrigger;
    private int animatorDoubleJumpTrigger;

    public float counter;
    public bool canMove;

    #endregion

    #region CallBackFunctions

    private void Awake()
    {
        controllerRigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        InputManager.InputControl.GamePlayer.Movement.performed += ctx => vectorInput = ctx.ReadValue<Vector2>();
        InputManager.InputControl.GamePlayer.Jump.started += Jump_Started;
        InputManager.InputControl.GamePlayer.Jump.performed += Jump_Performed;
        InputManager.InputControl.GamePlayer.Jump.canceled += Jump_Canceled;
    }

    private void OnDisable()
    {
        InputManager.InputControl.GamePlayer.Movement.performed -= ctx => vectorInput = ctx.ReadValue<Vector2>();
        InputManager.InputControl.GamePlayer.Jump.started -= Jump_Started;
        InputManager.InputControl.GamePlayer.Jump.performed -= Jump_Performed;
        InputManager.InputControl.GamePlayer.Jump.canceled -= Jump_Canceled;
    }

    private void Start()
    {
        animatorFirstLandingBool = Animator.StringToHash("FirstLanding");
        animatorGroundedBool = Animator.StringToHash("Grounded");
        animatorMovementSpeed = Animator.StringToHash("Movement");
        animatorVelocitySpeed = Animator.StringToHash("Velocity");
        animatorJumpTrigger = Animator.StringToHash("Jump");
        animatorDoubleJumpTrigger = Animator.StringToHash("DoubleJump");

        animator.SetBool(animatorFirstLandingBool, firstLanding);

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
    }

    private void UpdateDirection()
    {
        //控制玩家的旋转
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

    private void UpdateJump()
    {
        //下落
        if (isJumping && controllerRigibody.velocity.y < 0)
        {
            isFalling = true;
        }

        //跳跃
        if (JumpInput)
        {
            controllerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;

        }
        if (isOnGround && !isJumping && jumpCount != 0) //如果已经落地了，则重置跳跃计数器
        {
            jumpCount = 0;
            counter = Time.time - counter;
        }
    }

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
        if (jumpCount == 1)
        {
            animator.ResetTrigger(animatorJumpTrigger);
        }
        else if (jumpCount == 2)
        {
            animator.ResetTrigger(animatorDoubleJumpTrigger);
        }
    }

    private void UpdateGrounding(Collision2D collision, bool exitState)
    {
        if (exitState)
        {
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
    private void Jump_Canceled(InputAction.CallbackContext context)
    {
        JumpCancel();
    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {

    }

    private void Jump_Started(InputAction.CallbackContext context)
    {
        counter = Time.time;
        if (jumpCount <= 1)
        {
            ++jumpCount;
            if (jumpCount == 1)
            {
                animator.SetTrigger(animatorJumpTrigger);
            }
            else if (jumpCount == 2)
            {
                animator.SetTrigger(animatorDoubleJumpTrigger);
            }
        }
        else
        {
            return;
        }
        JumpInput = true;
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