using System;
using System.Collections.Generic;
using System.Text;

namespace DukeSoftware.FlightLog.ApplicationCore.Entities
{
    public class ModelStatus : EntityBase
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
       // public virtual IList<Model> Models { get; set; }
    }
}
