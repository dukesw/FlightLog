using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class PilotRepository : EfRepository<Pilot>, IPilotRepository
    {
        public PilotRepository(FlightLogContext dbContext) : base(dbContext)
        {

        }
    }
}
