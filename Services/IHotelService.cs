using TravelGuideAPI.Models;

namespace TravelGuideAPI.Services
{
    public interface IHotelService
    {
        Task<HotelModel> GetHotelDataAsync(string location);
    }
}
