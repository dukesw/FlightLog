using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IPilotService
    {
        Task<List<Pilot>> GetPilotsAsync();
        Task<Pilot> GetPilotByIdAsync(int id);
        Task<Pilot> AddPilotAsync(Pilot pilot);
        Task<Pilot> UpdatePilotAsync(Pilot pilot);
        Task DeletePilotAsync(int id);
    }
}
