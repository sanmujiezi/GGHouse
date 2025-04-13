using Game.Core.Event;
using Game.Core.InputGame;
using Game.Core.PlayerModel;
using Game.Utility;
using UnityEngine;


namespace Game.Core.GameInteract
{
    public class GameObjectInteract : MonoBehaviour, ICanInteract
    {
        public InteractType interactType = InteractType.Click;
        protected Transform m_collider;
        protected UIInteractTip m_UITip;
        private bool m_canInteract;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_collider = transform.Find("Collider").GetComponent<Transform>();
            m_UITip = transform.Find("m_UIIntarct").GetComponent<UIInteractTip>();
            SetInteract(true);
        }

        public virtual void Interact()
        {
            DebugLogger.Instance.Log(this,$"trigger the reward!");
        }

        private void SetInteract(bool canInteract)
        {
            m_canInteract = canInteract;
            m_collider.gameObject.SetActive(canInteract);
        }

        public void SetActiveWithUIInteract(bool active)
        {
            m_UITip.gameObject.SetActive(active);
        }

        public void SetUITextContent(string text)
        {
            m_UITip.SetTextContent(text);
        }

        public void SetProgress(float progress)
        {
            m_UITip.SetProgress(progress);
        }
    }
}