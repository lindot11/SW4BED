using Assignment_4_HearthStoneAPI.Models;
using Assignment_4_HearthStoneAPI.Services;


namespace Assignment_4_HearthStoneAPI
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			// Add services to the container.
			builder.Services.Configure<MongodbHearthStoneSettings>(
				builder.Configuration.GetSection("MongoDbDatabase"));

			builder.Services.AddTransient<MongoService>();
			builder.Services.AddTransient<HearthStoneService>();
			
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.MapControllers();

			app.Run();
		}
	}
}