using System.Text.Json;

namespace ApiJsonParsingDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://nameday.abalin.net/api/V1/today?timezone=Europe/Stockholm";

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    NamedayWrapper? result = JsonSerializer.Deserialize<NamedayWrapper>(jsonResponse);

                    await Console.Out.WriteLineAsync($"Namedays for {result.Day}/{result.Month}");
                    foreach (var pair in result.Nameday)
                    {
                        await Console.Out.WriteLineAsync($"{pair.Key}: {pair.Value}");
                    }
                } 
                else
                {
                    await Console.Out.WriteLineAsync($"Failed response code: {response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }
    }
}
