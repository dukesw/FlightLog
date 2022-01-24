using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IModelStatusRepository : IRepository<ModelStatus>, IAsyncRepository<ModelStatus>
    {
    }
}