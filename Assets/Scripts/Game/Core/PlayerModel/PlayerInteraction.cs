using System.Collections;
using System.Collections.Generic;
using Game.Core.GameInteract;
using Game.Core.InputGame;
using Game.Utility;
using UnityEngine;

namespace Game.Core.PlayerModel
{
    public interface ICanInteract
    {
        void Interact();
    }

    public enum InteractType
    {
        Click,
        Press
    }

    public class PlayerInteraction
    {
        private Transform m_playerTransform;
        private Transform m_headPoint;
        private PlayerController m_playerController;
        private List<GameObjectInteract> interactObjs;
        private GameObjectInteract m_seletedInteractObj;
        public bool interacting;

        public GameObjectInteract selectedInteractObj
        {
            get { return m_seletedInteractObj; }
            set
            {
                if (m_seletedInteractObj != null || m_seletedInteractObj != default(GameObjectInteract))
                {
                    m_seletedInteractObj.SetActiveWithUIInteract(false);
                }

                m_seletedInteractObj = value;
                if (m_seletedInteractObj != null || m_seletedInteractObj != default(GameObjectInteract))
                {
                    m_seletedInteractObj.SetActiveWithUIInteract(true);
                }
            }
        }

        public PlayerInteraction(PlayerController playerController)
        {
            interactObjs = new List<GameObjectInteract>();
            m_playerController = playerController;
            m_playerTransform = playerController.transform;
            m_headPoint = m_playerTransform.Find("HandPoint");

            if (!m_headPoint)
            {
                DebugLogger.Instance.LogError(this, "HeadPoint is null");
            }
        }

        public void Update()
        {
            if (GameInputSystem.Instance.PressInteractBtn())
            {
                Debug.Log("input");
            }
        }

        public bool IsStartInteractCheck()
        {
            return interactObjs.Count > 1 ? true : false;
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

        public IEnumerator SelectInteractObj()
        {
            while (true)
            {
                var _tempInteract = interactObjs[0];
                foreach (var VARIABLE in interactObjs)
                {
                    float preDis = GetDisWithPlayer(_tempInteract.transform.position);
                    float curDis = GetDisWithPlayer(VARIABLE.transform.position);
                    if (curDis < preDis)
                    {
                        _tempInteract = VARIABLE;
                    }
                }
                selectedInteractObj = _tempInteract;
                yield return null;
            }
        }

        private float GetDisWithPlayer(Vector3 target)
        {
            var dis = Vector3.Distance(m_playerController.transform.position,target);
            return dis;
        }
    }
}