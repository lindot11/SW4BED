namespace ModelManagement.Hubs
{
	public interface IMessage
	{
		Task NewExpense(decimal expense);
	}
}
