using Com.LuisPedroFonseca.ProCamera2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CriWare;
using Game.Skill;

public class PlayerController : MonoBehaviour
{
    #region Propertries
    readonly Vector3 flippedleft = new Vector3(-1.4f, 1.4f, 1.4f);
    readonly Vector3 flippedright = new Vector3(1.4f, 1.4f, 1.4f);

    [Header("依赖组件")]
    public Animator animator = null;
    public Rigidbody2D controllerRigibody;
    private SpriteRenderer mt;

    [Header("基础属性")]
    public int PlayerHealth = 3;

    [Header("移动参数")]
    public Vector2 vectorInput;
    public float maxSpeed = 1.0f;
    public float Speed = 1.0f;
    public float Flashspeed = 1.0f;
    public float MoveForce = 1.0f;

    [Header("跳跃参数")]
    public float jumpForce = 1.0f;
    public float maxJumpVelocity = 10.0f;
    public float maxFallVelocity = 10.0f;
    public float jumpGravityScale = 1.0f;
    public float fallGravityScale = 1.0f;
    public float groundedGravityScale = 1.0f;
    public bool enableGravity;

    [Header("状态参数")]
    static public bool AttackInput;
    public bool JumpInput;
    public bool FlashInput;

    public bool isFacingLeft;
    public bool isOnGround;
    public int jumpCount;
    public bool isJumping;
    public bool isFalling;
    static public bool isSkilling = false;
    public bool isBeAttacked = false;

    public float counter;
    public bool canMove;
    public bool canAttack;

    [Header("动画参数")]
    private int animatorGroundedBool;
    private int animatorMovementSpeed;
    private int animatorVelocitySpeed;
    private int animatorJumpTrigger;
    private int animatorAttackTrigger;
    private int animatorFlashTrigger;

    [Header("音效参数")]
    public CriAtomSource CRIsource;

    [Header("游戏管理")]
    public GameObject game_manager;
    #endregion

    #region CallBackFunctions

    private void Awake()
    {
        controllerRigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mt = gameObject.GetComponent<SpriteRenderer>();
        gameObject.GetComponent<CharacterSkillManager>().skills[0] = game_manager.GetComponent<GameManager>().SkillPool[7];
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

        InputManager.InputControl.GamePlayer.Skill_1.started += Skill_1_started;
        InputManager.InputControl.GamePlayer.Skill_1.performed += Skill_1_performed;
        InputManager.InputControl.GamePlayer.Skill_1.canceled += Skill_1_canceled;

        InputManager.InputControl.GamePlayer.Skill_2.started += Skill_2_started;
        InputManager.InputControl.GamePlayer.Skill_2.performed += Skill_2_performed;
        InputManager.InputControl.GamePlayer.Skill_2.canceled += Skill_2_canceled;
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

        InputManager.InputControl.GamePlayer.Skill_1.started -= Skill_1_started;
        InputManager.InputControl.GamePlayer.Skill_1.performed -= Skill_1_performed;
        InputManager.InputControl.GamePlayer.Skill_1.canceled -= Skill_1_canceled;

        InputManager.InputControl.GamePlayer.Skill_2.started -= Skill_2_started;
        InputManager.InputControl.GamePlayer.Skill_2.performed -= Skill_2_performed;
        InputManager.InputControl.GamePlayer.Skill_2.canceled -= Skill_2_canceled;
    }

    private void Start()
    {
        animatorGroundedBool = Animator.StringToHash("Grounded");
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
        UpdateHealth();
        if (canMove)
        {
            UpdateDirection();
            UpdateJump();
            UpdateGravityScale();
        }
    }
    #endregion

    #region Health
    private void UpdateHealth()
    {
        if (isBeAttacked == true)
        {
            if (canMove  && PlayerHealth > 0)
            {
                canMove = false;
                PlayerHealth--;
                animator.Play("Player_BeAttacked");
                StartCoroutine(BeAttacked());
            }
        }
    }

    IEnumerator BeAttacked()
    {
        mt.material.SetColor("_Color", Color.white);
        mt.material.SetInt("_BeAttack", 1);
        yield return new WaitForSeconds(0.1f);
        mt.material.SetInt("_BeAttack", 0);

        yield return new WaitForSeconds(0.4f);

        canMove = true;
        isBeAttacked = false;
        
        if (PlayerHealth <= 0)
        {
            animator.SetTrigger("Dead");
            canMove = false;
            GameEvents.current.PlayerDie();
        }
    }

    #endregion

    #region Movement
    /// <summary>
    /// 控制玩家的移动(加力的方式)
    /// </summary>
    private void UpdateVelocity()
    {
        int x = 1;
        if (isFacingLeft) x = -1;
        if(!isBeAttacked)
        {
            if (vectorInput.x != 0)
            {
                controllerRigibody.AddForce(new Vector2(vectorInput.x * MoveForce, 0), ForceMode2D.Impulse);
            }
            else if (vectorInput.x == 0 && FlashInput) 
            { 
                controllerRigibody.AddForce(new Vector2(x * MoveForce, 0), ForceMode2D.Impulse); 
            }
        }
        Vector2 velocity = controllerRigibody.velocity;
        if(!canMove) { velocity.x = 0; }
        if (vectorInput.x == 0 && !FlashInput){velocity.x = 0;}
        if (FlashInput) { velocity.y = 0; }
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxFallVelocity, maxJumpVelocity);
        controllerRigibody.velocity = velocity;
        animator.SetFloat(animatorVelocitySpeed, controllerRigibody.velocity.y);
        animator.SetInteger(animatorMovementSpeed, (int)controllerRigibody.velocity.x);

        if (isBeAttacked)
        {
            controllerRigibody.AddForce(new Vector2(-x * 8, 0), ForceMode2D.Impulse);
            velocity = controllerRigibody.velocity;
            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
            controllerRigibody.velocity = velocity;
        }
    }

    /// <summary>
    /// 控制玩家的旋转
    /// </summary>
    private void UpdateDirection()
    {
        if(!isBeAttacked){
            if (controllerRigibody.velocity.x > 1f && isFacingLeft)
            {
                isFacingLeft = false;
                transform.localScale = flippedright;
            }
            else if (controllerRigibody.velocity.x < -1f && !isFacingLeft)
            {
                isFacingLeft = true;
                transform.localScale = flippedleft;
            }
        }
    }

    /// <summary>
    /// 控制玩家的跳跃
    /// </summary>
    private void UpdateJump()
    {
        if (JumpInput && jumpCount == 0)
        {
            StartCoroutine(Jump());
            //controllerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //animator.SetTrigger(animatorJumpTrigger);
        }
        if (isOnGround && isJumping && jumpCount != 0) //如果已经落地了，则重置跳跃计数器
        {
            jumpCount = 0;
            isFalling = false;
            isJumping = false;
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
        yield return new WaitForSeconds(0.02f);
        controllerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
    }

    /// <summary>
    /// 控制玩家的重力
    /// </summary>
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

    /// <summary>
    /// 根据碰撞更新地面接触状态
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="exitState"></param>
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
                CRIsource.Play("Land");
                isOnGround = true;
            }
            //判断为落地状态
            if (collision.gameObject.tag == "Enemy" && !isOnGround)
            {
                CRIsource.Play("Land");
                isOnGround = true;
            }
        }
        animator.SetBool(animatorGroundedBool, isOnGround);
    }
    #endregion

    #region Combat
    /// <summary>
    /// 跳跃键输入
    /// </summary>
    /// <param name="context"></param>
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

    /// <summary>
    /// 攻击键输入
    /// </summary>
    /// <param name="context"></param>
    private void Attack_started(InputAction.CallbackContext context)
    {
        if (canMove && !FlashInput && !isSkilling)
        {
            AttackInput = true;
            animator.Play("Player_CommonAttack");
        }
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {

    }

    private void Attack_canceled(InputAction.CallbackContext context)
    {
        AttackCancel();
    }

    /// <summary>
    /// 瞬移键输入
    /// </summary>
    /// <param name="context"></param>
    private void Flash_started(InputAction.CallbackContext context)
    {
        if(canMove && !FlashInput)
            StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        FlashInput = true;
        animator.SetTrigger(animatorFlashTrigger);
        yield return new WaitForSeconds(0.02f);
        maxSpeed = Flashspeed;
        controllerRigibody.AddForce(new Vector2(10* vectorInput.x * MoveForce, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.43f);
        maxSpeed = Speed;
        yield return new WaitForSeconds(0.05f);
        FlashInput = false;
    }

    private void Flash_performed(InputAction.CallbackContext context)
    {

    }

    private void Flash_canceled(InputAction.CallbackContext context)
    {
        animator.ResetTrigger(animatorFlashTrigger);
    }

    /// <summary>
    /// 技能键输入1
    /// </summary>
    /// <param name="context"></param>
    private void Skill_1_started(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            Game.Skill.CharacterSkillManager manager = GetComponent<Game.Skill.CharacterSkillManager>();
            if (manager.skills[0].isPassive)
                return;
            Game.Skill.SkillData data = manager.PrepareSkill(manager.skills[0].skillID);
            if (data != null)
                manager.GenerateSkill(data);
        }
    }

    private void Skill_1_performed(InputAction.CallbackContext context)
    {

    }

    private void Skill_1_canceled(InputAction.CallbackContext context)
    {

    }

    /// <summary>
    /// 技能键输入2
    /// </summary>
    /// <param name="context"></param>
    private void Skill_2_started(InputAction.CallbackContext context)
    {
        if (canMove)
        {
            Game.Skill.CharacterSkillManager manager = GetComponent<Game.Skill.CharacterSkillManager>();
            if (manager.skills[1].isPassive)
                return;
            Game.Skill.SkillData data = manager.PrepareSkill(manager.skills[1].skillID);
            if (data != null)
                manager.GenerateSkill(data);
        }
    }

    private void Skill_2_performed(InputAction.CallbackContext context)
    {

    }

    private void Skill_2_canceled(InputAction.CallbackContext context)
    {

    }

    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="collision"></param>
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