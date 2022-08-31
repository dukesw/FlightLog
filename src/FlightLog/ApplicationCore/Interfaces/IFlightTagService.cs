using DukeSoftware.FlightLog.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IFlightTagService
    {
        Task<IList<FlightTagDto>> GetFlightTagsAsync();
        Task<FlightTagDto> GetFlightTagByIdAsync(int id);
        Task<FlightTagDto> AddFlightTagAsync(FlightTagDto flightTag);
        Task<FlightTagDto> UpdateFlightTagAsync(FlightTagDto flightTag);
        Task DeleteFlightTagAsync(int id);
    }
}
