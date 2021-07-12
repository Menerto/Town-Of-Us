using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace TownOfUs
{
	[HarmonyPatch(typeof(OptionsMenuBehaviour), nameof(OptionsMenuBehaviour.Start))]
	public class OptionsMenuBehaviour_Start
	{
		public static Vector3? origin;
		public static readonly float xOffset = 1.75f;
		public static readonly float yOffset = -0.5f;
		public static readonly Color colorCurrent = new Color(0f, 1f, 0.16470589f, 1f);
		public static readonly Color colorNotCurrent = Color.white;

		public static ToggleButtonBehaviour englishButton;
		public static ToggleButtonBehaviour polishButton;

		public static void Postfix(OptionsMenuBehaviour __instance)
		{
			if (__instance.CensorChatButton == null)
				return;

			origin ??= __instance.CensorChatButton.transform.localPosition + Vector3.up * 0.25f;
			__instance.CensorChatButton.transform.localPosition = origin.Value + Vector3.left * xOffset;
			__instance.CensorChatButton.transform.localScale = Vector3.one * 2f / 3f;

			englishButton = createButton(Language.English, Vector3.zero, (UnityEngine.Events.UnityAction) englishButtonToggle, __instance);
			polishButton = createButton(Language.Polish, Vector3.right * xOffset, (UnityEngine.Events.UnityAction) polishButtonToggle, __instance);

			void englishButtonToggle() => setLanguage(Language.English);
			void polishButtonToggle() => setLanguage(Language.Polish);

			Language.Current = Language.Load();
			updateButtons();
		}

		private static void setLanguage(Language language)
		{
			Language.Set(language);
			updateButtons();
		}

		private static ToggleButtonBehaviour createButton
		(
			Language language,
			Vector3 offset,
			UnityEngine.Events.UnityAction onClick,
			OptionsMenuBehaviour __instance
		)
		{
			var button = UnityEngine.Object.Instantiate(__instance.CensorChatButton, __instance.CensorChatButton.transform.parent);
			button.transform.localPosition = (origin ?? Vector3.zero) + offset;
			button.Text.text = language.Name;

			var passiveButton = button.GetComponent<PassiveButton>();
			passiveButton.OnClick = new Button.ButtonClickedEvent();
			passiveButton.OnClick.AddListener(onClick);

			return button;
		}

		private static void updateButtons()
		{
			foreach (var language in Language.List) {
				var current = language.Name == Language.Current.Name;
				var color = current ? colorCurrent : colorNotCurrent;
				var button = language.Name switch {
					nameof(Language.English) => englishButton,
					nameof(Language.Polish) => polishButton,
					_ => throw new NotImplementedException(),
				};

				if (button?.gameObject is null)
					continue;

				button.Background.color = color;
				button.Text.text = language.Name + ": " + (current ? "on" : "off");
				button.Rollover?.ChangeOutColor(color);
			}
		}
	}
}