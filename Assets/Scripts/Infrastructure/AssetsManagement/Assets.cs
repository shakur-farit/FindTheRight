using System;
using System.Collections.Generic;
using CellGrid;
using UnityEngine;
using Zenject;

namespace Infrastructure.AssetsManagement
{
	public class Assets
	{
		private readonly DiContainer _diContainer;

		public Assets(DiContainer diContainer) => 
			_diContainer = diContainer;

		public GameObject Instantiate(string path) => 
			_diContainer.InstantiatePrefabResource(path);

		public GameObject Instantiate(string path, Transform parentTransform) => 
			_diContainer.InstantiatePrefabResource(path, parentTransform);
	}
}