using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class Drunk : Modifier
    {
        public Drunk(PlayerControl player) : base(player)
        {
            Name = "Drunk".Translate();
            TaskText = () => "DrunkInfo".Translate();
            Color = new Color(0.46f, 0.5f, 0f, 1f);
            ModifierType = ModifierEnum.Drunk;
        }
    }
}