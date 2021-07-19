using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class Tiebreaker : Modifier
    {
        public Tiebreaker(PlayerControl player) : base(player)
        {
            Name = "Tiebreaker".Translate();
            TaskText = () => "TiebreakerInfo".Translate();
            Color = new Color(0.6f, 0.9f, 0.6f);
            ModifierType = ModifierEnum.Tiebreaker;
        }
    }
}