using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private readonly Assets _assets;

		public StaticDataService(Assets assets) => 
			_assets = assets;

		private const string LevelsListPath = "Levels Static Data List";
		private const string ContentListPath = "Content Static Data List";

		public LevelStaticDataList ForLevels { get; private set; }
		public ContentStaticDataList ForContent { get; private set; }

		public async Task Load()
		{
			await WarmUp();

			ForLevels =  await _assets.Load<LevelStaticDataList>(LevelsListPath);
			ForContent = await _assets.Load<ContentStaticDataList>(ContentListPath);

			Debug.Log(ForLevels);
		}

		private async Task WarmUp()
		{
			await _assets.Load<LevelStaticDataList>(LevelsListPath);
			await _assets.Load<ContentStaticDataList>(ContentListPath);
		}
	}
}