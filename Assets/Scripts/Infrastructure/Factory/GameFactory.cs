using CellGrid;
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

		public GameFactory(Assets assets) => 
			_assets = assets;

		public void CreateGrid() => 
			Grid = _assets.Instantiate(AssetsPath.GridPath);

		public GameObject CreateCell(Transform parentTransform) => 
			Cell = _assets.Instantiate(AssetsPath.CellPath, parentTransform);

		public void CreateContent(GameObject prefab, Transform parentTransform) => 
			Content = _assets.Instantiate(prefab, parentTransform);

		public void CreateHud() => 
			Hud = _assets.Instantiate(AssetsPath.Hud);

		public void DestroyGrid() => 
			Object.Destroy(Grid);

		public void DestroyHud() =>
			Object.Destroy(Hud);
	}
}