// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControl"",
    ""maps"": [
        {
            ""name"": ""GamePlayer"",
            ""id"": ""4b8bacac-7f9d-47c1-a719-dbd5891e5db0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cb3bbd34-622a-41a8-bccc-9d09b9571ea4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c932692c-7eb1-489a-aa8e-66e529ffa00e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""58c5585e-8e5f-4dd6-8bec-03918c89be53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flash"",
                    ""type"": ""Button"",
                    ""id"": ""37cbd3ca-24b5-4a3f-8d63-c28fd96ffe6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill_1"",
                    ""type"": ""Button"",
                    ""id"": ""8a338be0-1f9d-4cb3-992c-02f1ce3140a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill_2"",
                    ""type"": ""Button"",
                    ""id"": ""fee4f697-a8ad-4284-88b9-dab72c121b33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""456ada5b-a1ad-4ca5-8b91-d0006b45e6e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8270463f-d89f-4287-8894-daffd40f2d3e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8d077bf8-4d51-472e-8e9c-4f60e7b1f03d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e0df92c2-0e54-4fef-ad00-4da133eb8898"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7cefa0c9-08db-47d9-9d74-2411bef2c6f4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e6efc7dd-7646-42a3-a6fb-2c92077feb2f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ab53b401-1905-46cc-acc2-dc97471dbce4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cf18005d-fa26-4792-b863-dce0ba405b96"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3a7f0d36-971d-4010-9fc0-919392db5780"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b4ed9248-ab18-4162-892f-5aaed7b0e91a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cb4b9c66-7bfd-4e7f-9adb-3814351cfc24"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e9b106a-dc38-4972-93c3-033b226e3fd0"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3b2bf8f-4762-4d6d-a235-80dc7cc0788a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f6aab4e-4d1b-408f-9273-2764a4c0926d"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72682864-d554-4074-afe7-3c96471a6151"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48f79c06-61d5-4bfc-a5f6-56df61f8e05f"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2263cb4a-bfd4-4f03-baf3-a0e3b26c8f04"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46627658-6ba6-4994-8cd5-b222baf422aa"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98e690db-5aa1-4256-8b76-7689a7b3540a"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""27aaa62e-8338-4608-8f61-7d85f0171e7c"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""9b7e05c0-03ba-4181-8223-834174aba7b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e2d1d3ac-856a-4aba-944a-f9fa4c3d4b48"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlayer
        m_GamePlayer = asset.FindActionMap("GamePlayer", throwIfNotFound: true);
        m_GamePlayer_Movement = m_GamePlayer.FindAction("Movement", throwIfNotFound: true);
        m_GamePlayer_Jump = m_GamePlayer.FindAction("Jump", throwIfNotFound: true);
        m_GamePlayer_Attack = m_GamePlayer.FindAction("Attack", throwIfNotFound: true);
        m_GamePlayer_Flash = m_GamePlayer.FindAction("Flash", throwIfNotFound: true);
        m_GamePlayer_Skill_1 = m_GamePlayer.FindAction("Skill_1", throwIfNotFound: true);
        m_GamePlayer_Skill_2 = m_GamePlayer.FindAction("Skill_2", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Newaction = m_UI.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlayer
    private readonly InputActionMap m_GamePlayer;
    private IGamePlayerActions m_GamePlayerActionsCallbackInterface;
    private readonly InputAction m_GamePlayer_Movement;
    private readonly InputAction m_GamePlayer_Jump;
    private readonly InputAction m_GamePlayer_Attack;
    private readonly InputAction m_GamePlayer_Flash;
    private readonly InputAction m_GamePlayer_Skill_1;
    private readonly InputAction m_GamePlayer_Skill_2;
    public struct GamePlayerActions
    {
        private @InputControl m_Wrapper;
        public GamePlayerActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GamePlayer_Movement;
        public InputAction @Jump => m_Wrapper.m_GamePlayer_Jump;
        public InputAction @Attack => m_Wrapper.m_GamePlayer_Attack;
        public InputAction @Flash => m_Wrapper.m_GamePlayer_Flash;
        public InputAction @Skill_1 => m_Wrapper.m_GamePlayer_Skill_1;
        public InputAction @Skill_2 => m_Wrapper.m_GamePlayer_Skill_2;
        public InputActionMap Get() { return m_Wrapper.m_GamePlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayerActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayerActions instance)
        {
            if (m_Wrapper.m_GamePlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnAttack;
                @Flash.started -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnFlash;
                @Flash.performed -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnFlash;
                @Flash.canceled -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnFlash;
                @Skill_1.started -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnSkill_1;
                @Skill_1.performed -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnSkill_1;
                @Skill_1.canceled -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnSkill_1;
                @Skill_2.started -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnSkill_2;
                @Skill_2.performed -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnSkill_2;
                @Skill_2.canceled -= m_Wrapper.m_GamePlayerActionsCallbackInterface.OnSkill_2;
            }
            m_Wrapper.m_GamePlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Flash.started += instance.OnFlash;
                @Flash.performed += instance.OnFlash;
                @Flash.canceled += instance.OnFlash;
                @Skill_1.started += instance.OnSkill_1;
                @Skill_1.performed += instance.OnSkill_1;
                @Skill_1.canceled += instance.OnSkill_1;
                @Skill_2.started += instance.OnSkill_2;
                @Skill_2.performed += instance.OnSkill_2;
                @Skill_2.canceled += instance.OnSkill_2;
            }
        }
    }
    public GamePlayerActions @GamePlayer => new GamePlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Newaction;
    public struct UIActions
    {
        private @InputControl m_Wrapper;
        public UIActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_UI_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGamePlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnFlash(InputAction.CallbackContext context);
        void OnSkill_1(InputAction.CallbackContext context);
        void OnSkill_2(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
