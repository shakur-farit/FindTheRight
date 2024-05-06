using UnityEngine;

namespace Infrastructure.Services.GameObjectsCreate
{
	public interface IGameObjectsCreateService
	{
		GameObject Instantiate(GameObject prefab);
		GameObject Instantiate(GameObject prefab, Transform parentTransform);
	}
}