using AutoMapper;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using DukeSoftware.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightTagRepository _flightTagRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IAppLogger<FlightService> _logger;
        private readonly IMapper _mapper;
        public FlightService(IFlightRepository repository, IFlightTagRepository flightTagRepository, IModelRepository modelRepository, IAppLogger<FlightService> logger, IMapper mapper)
        {
            _flightRepository = repository;
            _flightTagRepository = flightTagRepository;
            _modelRepository = modelRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<FlightDto> AddFlightAsync(int accountId, FlightDto flight)
        {
            Guard.AgainstNull(flight, "flight");
            Guard.AgainstAccountNumberMismatch(accountId, flight.AccountId, "accountId", "flight.AccountId");
            var flightEntity = _mapper.Map<FlightDto, Flight>(flight);

            // Attach tags from the DB
            foreach (int i in flight.TagIds)
            {
                var tag = _flightTagRepository.GetById(i);
                if (tag == null)    // Expect this to never happen by design...
                {
                    tag = _mapper.Map<int, FlightTag>(i);
                }
                flightEntity.Tags.Add(tag);
            }

            try
            {
                flightEntity = await _flightRepository.AddAsync(flightEntity);
                _logger.LogInformation($"Added flight, new Id = {flightEntity.Id}");

                await UpdateFlightCountForModel(accountId, flightEntity.ModelId);

                return await GetFlightByIdAsync(accountId, flightEntity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding flight: {flight}.");
                throw; 
            }
        }

        public async Task DeleteFlightAsync(int accountId, int id)
        {
            try
            {
                var flightToDelete = _flightRepository.GetById(id);
                Guard.AgainstNull(flightToDelete, "flightToDelete");
                Guard.AgainstAccountNumberMismatch(accountId, flightToDelete.AccountId, "accountId", "flightToDelete.AccountId");

                await _flightRepository.DeleteAsync(flightToDelete);
                _logger.LogInformation($"Deleted flight with Id: {id}");

                // TODO Update the flight count for the model of this flight
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting flight with Id: {id}");
                throw;
            }
        }

        public async Task<FlightDto> GetFlightByIdAsync(int accountId, int id)
        {
            // todo include a SpecificationBase class then create an instance from there
            var spec = new GetFlightByIdWithIncludes(id);
            var result = await _flightRepository.GetBySpecAsync(spec);
            Guard.AgainstNull(result.FirstOrDefault(), "result");
            return _mapper.Map<Flight, FlightDto>(result.FirstOrDefault());
        }



        public async Task<IList<FlightDto>> GetFlightsAsync(int accountId)
        {
            var spec = new GetFlightsByAccount(accountId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetFlightsPagedAsync(int accountId, int skip, int take)
        {
            var spec = new GetFlightsByAccountPaged(accountId, skip, take);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<int> GetFlightCountAsync(int accountId)
        {
            var spec = new GetFlightsByAccount(accountId);
            var result = await _flightRepository.GetCountBySpecAsync(spec);
            return result;
        }

        public async Task<IList<FlightDto>> GetRecentFlightsAsync(int accountId)
        {
            // Defining recent flights as all of those within the last month, based on the date of the request
            var dateFrom = DateTime.Now.Date.AddMonths(-1);
            // TODO update this to get flights SINCE a date. Will need a new spec. Hacked to get around timezones on server (as not passed from client)
            var spec = new GetFlightsByAccountAndDateRange(accountId, dateFrom, DateTime.Now.Date.AddDays(2).AddSeconds(-1));
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetRecentFlightsPagedAsync(int accountId, int skip, int take)
        {
            // Defining recent flights as all of those within the last month, based on the date of the request
            var dateFrom = DateTime.Now.Date.AddMonths(-1);
            // TODO update this to get flights SINCE a date. Will need a new spec. Hacked to get around timezones on server (as not passed from client)
            var spec = new GetFlightsByAccountAndDateRangePaged(accountId, dateFrom, DateTime.Now.Date.AddDays(2).AddSeconds(-1), skip, take);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<int> GetRecentFlightCountAsync(int accountId)
        {
            // Defining recent flights as all of those within the last month, based on the date of the request
            var dateFrom = DateTime.Now.Date.AddMonths(-1);
            // TODO update this to get flights SINCE a date. Will need a new spec. Hacked to get around timezones on server (as not passed from client)
            var spec = new GetFlightsByAccountAndDateRange(accountId, dateFrom, DateTime.Now.Date.AddDays(2).AddSeconds(-1));
            var result = await _flightRepository.GetCountBySpecAsync(spec);
            return result;
        }

        public async Task<IList<FlightDto>> GetFlightsByModelAsync(int accountId, int modelId)
        {
            var spec = new GetFlightsByAccountAndModel(accountId, modelId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetFlightsByModelPagedAsync(int accountId, int modelId, int skip, int take)
        {
            var spec = new GetFlightsByAccountAndModelPaged(accountId, modelId, skip, take);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<int> GetFlightCountByModelAsync(int accountId, int modelId)
        {
            var spec = new GetFlightsByAccountAndModel(accountId, modelId);
            var result = await _flightRepository.GetCountBySpecAsync(spec);
            return result;
        }

        public async Task<IList<FlightsGroupedByTimeDto>> GetGroupedFlightsByWeekForDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            var result = await _flightRepository.GetGroupedFlightsByWeekForDates(accountId, fromDate, toDate);
            return result;
        }

        public async Task<IList<FlightsGroupedByTimeDto>> GetGroupedFlightsByMonthForDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            var result = await _flightRepository.GetGroupedFlightsByMonthForDates(accountId, fromDate, toDate);
            return result;
        }

        public async Task<IList<FlightsGroupedByModelAndTimeDto>> GetGroupedFlightsByMonthAndModelForDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            var result = await _flightRepository.GetGroupedFlightsByMonthAndModelForDates(accountId, fromDate, toDate);
            return result;
        }
        public async Task<FlightSummaryDto> GetFlightSummaryByModelAsync(int accountId, int modelId)
        {
            var allFlights = await GetFlightsByModelAsync(accountId, modelId);
            var result = CreateFlightSummary(allFlights, accountId);
            return result;
        }

        public async Task<FlightSummaryDto> GetFlightSummaryByDateRange(int accountId, DateTime fromDate, DateTime toDate)
        {
            var allFlights = await GetFlightsByDateRangeAsync(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1));
            var result = CreateFlightSummary(allFlights, accountId);
            return result;
        }

        public async Task<FlightSummaryDto> GetFlightSummaryByModelAndDateRange(int accountId, int modelId, DateTime fromDate, DateTime toDate)
        {
            var allFlights = await GetFlightsByDateRangeAndModelAsync(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1), modelId);
            var result = CreateFlightSummary(allFlights, accountId);
            return result;
        }
        
        public async Task<IList<FlightDto>> GetFlightsByDateRangeAsync(int accountId, DateTime fromDate, DateTime toDate)
        {
            var spec = new GetFlightsByAccountAndDateRange(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1));
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetFlightsByDateRangePagedAsync(int accountId, DateTime fromDate, DateTime toDate, int skip, int take)
        {
            var spec = new GetFlightsByAccountAndDateRangePaged(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1), skip, take);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<int> GetFlightCountByDateRangeAsync(int accountId, DateTime fromDate, DateTime toDate)
        {
            var spec = new GetFlightsByAccountAndDateRange(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1));
            var result = await _flightRepository.GetCountBySpecAsync(spec);
            return result;
        }

        public async Task<IList<FlightDto>> GetFlightsByDateRangeAndModelAsync(int accountId, DateTime fromDate, DateTime toDate, int modelId)
        {
            var spec = new GetFlightsByAccountAndDateRangeAndModel(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1), modelId);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<IList<FlightDto>> GetFlightsByDateRangeAndModelPagedAsync(int accountId, DateTime fromDate, DateTime toDate, int modelId, int skip, int take)
        {
            var spec = new GetFlightsByAccountAndDateRangeAndModelPaged(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1), modelId, skip, take);
            var result = await _flightRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<Flight>, IList<FlightDto>>(result);
        }

        public async Task<int> GetFlightCountByDateRangeAndModelAsync(int accountId, DateTime fromDate, DateTime toDate, int modelId)
        {
            var spec = new GetFlightsByAccountAndDateRangeAndModel(accountId, fromDate.Date, toDate.Date.AddDays(1).AddSeconds(-1), modelId);
            var result = await _flightRepository.GetCountBySpecAsync(spec);
            return result;
        }

        public async Task<FlightDto> UpdateFlightAsync(int accountId, FlightDto flight)
        {
            // TODO get the current flight, check the model. 
            // Then get the model from the new flight. If they are different, update both 
            // flight counts after the update. If they are the same, no need to update flight counts. 
            Guard.AgainstNull(flight, "flight");
            Guard.AgainstAccountNumberMismatch(accountId, flight.AccountId, "accountId", "flight.AccountId");

            // First get from the DB
            var spec = new GetFlightByIdWithIncludes(flight.Id);
            var flightEntity = (await _flightRepository.GetBySpecAsync(spec)).FirstOrDefault();

            // Update fields (not collections)
            flightEntity.CopyFrom(flight);

            // Clear collections. Only tags but media links should be added in the same way
            flightEntity.Tags.Clear();

            // Retrieve and attach tag entities
            foreach (int i in flight.TagIds)
            {
                var tag = _flightTagRepository.GetById(i);
                if (tag == null)    // Expect this to never happen by design...
                {
                    tag = _mapper.Map<int, FlightTag>(i);
                }
                flightEntity.Tags.Add(tag);
            }

            var result = await _flightRepository.UpdateAsync(flightEntity);
            if (result != null)
            {
                _logger.LogInformation($"Updated model, Id = {flightEntity.Id}");
            }
            else
            {
                _logger.LogWarning($"Could not update model, Id = {flightEntity.Id}");
            }
            return await GetFlightByIdAsync(accountId, result.Id);
        }

        private FlightSummaryDto CreateFlightSummary(IList<FlightDto> flights, int accountId)
        {
            var result = new FlightSummaryDto
            {
                AccountId = accountId
            };

            if (flights.Count > 0)
            {
                result.TotalFlightTimeMinutes = (float)flights.Sum(x => x.FlightMinutes);
                result.TotalNumberOfFlights = flights.Count;
                result.AverageFlightTimeMinutes = (float)flights.Average(x => x.FlightMinutes);
                result.FirstFlight = flights.Min(x => x.Date.Value);
                result.LastFlight = flights.Max(x => x.Date.Value);
            };

            return result;
        }

        private async Task UpdateFlightCountForModel(int accountId, int modelId)
        {
            // Updating the total flights for a model
            var model = await _modelRepository.GetByIdAsync(modelId);
            model.LoggedFlights = await GetFlightCountByModelAsync(accountId, modelId);  // Gets the logged flights
            model.TotalFlights = model.LoggedFlights + model.UnloggedFlights;
            var modelResult = await _modelRepository.UpdateAsync(model);
        }

    }
}
