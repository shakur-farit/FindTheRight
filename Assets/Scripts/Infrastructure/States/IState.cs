namespace Infrastructure.States
{
	public interface IState
	{
		void Enter();
	}

	public interface IExitable : IState
	{
		void Exit();
	}
}