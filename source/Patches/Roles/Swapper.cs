using System.Collections.Generic;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Swapper : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();


        public Swapper(PlayerControl player) : base(player)
        {
            Name = "Swapper".Translate();
            ImpostorText = () => "SwapperStartGameText".Translate();
            TaskText = () => "SwapperGameTaskText".Translate();
            Color = new Color(0.4f, 0.9f, 0.4f, 1f);
            RoleType = RoleEnum.Swapper;
        }
    }
}