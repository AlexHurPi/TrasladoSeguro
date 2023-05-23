using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;

namespace SupermarketWEB
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			//Agregando el contexto SupermarketContext a la aplicacion
			builder.Services.AddDbContext<TransporteSeguroContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("TransporteSeguroDB"))
			);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}