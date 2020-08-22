using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class MediaLink : EntityBase
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Uri { get; set; }
    }
}
