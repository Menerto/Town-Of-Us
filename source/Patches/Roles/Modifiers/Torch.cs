using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class Torch : Modifier
    {
        public Torch(PlayerControl player) : base(player)
        {
            Name = "Torch".Translate();
            TaskText = () => "TorchInfo".Translate();
            Color = new Color(1f, 1f, 0.6f);
            ModifierType = ModifierEnum.Torch;
        }
    }
}