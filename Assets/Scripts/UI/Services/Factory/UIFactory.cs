using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticEvents;
using UnityEngine;

namespace UI.Services.Factory
{
	public class UIFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private AssetsReference _reference;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public Transform UIRoot { get; private set; }
		public GameObject GameCompleteWindow { get; private set; }

		public UIFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;

			LoadAssetsReference();
		}

		public async UniTask CreateUIRoot()
		{
			StaticEventsHandler.CallDebugUI("GetInstant");
			
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.UIRootAddress);
			UIRoot = _gameObjectsCreateService.Instantiate(prefab).transform;
			StaticEventsHandler.CallDebugUI($"Instant {UIRoot.GetInstanceID()}");
		}

		public async UniTask CreateGameCompleteWindow(Transform parentTransform)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.GameCompleteWindowAddress);
			GameCompleteWindow = _gameObjectsCreateService.Instantiate(prefab, parentTransform);
		}

		public void DestroyUIRoot()
		{
			Object.Destroy(UIRoot.gameObject);
			StaticEventsHandler.CallDebugUI($"Destroy {UIRoot.GetInstanceID()}");
		}

		public void DestroyGameCompleteWindow() => 
			Object.Destroy(GameCompleteWindow);

		private async void LoadAssetsReference() => 
			_reference = await _assetsProvider.Load<AssetsReference>(AssetsAddress.AssetsReferenceAddress);
	}
}
