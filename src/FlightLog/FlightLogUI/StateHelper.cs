using DukeSoftware.FlightLog.FlightLogUI.Pages;

namespace DukeSoftware.FlightLog.FlightLogUI
{
    public class StateHelper : IStateHelper
    {
        public FlightSearchDto SearchState { get; set; } = new FlightSearchDto();
    }
}
