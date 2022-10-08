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

    private Rigidbody2D controllerRigibody;

    [Header("依赖脚本")]
    [SerializeField] Animator animator;

    [Header("移动参数")]
    [SerializeField] float maxSpeed = 0.0f;
    [SerializeField] float maxGravityVelocity = 10.0f;
    [SerializeField] float jumpForce = 0.0f;
    [SerializeField] float groundedGravityScale = 0.0f;

    [SerializeField] float jumpGravityScale = 0.0f;
    [SerializeField] float fallGravityScale = 0.0f;

    private Vector2 vectorInput;
    private int jumpCount;
    private bool JumpInput;
    private float counter;

    private bool enableGravity;
    private bool canMove;

    private bool isOnGround;
    private bool isFacingLeft;
    private bool isJumping;
    private bool isFalling;

    private int animatorFirstLandingBool;
    private int animatorGroundedBool;
    private int animatorMovementSpeed;
    private int animatorVelocitySpeed;
    private int animatorJumpTrigger;
    private int animatorDoubleJumpTrigger;

    [Header("其它参数")]
    [SerializeField] private bool firstLanding;

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
/*        animatorFirstLandingBool = Animator.StringToHash("FirstLanding");
        animatorGroundedBool = Animator.StringToHash("Grounded");
        animatorVelocitySpeed = Animator.StringToHash("Velocity");
        animatorMovementSpeed = Animator.StringToHash("Movement");
        animatorJumpTrigger = Animator.StringToHash("Jump");
        animatorDoubleJumpTrigger = Animator.StringToHash("DoubleJump");

        animator.SetBool(animatorFirstLandingBool, firstLanding);*/

        enableGravity = true;
        canMove = true;
    }

    private void FixedUpdate()
    {
        UpdateVelocity();
        UpdateDirection();

    }

    #endregion

    #region Movement

    private void UpdateVelocity()
    {
        Vector2 velocity = controllerRigibody.velocity;
        if (vectorInput.x != 0)
        {
            velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity / 2, maxGravityVelocity / 2);
        }
        else
        {
            velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity, maxGravityVelocity);
        }
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

    private void UpdateGrounding(Collision2D collision, bool exitState)
    {
        if (exitState)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Terrian") || collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrian"))
            {
                isOnGround = false;

            }
        }
        else
        {
            //判断为落地状态
            if (collision.gameObject.layer == LayerMask.NameToLayer("Terrian")
                || collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrian")
                && collision.contacts[0].normal == Vector2.up
                && !isOnGround)
            {
                isOnGround = true;
                isJumping = false;
                isFalling = false;
            }
            //判断为头顶碰到物体状态
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Terrian") || collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrian")
                && collision.contacts[0].normal == Vector2.down && isJumping)
            {

            }
        }
        animator.SetBool(animatorGroundedBool, isOnGround);
    }

    public void StopHorizontalMovement()
    {
        Vector2 velocity = controllerRigibody.velocity;
        velocity.x = 0;
        controllerRigibody.velocity = velocity;
        animator.SetInteger(animatorMovementSpeed, 0);
    }

    public void SetIsOnGrounded(bool state)
    {
        isOnGround = state;
        animator.SetBool(animatorGroundedBool, isOnGround);
    }
    #endregion

    #region Combat
    private void Jump_Canceled(InputAction.CallbackContext context)
    {

    }

    private void Jump_Performed(InputAction.CallbackContext context)
    {

    }

    private void Jump_Started(InputAction.CallbackContext context)
    {

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

    #region Others

    public void FirstLanding()
    {

    }
 
    #endregion
}
