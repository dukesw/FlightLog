using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;

namespace DukeSoftware.FlightLog.ApplicationCore.Specifications
{
    internal class GetBatteryTypesByAccountAndIdWithIncludes : BaseSpecification<BatteryType>, ISpecification<BatteryType>
    {

        public GetBatteryTypesByAccountAndIdWithIncludes(int accountId, long id) : base(x => x.Id == id && x.AccountId == accountId)
        {
            Includes.Add(x => x.Batteries);
        }
    }
}