using Microsoft.AspNetCore.SignalR;

namespace ModelManagement.Hubs
{
	public class MessageHub : Hub<IMessage>
	{
		public async Task NewExpense(string expense)
		{
			await Clients.All.NewExpense(expense);
		}
	}
}
