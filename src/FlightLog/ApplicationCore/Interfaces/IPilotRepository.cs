using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IPilotRepository : IRepository<Pilot>, IAsyncRepository<Pilot>
    {
    }
}
