using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class Diseased : Modifier
    {
        public Diseased(PlayerControl player) : base(player)
        {
            Name = "Diseased".Translate();
            TaskText = () => "DiseasedInfo".Translate();
            Color = Color.grey;
            ModifierType = ModifierEnum.Diseased;
        }
    }
}