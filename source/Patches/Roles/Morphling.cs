﻿using System;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Morphling : Role

    {
        public KillButtonManager _morphButton;
        public PlayerControl ClosestPlayer;
        public DateTime LastMorphed;
        public PlayerControl MorphedPlayer;

        public PlayerControl SampledPlayer;
        public float TimeRemaining;

        public Morphling(PlayerControl player) : base(player)
        {
            Name = "Morphling".Translate();
            ImpostorText = () => "MorphlingStartGameText".Translate();
            TaskText = () => "MorphlingGameTaskText".Translate();
            Color = Palette.ImpostorRed;
            RoleType = RoleEnum.Morphling;
            Faction = Faction.Impostors;
        }

        public KillButtonManager MorphButton
        {
            get => _morphButton;
            set
            {
                _morphButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public bool Morphed => TimeRemaining > 0f;


        public void Morph()
        {
            TimeRemaining -= Time.deltaTime;
            Utils.Morph(Player, MorphedPlayer);
        }

        public void Unmorph()
        {
            MorphedPlayer = null;
            Utils.Unmorph(Player);
            LastMorphed = DateTime.UtcNow;
        }


        public float MorphTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastMorphed;
            var num = CustomGameOptions.MorphlingCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}
