using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory
	{
		private readonly Assets _assets;

		public GameObject Grid { get; private set; }
		public GameObject Cell { get; private set; }
		public GameObject Content { get; private set; }
		public GameObject Hud { get; private set; }
		public GameObject ClickDetector { get; private set; }

		public GameFactory(Assets assets) => 
			_assets = assets;

		public async Task WarmUp()
		{
			await _assets.Instantiate<GameObject>(AssetsAddress.GridPath);
			await _assets.Instantiate<GameObject>(AssetsAddress.CellPath);
			await _assets.Instantiate<GameObject>(AssetsAddress.ContentPath);
			await _assets.Instantiate<GameObject>(AssetsAddress.HudPath);
			await _assets.Instantiate<GameObject>(AssetsAddress.DetectorPath);
		}

		public async Task CreateGrid()
		{
			GameObject prefab = await _assets.Instantiate<GameObject>(AssetsAddress.GridPath);
			Grid = _assets.Instantiate(prefab);
			Debug.Log("CreatG");
		}

		public async Task<GameObject> CreateCell(Transform parentTransform)
		{
			GameObject prefab = await _assets.Instantiate<GameObject>(AssetsAddress.CellPath);
			return Cell = _assets.Instantiate(prefab, parentTransform);
		}

		public async Task<GameObject> CreateContent(Transform parentTransform)
		{
			GameObject prefab = await _assets.Instantiate<GameObject>(AssetsAddress.ContentPath);
			return Content = _assets.Instantiate(prefab, parentTransform);
		}

		public async Task CreateHud()
		{
			GameObject prefab = await _assets.Instantiate<GameObject>(AssetsAddress.HudPath);
			Hud = _assets.Instantiate(prefab);
			Debug.Log("CreatH");
		}

		public async Task CreateClickDetector()
		{
			GameObject prefab = await _assets.Instantiate<GameObject>(AssetsAddress.DetectorPath);
			ClickDetector = _assets.Instantiate(prefab);
		}

		public void DestroyGrid() => 
			Object.Destroy(Grid);

		public void DestroyHud() =>
			Object.Destroy(Hud);

		public void DestroyClickDetector() => 
			Object.Destroy(ClickDetector);
	}
}