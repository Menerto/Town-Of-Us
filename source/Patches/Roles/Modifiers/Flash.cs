using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class Flash : Modifier
    {
        public Flash(PlayerControl player) : base(player)
        {
            Name = "Flash".Translate();
            TaskText = () => "FlashInfo".Translate();
            Color = new Color(1f, 0.5f, 0.5f, 1f);
            ModifierType = ModifierEnum.Flash;
        }
    }
}