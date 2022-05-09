using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }     // This should be set to the userID from Auth0
        public string OwnerEmail { get; set; }
        public DateTime OpenedOn { get; set; }
        public DateTime? ClosedOn { get; set; }

        // TODO Pilots to be added perhaps??? But not all the other properties

    }
}
