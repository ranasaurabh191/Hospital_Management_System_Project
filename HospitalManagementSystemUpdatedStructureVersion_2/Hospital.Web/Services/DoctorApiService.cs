using Hospital.Web.Models;
using System.Text;
using System.Text.Json;

namespace Hospital.Web.Services;

public class DoctorApiService
{
    private readonly HttpClient _client;

    public DoctorApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<DoctorViewModel>> GetDoctors()
    {
        var response = await _client.GetAsync("doctors");

        if (!response.IsSuccessStatusCode)
            return new List<DoctorViewModel>();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<DoctorViewModel>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task AddDoctor(DoctorViewModel doctor)
    {
        var json = JsonSerializer.Serialize(doctor);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _client.PostAsync("doctors", content);
    }
}