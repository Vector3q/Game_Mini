using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputControl inputControl;
    public static InputControl InputControl
    {
        get
        {
            if (inputControl == null)
            {
                inputControl = new InputControl();
            }
            return inputControl;
        }
    }

    private void OnEnable()
    {
        InputControl.GamePlayer.Movement.Enable();
        InputControl.GamePlayer.Jump.Enable();
        InputControl.GamePlayer.Attack.Enable();
        InputControl.GamePlayer.Flash.Enable();
        InputControl.GamePlayer.Skill_1.Enable();
        InputControl.GamePlayer.Skill_2.Enable();
    }

    private void OnDisable()
    {
        InputControl.GamePlayer.Movement.Disable();
        InputControl.GamePlayer.Jump.Disable();
        InputControl.GamePlayer.Attack.Disable();
        InputControl.GamePlayer.Flash.Disable();
        InputControl.GamePlayer.Skill_1.Disable();
        InputControl.GamePlayer.Skill_2.Disable();
    }
}
