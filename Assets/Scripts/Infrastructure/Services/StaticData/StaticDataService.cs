using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticData;

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

		public async UniTask Load()
		{
			await WarmUp();

			ForLevels =  await _assets.Load<LevelStaticDataList>(LevelsListPath);
			ForContent = await _assets.Load<ContentStaticDataList>(ContentListPath);
		}

		private async UniTask WarmUp()
		{
			await _assets.Load<LevelStaticDataList>(LevelsListPath);
			await _assets.Load<ContentStaticDataList>(ContentListPath);
		}
	}
}