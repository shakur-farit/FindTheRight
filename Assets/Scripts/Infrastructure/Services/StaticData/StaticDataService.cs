using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticData;
using StaticData.Animation;
using UnityEditor.PackageManager.UI;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string LevelsListPath = "Levels Static Data List";
		private const string ContentListPath = "Content Static Data List";

		private const string ContentBounceAnimationPath = "Content Bounce Animation Static Data";
		private const string ContentShakeAnimationPath = "Content Shake Animation Static Data";

		private const string GridBounceAnimationPath = "Grid Bounce Animation Static Data";

		private const string RestartButtonRotateAnimation = "Restart Button Rotate Animation Static Data";

		private const string GameCompleteWindowFadeInAnimationPath = "Complete Window Fade In Animation Static Data";
		private const string GameCompleteWindowFadeOutAnimationPath = "Complete Window Fade Out Animation Static Data";

		private readonly AssetsProvider _assetsProvider;

		public LevelStaticDataList ForLevels { get; private set; }
		public ContentStaticDataList ForContent { get; private set; }

		public BounceAnimationStaticData ForContentBounceAnimation { get; private set; }
		public ShakeAnimationStaticData ForContentShakeAnimation { get; private set; }

		public BounceAnimationStaticData ForGridBounceAnimation { get; private set; }

		public RotateAnimationStaticData ForRestartButtonRotateAnimation { get; private set; }

		public FadeInOutAnimationStaticData ForGameCompleteWindowFadeInAnimation { get; private set; }
		public FadeInOutAnimationStaticData ForGameCompleteWindowFadeOutAnimation { get; private set; }

		public StaticDataService(AssetsProvider assetsProvider) => 
			_assetsProvider = assetsProvider;

		public async UniTask Load()
		{
			await WarmUp();

			ForLevels =  await _assetsProvider.Load<LevelStaticDataList>(LevelsListPath);
			ForContent = await _assetsProvider.Load<ContentStaticDataList>(ContentListPath);
			
			ForContentBounceAnimation = await _assetsProvider.Load<BounceAnimationStaticData>(ContentBounceAnimationPath);
			ForContentShakeAnimation = await _assetsProvider.Load<ShakeAnimationStaticData>(ContentShakeAnimationPath);

			ForGridBounceAnimation = await _assetsProvider.Load<BounceAnimationStaticData>(GridBounceAnimationPath);

			ForRestartButtonRotateAnimation = await _assetsProvider.Load<RotateAnimationStaticData>(RestartButtonRotateAnimation);

			ForGameCompleteWindowFadeInAnimation = 
				await _assetsProvider.Load<FadeInOutAnimationStaticData>(GameCompleteWindowFadeInAnimationPath);
			ForGameCompleteWindowFadeOutAnimation = 
				await _assetsProvider.Load<FadeInOutAnimationStaticData>(GameCompleteWindowFadeOutAnimationPath);
		}

		private async UniTask WarmUp()
		{
			await _assetsProvider.Load<LevelStaticDataList>(LevelsListPath);
			await _assetsProvider.Load<ContentStaticDataList>(ContentListPath);
			
			await _assetsProvider.Load<BounceAnimationStaticData>(ContentBounceAnimationPath);
			await _assetsProvider.Load<ShakeAnimationStaticData>(ContentShakeAnimationPath);

			await _assetsProvider.Load<BounceAnimationStaticData>(GridBounceAnimationPath);

			await _assetsProvider.Load<RotateAnimationStaticData>(RestartButtonRotateAnimation);

			await _assetsProvider.Load<FadeInOutAnimationStaticData>(GameCompleteWindowFadeInAnimationPath);
			await _assetsProvider.Load<FadeInOutAnimationStaticData>(GameCompleteWindowFadeOutAnimationPath);
		}
	}
}