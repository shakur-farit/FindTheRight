using System;
using Infrastructure.Services.PersistentProgress;
using StaticEvents;
using TMPro;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class Hud : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _searchIntentText;
		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void OnEnable() => 
			StaticEventsHandler.OnSearchIntentChanged += UpdateSearchIntentText;

		private void OnDestroy() => 
			StaticEventsHandler.OnSearchIntentChanged -= UpdateSearchIntentText;

		private void UpdateSearchIntentText() => 
			_searchIntentText.text = _persistentProgressService.Progress.SearchIntentData.SearchIntent;
	}
}
