namespace Infrastructure.States
{
	public interface IExitable : IState
	{
		void Exit();
	}
}