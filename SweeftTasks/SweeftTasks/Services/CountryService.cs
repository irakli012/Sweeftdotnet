using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SweeftTasks.Services
{
    public class CountryService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task GenerateCountryDataFiles()
        {
            // need to request needed fields otherwise error 400 in that url: https://restcountries.com/v3.1/all
            string apiUrl = "https://restcountries.com/v3.1/all?fields=name,region,subregion,latlng,area,population";

            // change path for your environment 
            string folderPath = @"C:\Users\irakl\Desktop\CountryFiles";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                var jsonResponse = await client.GetStringAsync(apiUrl);
                var countries = JsonSerializer.Deserialize<List<Country>>(jsonResponse);

                if (countries == null)
                {
                    Console.WriteLine("no countries found");
                    return;
                }

                foreach (var country in countries)
                {
                    string fileName = $"{SanitizeFileName(country.Name.Common)}.txt";
                    string filePath = Path.Combine(folderPath, fileName);

                    string content = $"Region: {country.Region}\n" +
                                     $"Subregion: {country.Subregion}\n" +
                                     $"LatLng: {string.Join(", ", country.Latlng ?? Array.Empty<double>())}\n" +
                                     $"Area: {country.Area}\n" +
                                     $"Population: {country.Population}";

                    File.WriteAllText(filePath, content);
                }

                Console.WriteLine($"Country files generated in '{folderPath}'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating country files: {ex.Message}");
            }
        }

        // replace invalid characters for files naming 
        private string SanitizeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name;
        }

        private class Country
        {
            [JsonPropertyName("name")]
            public Name Name { get; set; } = new Name();

            [JsonPropertyName("region")]
            public string? Region { get; set; }

            [JsonPropertyName("subregion")]
            public string? Subregion { get; set; }

            [JsonPropertyName("latlng")]
            public double[]? Latlng { get; set; }

            [JsonPropertyName("area")]
            public double Area { get; set; }

            [JsonPropertyName("population")]
            public long Population { get; set; }
        }

        private class Name
        {
            [JsonPropertyName("common")]
            public string Common { get; set; } = "";
        }
    }
}