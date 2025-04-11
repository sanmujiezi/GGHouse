using Game.Core.Event;
using Game.Core.GameInteract;
using Game.Utility;
using UnityEngine;

namespace Game.Core.PlayerModel
{
    public class PlayerEvnetor : PlayerBaseCompontent
    {
        
        public PlayerEvnetor(PlayerController playerController) : base(playerController)
        {
            
        }

        public void Listener()
        {
            GlobleEventSystem.OnGetObjet += InteractWithObject;
        }

        public void UnListener()
        {
            GlobleEventSystem.OnGetObjet -= InteractWithObject;
        }

        private void InteractWithObject(ICanInteract canInteract)
        {
            DebugLogger.Instance.Log(this,$"收到了消息");
            canInteract.Interact();
        }
        
        
    }
}