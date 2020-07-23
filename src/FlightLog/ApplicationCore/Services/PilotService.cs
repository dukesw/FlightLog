using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class PilotService : IPilotService
    {
        private IPilotRepository _pilotRepository;
        private IAppLogger<PilotService> _logger;

        public PilotService(IPilotRepository pilotRepository, IAppLogger<PilotService> logger)
        {
            Guard.AgainstNull(pilotRepository, "pilotRepository");
            Guard.AgainstNull(logger, "logger"); 
            this._pilotRepository = pilotRepository;
            this._logger = logger;
        }
        public Task<Pilot> AddPilotAsync(Pilot pilot)
        {
            throw new NotImplementedException();
        }

        public Task DeletePilotAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pilot> GetPilotByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pilot>> GetPilotsAsync()
        {
            return await _pilotRepository.GetAllAsync();
        }

        public Task<Pilot> UpdatePilotAsync(Pilot pilot)
        {
            throw new NotImplementedException();
        }
    }
}
