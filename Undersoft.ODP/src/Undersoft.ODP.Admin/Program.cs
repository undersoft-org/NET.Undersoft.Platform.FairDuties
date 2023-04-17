using UltimatR;

namespace Undersoft.ODP.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddHttpClient();
            builder.Services.AddBootstrapBlazor();
            builder.Services.AddServiceSetup()
                     .ConfigureServices(false);


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

            app.UseAppSetup(app.Environment, false)
                .UseExternalProvider()
                .UseDataClients();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.UseBootstrapBlazor();

            app.Run();
        }
    }
}