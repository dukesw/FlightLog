using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
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
        public Task<Pilot> AddPilotAsync(int accountId, Pilot pilot)
        {
            throw new NotImplementedException();
        }

        public Task DeletePilotAsync(int accountId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pilot> GetPilotByIdAsync(int accountId, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pilot>> GetPilotsAsync(int accountId)
        {
            var spec = new GetPilotsByAccount(accountId);
            return await _pilotRepository.GetBySpecAsync(spec);
        }

        public Task<Pilot> UpdatePilotAsync(int accountId, Pilot pilot)
        {
            throw new NotImplementedException();
        }
    }
}
