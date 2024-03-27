using Infrastructure.AssetsManagement;
using UnityEngine;

namespace UI.Services.Factory
{
	public class UIFactory
	{
		private readonly Assets _assets;

		public Transform UIRoot { get; private set; }

		public UIFactory(Assets assets) =>
			_assets = assets;

		public void CreateUIRoot() =>
			UIRoot = _assets.Instantiate(AssetsPath.UIRootPath).transform;

		public void CreateGameCompleteWindow(Transform parentTransform) =>
			_assets.Instantiate(AssetsPath.GameCompleteWindowPath, parentTransform);

		public void CreateLoadingWindow(Transform parentTransform) => 
			_assets.Instantiate(AssetsPath.LoadingWindowPath, parentTransform);

		public void DestroyUIRoot() => 
			Object.Destroy(UIRoot.gameObject);
	}
}
