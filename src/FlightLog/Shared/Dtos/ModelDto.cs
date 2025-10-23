using System;

namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int AccountId { get; set; }
        public string PowerPlant { get; set; }
        public DateTime? MaidenedOn { get; set; }
        public DateTime? PurchasedOn { get; set; }
        public DateTime? DisposedOn { get; set; }
        public ModelStatusDto Status { get; set; }
        public int TotalFlights { get; set; }
        public int LoggedFlights { get; set; }
        public int UnloggedFlights { get; set; }
        public int SortOrder { get; set; }
        public string Notes { get; set; }

        public ModelDto()
        {
            Status = new ModelStatusDto();
        }
    }
}