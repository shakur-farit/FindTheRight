using UnityEngine;

namespace Infrastructure.AssetsManagement
{
	public interface IGameObjectsCreateService
	{
		GameObject Instantiate(GameObject prefab);
		GameObject Instantiate(GameObject prefab, Transform parentTransform);
	}
}