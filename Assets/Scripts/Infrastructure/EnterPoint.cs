using Infrastructure.States.Factory;
using Infrastructure.States.Game;
using Infrastructure.States.LevelDifficultly;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private GameStateMachine _gameStateMachine;
		private IStatesFactory _statesFactory;
		private LevelStateMachine _levelStateMachine;


		[Inject]
		public void Constructor(GameStateMachine gameStateMachine, LevelStateMachine levelStateMachine, IStatesFactory statesFactory)
		{
			_gameStateMachine = gameStateMachine;
			_statesFactory = statesFactory;
			_levelStateMachine = levelStateMachine;
		}

		private void Awake()
		{
			RegisterStates();
			EnterInLoadStaticDataState();

			DontDestroyOnLoad(this);
		}

		private void RegisterStates()
		{
			RegisterGameStates();

			RegisterLevelStates();
		}

		private void RegisterGameStates()
		{
			_gameStateMachine.RegisterState(_statesFactory.Create<WarmUpState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadStaticDataState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<LoadSceneState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<MainMenuState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<GamePlayLoopState>());
			_gameStateMachine.RegisterState(_statesFactory.Create<GameCompleteState>());
		}

		private void RegisterLevelStates()
		{
			_levelStateMachine.RegisterState(_statesFactory.Create<EasyLevelState>());
			_levelStateMachine.RegisterState(_statesFactory.Create<MediumLevelState>());
			_levelStateMachine.RegisterState(_statesFactory.Create<HardLevelState>());
		}

		private void EnterInLoadStaticDataState() =>
			_gameStateMachine.Enter<LoadStaticDataState>();
	}
}

