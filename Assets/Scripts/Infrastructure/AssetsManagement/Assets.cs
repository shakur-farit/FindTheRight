using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Infrastructure.AssetsManagement
{
	public class Assets
	{
		private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new Dictionary<string, AsyncOperationHandle>();
		private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

		private readonly DiContainer _diContainer;

		public Assets(DiContainer diContainer) => 
			_diContainer = diContainer;

		public void Initialize() => 
			Addressables.InitializeAsync();

		public GameObject Instantiate(GameObject prefab) => 
			_diContainer.InstantiatePrefab(prefab);

		public GameObject Instantiate(GameObject prefab, Transform parentTransform) => 
			_diContainer.InstantiatePrefab(prefab, parentTransform);

		public async Task<T> Instantiate<T>(string addressReference) where T : class
		{
			if (_completedCache.TryGetValue(addressReference, out AsyncOperationHandle completedHandle))
				return completedHandle.Result as T;

			AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(addressReference);

			handle.Completed += h => 
				_completedCache[addressReference] = h;

			AddHandle(addressReference, handle);

			return await handle.Task;
		}

		public void CleanUp()
		{
			foreach (List<AsyncOperationHandle> resourcesHandles in _handles.Values)
				foreach (AsyncOperationHandle handle in resourcesHandles) 
					Addressables.Release(handle);

			_completedCache.Clear();
			_handles.Clear();
		}

		private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
		{
			if (_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles) == false)
			{
				resourceHandles = new List<AsyncOperationHandle>();
				_handles[key] = resourceHandles;
			}

			resourceHandles.Add(handle);
		}
	}
}