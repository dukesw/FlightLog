using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    internal class GetBatteryTypeWithAllDetails : BaseSpecification<BatteryType>, ISpecification<BatteryType>
    {

        public GetBatteryTypeWithAllDetails(long id) : base(x => x.Id == id)
        {
            Includes.Add(x => x.Batteries);
        }
    }
}