using Microsoft.AspNetCore.SignalR;

namespace ModelManagement.Hubs
{
	public class MessageHub : Hub<IMessage>
	{
		public async Task NewExpense(decimal expense)
		{
			await Clients.All.NewExpense(expense);
		}
	}
}
