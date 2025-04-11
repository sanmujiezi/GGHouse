using Game.Core.Event;
using Game.Core.InputGame;
using Game.Core.PlayerModel;
using Game.Utility;
using UnityEngine;


namespace Game.Core.GameInteract
{
    public class GameObjectInteract : MonoBehaviour, ICanInteract
    {
        protected Transform m_collider;
        private bool m_canInteract;

        private void Awake()
        {
            Init();
            
        }

        private void Init()
        {
            m_collider = transform.Find("Collider").GetComponent<Transform>();
            SetInteract(true);
        }

        public virtual void Interact()
        {
            
        }

        private void SetInteract(bool canInteract)
        {
            m_canInteract = canInteract;
            m_collider.gameObject.SetActive(false);
        }
        
        
    }
}