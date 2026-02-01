using DukeSoftware.FlightLog.Shared.Dtos;

namespace DukeSoftware.FlightLog.FlightLogUI.Pages
{
    public class FlightSearchDto
    {
        public FlightModelDto? Model { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;

    }
}
