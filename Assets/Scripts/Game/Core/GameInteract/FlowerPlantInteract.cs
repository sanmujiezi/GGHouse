using Game.Core.PlayerModel;

namespace Game.Core.GameInteract
{
    public class FlowerPlantInteract : GameObjectInteract
    {
        public override void Interact()
        {
            base.Interact();
            PlayerController.Instance.SetHandPoint(gameObject);
        }
    }
}