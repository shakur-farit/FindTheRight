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
			StaticEventsHandler.CallDebugUI("GetInstant");
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.UIRootPath);
			UIRoot = _assets.Instantiate(prefab).transform;
			StaticEventsHandler.CallDebugUI($"Instant {UIRoot.GetInstanceID()}");
		}

		public async UniTask CreateGameCompleteWindow(Transform parentTransform)
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.GameCompleteWindowPath);
			GameCompleteWindow = _assets.Instantiate(prefab, parentTransform);
		}

		public void DestroyUIRoot()
		{
			Object.Destroy(UIRoot.gameObject);
			StaticEventsHandler.CallDebugUI($"Destroy {UIRoot.GetInstanceID()}");
		}

		public void DestroyGameCompleteWindow() => 
			Object.Destroy(GameCompleteWindow);
	}
}
