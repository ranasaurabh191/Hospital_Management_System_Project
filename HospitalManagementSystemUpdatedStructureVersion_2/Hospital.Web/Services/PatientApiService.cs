using Hospital.Web.Models;
using System.Text;
using System.Text.Json;

namespace Hospital.Web.Services;

public class PatientApiService
{
    private readonly HttpClient _client;

    public PatientApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<PatientViewModel>> GetPatients()
    {
        var response = await _client.GetAsync("patients");

        if (!response.IsSuccessStatusCode)
            return new List<PatientViewModel>();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<PatientViewModel>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task AddPatient(PatientViewModel patient)
    {
        var json = JsonSerializer.Serialize(patient);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await _client.PostAsync("patients", content);
    }
}