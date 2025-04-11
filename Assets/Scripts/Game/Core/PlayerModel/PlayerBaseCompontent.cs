namespace Game.Core.PlayerModel
{
    public abstract class PlayerBaseCompontent
    {
        protected PlayerController m_playerController;

        public PlayerBaseCompontent(PlayerController playerController)
        {
            m_playerController = playerController;
        }
    }
}