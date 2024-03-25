using Data;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
	public class SaveLoadService : ILoadService, ISaveService
	{
		public const string ProgressKey = "Progress";

		private readonly PersistentProgressService.PersistentProgressService _progressService;

		public SaveLoadService(PersistentProgressService.PersistentProgressService progressService) =>
			_progressService = progressService;

		public void SaveProgress() =>
			PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());

		public Progress LoadProgress()
		{
			if (PlayerPrefs.HasKey(ProgressKey))

				return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<Progress>();

			return default;
		}
	}
}