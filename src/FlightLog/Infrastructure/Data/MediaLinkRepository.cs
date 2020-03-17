using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.Infrastructure.Data
{
    public class MediaLinkRepository : EfRepository<MediaLink>, IRepository<MediaLink>, IAsyncRepository<MediaLink>
    {
        public MediaLinkRepository(FlightLogContext context) : base(context)
        {
        }
    }
}
