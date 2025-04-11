using Game.Core.GameInteract;
using Game.Core.PlayerModel;
using Game.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Core.Event
{
    public class GlobleEventSystem
    {
        public static event UnityAction<ICanInteract> OnGetObjet;
        
        private static GlobleEventSystem _instance;
        public static GlobleEventSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobleEventSystem();
                }
                return _instance;
            }
        }

        public void Interact(ICanInteract canInteract)
        {
            OnGetObjet?.Invoke(canInteract);
        }
        
    }
}