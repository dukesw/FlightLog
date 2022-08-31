using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IFlightTagRepository : IRepository<FlightTag>, IAsyncRepository<FlightTag>
    {
    }
}