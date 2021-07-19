using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Assassin : Role
    {
        public Dictionary<byte, (GameObject, GameObject)> Buttons = new Dictionary<byte, (GameObject, GameObject)>();


        public Dictionary<string, Color> ColorMapping = new Dictionary<string, Color>
        {
            { "Mayor".Translate(), new Color(0.44f, 0.31f, 0.66f, 1f) },
            { "Sheriff".Translate(), Color.yellow },
            { "Engineer".Translate(), new Color(1f, 0.65f, 0.04f, 1f) },
            { "Swapper".Translate(), new Color(0.4f, 0.9f, 0.4f, 1f) },
            { "Investigator".Translate(), new Color(0f, 0.7f, 0.7f, 1f) },
            { "Time Lord".Translate(), new Color(0f, 0f, 1f, 1f) },
            { "Lover".Translate(), new Color(1f, 0.4f, 0.8f, 1f) },
            { "Medic".Translate(), new Color(0f, 0.4f, 0f, 1f) },
            { "Seer".Translate(), new Color(1f, 0.8f, 0.5f, 1f) },
            { "Spy".Translate(), new Color(0.8f, 0.64f, 0.8f, 1f) },
            { "Child".Translate(), Color.white },
            { "Snitch".Translate(), new Color(0.83f, 0.69f, 0.22f, 1f) },
            { "Altruist".Translate(), new Color(0.4f, 0f, 0f, 1f) }
        };

        public Dictionary<byte, string> Guesses = new Dictionary<byte, string>();


        public Assassin(PlayerControl player) : base(player)
        {
            Name = "Assassin".Translate();
            ImpostorText = () => "AssassinStartGameText".Translate();
            TaskText = () => "AssassinGameTaskText".Translate();
            Color = Palette.ImpostorRed;
            RoleType = RoleEnum.Assassin;
            Faction = Faction.Impostors;

            RemainingKills = CustomGameOptions.AssassinKills;

            if (CustomGameOptions.AssassinGuessNeutrals)
            {
                ColorMapping.Add("Jester".Translate(), new Color(1f, 0.75f, 0.8f, 1f));
                ColorMapping.Add("Shifter".Translate(), new Color(0.6f, 0.6f, 0.6f, 1f));
                ColorMapping.Add("Executioner".Translate(), new Color(0.55f, 0.25f, 0.02f, 1f));
                ColorMapping.Add("The Glitch".Translate(), Color.green);
                ColorMapping.Add("Arsonist".Translate(), new Color(1f, 0.3f, 0f));
            }

            if (CustomGameOptions.AssassinCrewmateGuess) ColorMapping.Add("Crewmate", Color.white);
        }

        public bool GuessedThisMeeting { get; set; } = false;

        public int RemainingKills { get; set; }

        public List<string> PossibleGuesses => ColorMapping.Keys.ToList();
    }
}
