using Events;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class Hud : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _searchIntentText;

		private PersistentProgressService _persistentProgressService;
		private ISearchIntentChangeEvent _searchIntentChangeEvent;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService,
			ISearchIntentChangeEvent searchIntentChangeEvent)
		{
			_persistentProgressService = persistentProgressService;
			_searchIntentChangeEvent = searchIntentChangeEvent;
		}

		private void OnEnable() => 
			_searchIntentChangeEvent.SearchIntentChanged += UpdateSearchIntentText;

		private void OnDestroy() => 
			_searchIntentChangeEvent.SearchIntentChanged -= UpdateSearchIntentText;

		private void UpdateSearchIntentText() => 
			_searchIntentText.text = _persistentProgressService.Progress.SearchIntentData.SearchIntent;
	}
}
