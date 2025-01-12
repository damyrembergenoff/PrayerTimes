using Microsoft.JSInterop;

namespace PrayerTimes.Services;

public class LocationService
{
    private readonly IJSRuntime _jsRuntime;

    public LocationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<(double Latitude, double Longitude)> GetUserLocationAsync()
    {
        try
        {
            var location = await _jsRuntime.InvokeAsync<Location>("getUserLocation");
            return (location.Latitude, location.Longitude);
        }
        catch (Exception ex)
        {
            throw new Exception("Lokatsiyani olishda xatolik: " + ex.Message);
        }
    }

    private class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
