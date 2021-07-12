using System;
using System.Collections.Generic;
using System.IO;

namespace TownOfUs
{
	public class Language
	{
		public string Name;
		public Language(string name) => Name = name;

		public static Language English = new Language(nameof(English));
		public static Language Polish = new Language(nameof(Polish));

		public static readonly Language Default = English;
		public static Language Current = Default;

		public static List<Language> List = new List<Language>{ English, Polish };
		public static readonly string Location = Path.Combine
		(
			Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
			@"AppData\LocalLow\Innersloth\Among Us\language"
		);

		public static Language Load()
		{
			if (!File.Exists(Location)) {
				Save(Default);
				goto spare;
			}

			var languageText = File.ReadAllText(Location);
			foreach (var language in List) {
				if (language.Name == languageText)
					return language;
			}

		spare:
			return Default;
		}

		public static void Set(Language language)
		{
			Current = language;
			Save(language);
		}

		public static void Save(Language language)
		{
			if (!File.Exists(Location))
				File.Create(Location).Dispose();

			File.WriteAllText(Location, language.Name);
		}
	}

	public static partial class LanguageExtensions
	{
		public static string Translate(this string key)
		{
			Language.Current = Language.Load();
			return Language.Current.Name switch {
				nameof(Language.English) => Patches.Locale.English.Translations.TryGetValue(key, out var value) ? value : key.ToString(),
				nameof(Language.Polish) => Patches.Locale.Polish.Translations.TryGetValue(key, out var value) ? value : key.ToString(),
				_ => key.ToString(),
			};
		}
	}
}