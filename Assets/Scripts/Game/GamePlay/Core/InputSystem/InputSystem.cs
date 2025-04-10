using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputSystem : MonoBehaviour
    {
        private static InputSystem m_Instance;
        public static InputSystem Instance => m_Instance;

        public event Action OnStartMove;
        public event Action OnStopMove;

        private GameInput gameInput;

        private void OnEnable()
        {
            gameInput.Enable();
        }

        private void OnDisable()
        {
            gameInput.Disable();
        }

        private void Awake()
        {
            m_Instance = this;
            
            DontDestroyOnLoad(this);
            
            gameInput = new GameInput();
            gameInput.KeyBoard.Move.started += OnStartInputMove;
            gameInput.KeyBoard.Move.canceled += OnStopInputMove;
        }

        private void OnDestroy()
        {
            gameInput.KeyBoard.Move.started += OnStartInputMove;
            gameInput.KeyBoard.Move.canceled += OnStopInputMove;
        }

        private void OnStopInputMove(InputAction.CallbackContext obj)
        {
            OnStopMove?.Invoke();
        }

        private void OnStartInputMove(InputAction.CallbackContext obj)
        {
            OnStartMove?.Invoke();
        }

        public Vector2 GetMoveVector2Normal()
        {
            return gameInput.KeyBoard.Move.ReadValue<Vector2>().normalized;
        }
    }
}