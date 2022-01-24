using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Specifications;
using DukeSoftware.FlightLog.Shared.Dtos;
using DukeSoftware.GuardClauses;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    public class ModelStatusService : IModelStatusService
    {
        private readonly IModelStatusRepository _modelStatusRepository;
        private readonly IAppLogger<ModelStatusService> _logger;
        private readonly IMapper _mapper;

        public ModelStatusService(IModelStatusRepository modelStatusRepository, IAppLogger<ModelStatusService> logger, IMapper mapper)
        {
            Guard.AgainstNull(modelStatusRepository, "modelStatusRepository");
            Guard.AgainstNull(logger, "logger");
            Guard.AgainstNull(mapper, "mapper");

            _modelStatusRepository = modelStatusRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public Task<ModelStatusDto> AddModelStatusAsync(ModelStatusDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteModelStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelStatusDto> GetModelStatusByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ModelStatusDto>> GetModelStatusesAsync()
        {
            var result = await _modelStatusRepository.GetAllAsync();
            return _mapper.Map<IList<ModelStatus>, IList<ModelStatusDto>>(result);
        }


        public async Task<IList<ModelStatusDto>> GetActiveModelStatusesAsync()
        {
            var spec = new GetModelStatusesByIsActive(true);
            var result = await _modelStatusRepository.GetBySpecAsync(spec);
            return _mapper.Map<IList<ModelStatus>, IList<ModelStatusDto>>(result);
        }

        public Task<ModelStatusDto> UpdateModelStatusAsync(ModelStatusDto model)
        {
            throw new NotImplementedException();
        }
    }
}
