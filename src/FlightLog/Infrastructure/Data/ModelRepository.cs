using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class ModelRepository : EfRepository<Model>, IModelRepository
    {
        public ModelRepository(FlightLogContext context) : base(context)
        {

        }
    }
}
