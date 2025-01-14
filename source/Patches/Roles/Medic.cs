﻿using UnityEngine;

namespace TownOfUs.Roles
{
    public class Medic : Role
    {
        public Medic(PlayerControl player) : base(player)
        {
            Name = "Medic".Translate();
            ImpostorText = () => "MedicStartGameText".Translate();
            TaskText = () => "MedicGameTaskText".Translate();
            Color = new Color(0f, 0.4f, 0f, 1f);
            RoleType = RoleEnum.Medic;
            ShieldedPlayer = null;
        }

        public PlayerControl ClosestPlayer;
        public bool UsedAbility { get; set; } = false;
        public PlayerControl ShieldedPlayer { get; set; }
        public PlayerControl exShielded { get; set; }
    }
}
