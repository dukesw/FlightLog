using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{   
    public class GetModelStatusesByIsActive : BaseSpecification<ModelStatus>, ISpecification<ModelStatus>
    {
        public GetModelStatusesByIsActive(bool isActive) : base(x => x.IsActive == isActive)
        {
        }
    }
}


