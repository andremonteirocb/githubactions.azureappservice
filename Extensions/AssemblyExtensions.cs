using System.Reflection;

namespace GithubActions.AzureAppService.Extensions
{
    public static class AssemblyExtensions
    {
        public static Assembly entryAssembly = Assembly.GetExecutingAssembly();
        public static void AddMapDefault(this WebApplication app)
        {
            app.MapControllers();
            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync($"Container ({DateTime.Now}) - Update: {new FileInfo(entryAssembly.Location).LastWriteTime}");
            });
        }
    }
}
