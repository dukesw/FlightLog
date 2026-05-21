namespace DukeSoftware.FlightLog.Shared.Dtos
{
    public class PilotDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsStudent { get; set; }
    }
}