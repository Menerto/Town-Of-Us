using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class BigBoi : Modifier
    {
        public BigBoi(PlayerControl player) : base(player)
        {
            Name = "Giant".Translate();
            TaskText = () => "GiantInfo".Translate();
            Color = new Color(1f, 0.5f, 0.5f, 1f);
            ModifierType = ModifierEnum.BigBoi;
        }
    }
}