using Game.Core.PlayerModel;
using InputGame;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game.Core.InputGame
{
    public class GameInputSystem : MonoBehaviour
    {
        private static GameInputSystem m_Instance;
        public static GameInputSystem Instance => m_Instance;
        public event UnityAction OnStartMove;
        public event UnityAction OnStopMove;

        private Gameinput gameInput;

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
            
            gameInput = new Gameinput();
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
        
        public bool PressInteractBtn()
        {
            var pressed = gameInput.KeyBoard.Interact.IsPressed();
            return pressed;
        }
    }
}