namespace Bakalarska_prace_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Zaregistrujeme podporu pro API kontrolory
            builder.Services.AddControllers();
            builder.Services.AddSignalR();

            var app = builder.Build();

            app.MapControllers();


            Console.WriteLine("Server startuje podle konfigurace...");
            app.Run();
        }
    }
}