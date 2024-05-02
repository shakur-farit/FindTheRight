using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory
	{
		private readonly Assets _assets;

		public Transform GridParent { get; private set; }
		public GameObject Grid { get; private set; }
		public GameObject Cell { get; private set; }
		public GameObject Content { get; private set; }
		public GameObject Hud { get; private set; }
		public GameObject ClickDetector { get; private set; }

		public GameFactory(Assets assets) => 
			_assets = assets;

		public async UniTask WarmUp()
		{
			await _assets.Load<GameObject>(AssetsAddress.GridParentPath);
			await _assets.Load<GameObject>(AssetsAddress.GridPath);
			await _assets.Load<GameObject>(AssetsAddress.CellPath);
			await _assets.Load<GameObject>(AssetsAddress.ContentPath);
			await _assets.Load<GameObject>(AssetsAddress.HudPath);
			await _assets.Load<GameObject>(AssetsAddress.DetectorPath);
		}
		public async UniTask CreateGridParent()
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.GridParentPath);
			GridParent = _assets.Instantiate(prefab).transform;
		}

		public async UniTask CreateGrid()
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.GridPath);
			Grid = _assets.Instantiate(prefab);
		}

		public async UniTask<GameObject> CreateCell(Transform parentTransform)
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.CellPath);
			return Cell = _assets.Instantiate(prefab, parentTransform);
		}

		public async UniTask<GameObject> CreateContent(Transform parentTransform)
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.ContentPath);
			return Content = _assets.Instantiate(prefab, parentTransform);
		}

		public async UniTask CreateHud()
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.HudPath);
			Hud = _assets.Instantiate(prefab);
		}

		public async UniTask CreateClickDetector()
		{
			GameObject prefab = await _assets.Load<GameObject>(AssetsAddress.DetectorPath);
			ClickDetector = _assets.Instantiate(prefab);
		}

		public void DestroyGridParent() =>
			Object.Destroy(GridParent.gameObject);

		public void DestroyHud() =>
			Object.Destroy(Hud);

		public void DestroyClickDetector() => 
			Object.Destroy(ClickDetector);
	}
}