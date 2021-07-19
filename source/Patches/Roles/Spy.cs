using UnityEngine;

namespace TownOfUs.Roles
{
    public class Spy : Role
    {
        public Spy(PlayerControl player) : base(player)
        {
            Name = "Spy".Translate();
            ImpostorText = () => "SpyStartGameText".Translate();
            TaskText = () => "SpyGameTaskText".Translate();
            Color = new Color(0.8f, 0.64f, 0.8f, 1f);
            RoleType = RoleEnum.Spy;
        }
    }
}