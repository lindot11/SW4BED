namespace ModelManagement.Hubs
{
	public interface IMessage
	{
		Task NewExpense(string expense);
	}
}
