using System.Collections.Generic;
using Game.Core.GameInteract;
using Game.Core.Interface;
using Game.Utility;
using UnityEngine;

namespace Game.Core.PlayerModel
{
    public interface ICanInteract
    {
        void Interact();
    }
    
    public class PlayerInteraction
    {
        private Transform m_playerTransform;
        private Transform m_headPoint;
        private PlayerController m_playerController;
        private List<GameObjectInteract> interactObjs;        
        public PlayerInteraction(PlayerController playerController)
        {
            m_playerController = playerController;
            m_playerTransform = playerController.transform;
            m_headPoint = m_playerTransform.Find("HandPoint");

            if (!m_headPoint )
            {
                DebugLogger.Instance.LogError(this,"HeadPoint is null");
            }
        }

        public void SetHandPoint(GameObject gameObject)
        {
            gameObject.transform.parent = m_headPoint;
            gameObject.transform.localPosition = Vector3.zero;
        }

        public void AddInteractList(GameObjectInteract objectInteract)
        {
            interactObjs.Add(objectInteract);
        }
        public void RemoveInteractList(GameObjectInteract objectInteract)
        {
            interactObjs.Remove(objectInteract);
        }
        
        
    }
}