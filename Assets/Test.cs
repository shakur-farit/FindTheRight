using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using StaticData;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Zenject;

public class Test : MonoBehaviour
{
	private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new Dictionary<string, AsyncOperationHandle>();
	private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

	private string levels = "Levels Static Data List";
	private string content = "Content Static Data List";

	private async void Start()
	{
		await Instantiate<ContentStaticDataList>(content);

		ContentStaticDataList prefab = await Instantiate<ContentStaticDataList>(content);


		Debug.Log(prefab.ContentList.Count);
	}

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
