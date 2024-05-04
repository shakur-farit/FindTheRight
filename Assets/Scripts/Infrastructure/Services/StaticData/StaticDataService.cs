using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticData;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private readonly AssetsProvider _assetsProvider;

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		private const string LevelsListPath = "Levels Static Data List";
		private const string ContentListPath = "Content Static Data List";

		public LevelStaticDataList ForLevels { get; private set; }
		public ContentStaticDataList ForContent { get; private set; }

		public async UniTask Load()
		{
			await WarmUp();

			ForLevels =  await _assetsProvider.Load<LevelStaticDataList>(LevelsListPath);
			ForContent = await _assetsProvider.Load<ContentStaticDataList>(ContentListPath);
		}

		private async UniTask WarmUp()
		{
			await _assetsProvider.Load<LevelStaticDataList>(LevelsListPath);
			await _assetsProvider.Load<ContentStaticDataList>(ContentListPath);
		}
	}
}