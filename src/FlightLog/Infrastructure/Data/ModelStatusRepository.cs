using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class ModelStatusRepository : EfRepository<ModelStatus>, IModelStatusRepository
    {
        public ModelStatusRepository(FlightLogContext context) : base(context)
        {

        }
    }
}
