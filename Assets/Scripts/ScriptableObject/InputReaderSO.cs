using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
    public class InputReaderSO : UnityEngine.ScriptableObject ,Player_1.IGamePlayActions 
    {
        public void OnMove(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
