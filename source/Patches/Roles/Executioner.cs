using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Executioner : Role
    {
        public PlayerControl target;
        public bool TargetVotedOut;

        public Executioner(PlayerControl player) : base(player)
        {
            Name = "Executioner".Translate();
            ImpostorText = () =>
                target == null ? "ExecutionerStartGameText1".Translate() : $"{"ExecutionerStartGameTextVote".Translate()} {target.name} {"ExecutionerStartGameTextOut".Translate()}";
            TaskText = () =>
                target == null
                    ? "ExecutionerGameTaskText1".Translate()
                    : $"{"ExecutionerGameTaskTextVote".Translate()} {target.name} {"ExecutionerGameTaskTextOut".Translate()}";
            Color = new Color(0.55f, 0.25f, 0.02f, 1f);
            RoleType = RoleEnum.Executioner;
            Faction = Faction.Neutral;
            Scale = 1.4f;
        }

        protected override void IntroPrefix(IntroCutscene._CoBegin_d__14 __instance)
        {
            var executionerteam = new List<PlayerControl>();
            executionerteam.Add(PlayerControl.LocalPlayer);
            __instance.yourTeam = executionerteam;
        }

        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            if (Player.Data.IsDead) return true;
            if (!TargetVotedOut || !target.Data.IsDead) return true;
            Utils.EndGame();
            return false;
        }

        public void Wins()
        {
            if (Player.Data.IsDead || Player.Data.Disconnected) return;
            TargetVotedOut = true;
        }

        public void Loses()
        {
            Player.Data.IsImpostor = true;
        }
    }
}