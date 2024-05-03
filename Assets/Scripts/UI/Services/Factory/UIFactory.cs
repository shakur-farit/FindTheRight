using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticEvents;
using UnityEngine;

namespace UI.Services.Factory
{
	public class UIFactory
	{
		private readonly Assets _assets;

		public Transform UIRoot { get; private set; }
		public GameObject GameCompleteWindow { get; private set; }

		public UIFactory(Assets assets) =>
			_assets = assets;

		public async UniTask WarmUp()
		{
			await _assets.Load<GameObject>(AssetsAddress.UIRootPath);
			await _assets.Load<GameObject>(AssetsAddress.GameCompleteWindowPath);
		}

		public async UniTask CreateUIRoot()
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.UIRootPath);
			UIRoot = _assets.Instantiate(prefab).transform;
			StaticEventsHandler.CallDebugUI($"Instant {UIRoot.GetInstanceID().ToString()}");
		}

		public async UniTask CreateGameCompleteWindow(Transform parentTransform)
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.GameCompleteWindowPath);
			GameCompleteWindow = _assets.Instantiate(prefab, parentTransform);
		}

		public void DestroyUIRoot()
		{
			StaticEventsHandler.CallDebugUI($"Destroy {UIRoot.GetInstanceID().ToString()}");
			Object.Destroy(UIRoot.gameObject);
		}

		public void DestroyGameCompleteWindow() => 
			Object.Destroy(GameCompleteWindow);
	}
}
