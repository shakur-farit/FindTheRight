using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Infrastructure.AssetsManagement
{
	public class AssetsProvider
	{
		private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new Dictionary<string, AsyncOperationHandle>();
		private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

		public void Initialize() =>
			Addressables.InitializeAsync();

		public async UniTask<T> Load<T>(string addressReference) where T : class
		{
			if (_completedCache.TryGetValue(addressReference, out AsyncOperationHandle completedHandle))
				return completedHandle.Result as T;

			var completionSource = new UniTaskCompletionSource<T>();

			AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(addressReference);
			handle.Completed += h =>
			{
				_completedCache[addressReference] = h;
				completionSource.TrySetResult(h.Result);
			};

			AddHandle(addressReference, handle);

			return await completionSource.Task;
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