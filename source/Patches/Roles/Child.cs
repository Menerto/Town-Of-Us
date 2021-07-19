using UnityEngine;

namespace TownOfUs.Roles
{
    public class Child : Role
    {
        public bool Dead;

        public Child(PlayerControl player) : base(player)
        {
            Name = "Child".Translate();
            ImpostorText = () => "ChildStartGameText".Translate();
            TaskText = () => "ChildGameTaskText".Translate();
            Color = Color.white;
            RoleType = RoleEnum.Child;
        }

        public void Wins()
        {
            Dead = true;
        }

        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            //System.Console.WriteLine("REACHES HERE2.75");
            if (!Dead) return true;
            //System.Console.WriteLine("REACHES HERE3");
            if (!Player.Data.IsDead) return false;
            //System.Console.WriteLine("REACHES HERE4");
            Utils.EndGame();
            return false;
        }
    }
}