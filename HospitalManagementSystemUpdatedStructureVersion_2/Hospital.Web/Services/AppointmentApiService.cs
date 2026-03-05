using Hospital.Web.Models;
using System.Text;
using System.Text.Json;

namespace Hospital.Web.Services
{
    public class AppointmentApiService
    {
        private readonly HttpClient _client;

        public AppointmentApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AppointmentViewModel>> GetAppointments()
        {
            var response = await _client.GetAsync("appointments");

            if (!response.IsSuccessStatusCode)
                return new List<AppointmentViewModel>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<AppointmentViewModel>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<AppointmentViewModel>();
        }

        public async Task AddAppointment(AppointmentViewModel appointment)
        {
            var json = JsonSerializer.Serialize(appointment);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("appointments", content);
        }
    }
}