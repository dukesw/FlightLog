using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class PowerPlantRepository : EfRepository<PowerPlant>, IPowerPlantRepository
    {
        public PowerPlantRepository(FlightLogContext context) : base(context)
        {

        }
    }
}
