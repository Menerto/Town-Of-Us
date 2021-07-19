using UnityEngine;

namespace TownOfUs.Roles.Modifiers
{
    public class ButtonBarry : Modifier
    {
        public KillButtonManager ButtonButton;

        public bool ButtonUsed;

        public ButtonBarry(PlayerControl player) : base(player)
        {
            Name = "ButtonBarry".Translate();
            TaskText = () => "ButtonBarryInfo".Translate();
            Color = new Color(0.9f, 0f, 1f, 1f);
            ModifierType = ModifierEnum.ButtonBarry;
        }
    }
}