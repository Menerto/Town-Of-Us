using UnityEngine;

namespace TownOfUs.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer".Translate();
            ImpostorText = () => "EngineerStartGameText".Translate();
            TaskText = () => "EngineerGameTaskText".Translate();
            Color = new Color(1f, 0.65f, 0.04f, 1f);
            RoleType = RoleEnum.Engineer;
        }

        public bool UsedThisRound { get; set; } = false;
    }
}