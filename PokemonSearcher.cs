namespace Search;

using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PokemonSearcher
{
    public static void Search(string search)
    {
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        HttpClient client = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://pokeapi.co/api/v2/pokemon/{search}"
        );

        HttpResponseMessage response = client.Send(request);

        HttpContent content = response.Content;
        Stream stream = content.ReadAsStream();
        // Decoding eller deserialization
        // Encoding, serialization

        Pokemon? pokemon = JsonSerializer.Deserialize<Pokemon>(stream, jsonOptions);
        if (pokemon == null)
        {
            Console.WriteLine("Could not parse pokemon.");
        }
        else
        {
            Console.WriteLine(pokemon.Name);
            Console.WriteLine(pokemon.Id);
            Console.WriteLine(pokemon.BaseExperience);
        }
    }
}

class Pokemon
{
    public string? Name { get; set; }
    public int? Id { get; set; }

    [JsonPropertyName("base_experience")]
    public int? BaseExperience { get; set; }
}
