namespace Infrastructure.States.Game
{
	public interface IStatesFactory
	{
		TState Create<TState>() where TState : IState;
	}
}