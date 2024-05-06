using UnityEngine;
using Zenject;

namespace Infrastructure.Services.GameObjectsCreate
{
	public class GameObjectsCreateService : IGameObjectsCreateService
	{
		private readonly IInstantiator _instantiator;

		public GameObjectsCreateService(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public GameObject Instantiate(GameObject prefab) =>
			_instantiator.InstantiatePrefab(prefab);

		public GameObject Instantiate(GameObject prefab, Transform parentTransform) =>
			_instantiator.InstantiatePrefab(prefab, parentTransform);

	}
}