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

		public GameFactory(Assets assets) => 
			_assets = assets;

		public void CreateGrid() => 
			Grid = _assets.Instantiate(AssetsPath.GridPath);

		public GameObject CreateCell(Transform transform) => 
			Cell = _assets.Instantiate(AssetsPath.CellPath, transform);
	}
}