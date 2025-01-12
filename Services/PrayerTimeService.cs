namespace PrayerTimes.Services;

using System.Net.Http.Json;

public class PrayerTimeService
{
    private readonly HttpClient _httpClient;

    public PrayerTimeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PrayerTimes> GetPrayerTimesAsync(double latitude, double longitude)
    {
        var url = $"https://api.aladhan.com/v1/timings?latitude={latitude}&longitude={longitude}&method=2";
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>(url);
        return response?.Data?.Timings!;
    }

    private class ApiResponse
    {
        public Data? Data { get; set; }
    }

    public class Data
    {
        public PrayerTimes? Timings { get; set; }
    }

    public class PrayerTimes
    {
        public string? Fajr { get; set; }
        public string? Sunrise { get; set; }
        public string? Dhuhr { get; set; }
        public string? Asr { get; set; }
        public string? Maghrib { get; set; }
        public string? Isha { get; set; }
    }
}
