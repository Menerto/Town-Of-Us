using UnityEngine;

namespace TownOfUs.Roles
{
	public class Altruist : Role
	{
		public bool CurrentlyReviving;
		public DeadBody CurrentTarget;

		public bool ReviveUsed;

		public Altruist(PlayerControl player) : base(player)
		{
			Name = "Altruist".Translate();
			ImpostorText = () => "AltruistStartGameText".Translate();
			TaskText = () => "AltruistGameTaskText".Translate();
			Color = new Color(0.4f, 0f, 0f, 1f);
			RoleType = RoleEnum.Altruist;
		}
	}
}