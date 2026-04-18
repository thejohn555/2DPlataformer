using System;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
    public class InputReaderSO : UnityEngine.ScriptableObject ,MyPlayerActions.IGamePlayActionsActions
    {

        public event Action OnJumpStart;
        public event Action OnAtackStart;
        public event Action<float> OnMoveStart;
        public event Action OnCrouchStart,OnCrouchEnd;

        [SerializeField] private string jump;
        [SerializeField] private string left;
        [SerializeField] private string right;
        [SerializeField] private string crouch;
        [SerializeField] private string atack;

        public MyPlayerActions PlayerActions { get; private set; }

        private void OnEnable()
        {
            PlayerActions = new MyPlayerActions();
            PlayerActions.GamePlayActions.Enable();
            PlayerActions.GamePlayActions.AddCallbacks(this);
            
        }

        private void OnDisable()
        {
            PlayerActions.GamePlayActions.Disable();
        }
        public void Initialize()
        {
            PlayerActions.GamePlayActions.Jump.ApplyBindingOverride(0,$"<Keyboard>/{jump}");
            PlayerActions.GamePlayActions.Crouch.ApplyBindingOverride(0,$"<Keyboard>/{crouch}");
            PlayerActions.GamePlayActions.Atack.ApplyBindingOverride(0,$"<Keyboard>/{atack}");
            PlayerActions.GamePlayActions.Move.ApplyBindingOverride(1,$"<Keyboard>/{right}");
            PlayerActions.GamePlayActions.Move.ApplyBindingOverride(2,$"<Keyboard>/{left}");
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            OnMoveStart?.Invoke(context.ReadValue<float>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnJumpStart?.Invoke();
            }
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnCrouchStart?.Invoke();
            }
            else if(context.canceled)
            {
                OnCrouchEnd?.Invoke();
            }
        }

        public void OnAtack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnAtackStart?.Invoke();
            }
        }
    }
}
