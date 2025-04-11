using System.Collections.Generic;
using Game.Utility;
using UnityEngine;

namespace Game.Core.PlayerModel
{
    public class PlayerAnimatior : PlayerBaseCompontent
    {
        private string m_isRunStr = "isRun";
        private Animator m_animator;
        
        public PlayerAnimatior(PlayerController playerController) : base(playerController)
        {
            m_animator = m_playerController.GetComponent<Animator>();
        }

        public void SetIsRun(bool isRunning)
        {
            m_animator.SetBool(m_isRunStr, isRunning);
        }

      

    }
}