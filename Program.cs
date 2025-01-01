namespace WeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            // MainAsync().Wait();
            static async Task MainAsync()
            {
                // await stuff here
                await WeatherApi.ApiFunctionAsync();
            }
        }
    }
}
