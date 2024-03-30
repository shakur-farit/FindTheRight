using System.Threading.Tasks;
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

		public async Task WarmUp()
		{
			await _assets.Load<GameObject>(AssetsAddress.UIRootPath);
			await _assets.Load<GameObject>(AssetsAddress.GameCompleteWindowPath);
			await _assets.Load<GameObject>(AssetsAddress.LoadingWindowPath);
		}

		public async Task CreateUIRoot()
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.UIRootPath);
			UIRoot = _assets.Instantiate(prefab).transform;
		}

		public async Task CreateGameCompleteWindow(Transform parentTransform)
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.GameCompleteWindowPath);
			_assets.Instantiate(prefab, parentTransform);
		}

		public async Task CreateLoadingWindow(Transform parentTransform)
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.LoadingWindowPath);
			_assets.Instantiate(prefab, parentTransform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(UIRoot.gameObject);
	}
}
