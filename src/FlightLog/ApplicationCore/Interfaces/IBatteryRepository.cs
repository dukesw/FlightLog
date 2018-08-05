// Copyright DukeSoftware 2018
using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IBatteryRepository : IRepository<Battery>, IAsyncRepository<Battery>
    {
    }
}