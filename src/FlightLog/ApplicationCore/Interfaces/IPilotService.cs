using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IPilotService
    {
        Task<List<Pilot>> GetPilotsAsync(int accountId);
        Task<Pilot> GetPilotByIdAsync(int accountId, int id);
        Task<Pilot> AddPilotAsync(int accountId, Pilot pilot);
        Task<Pilot> UpdatePilotAsync(int accountId, Pilot pilot);
        Task DeletePilotAsync(int accountId, int id);
    }
}
