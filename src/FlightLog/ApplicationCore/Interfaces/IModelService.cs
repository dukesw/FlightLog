﻿using DukeSoftware.FlightLog.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IModelService
    {
        // TODO Work on the ModelService (and interface) next... 
        Task<List<Model>> GetModelsAsync(int accountId);
        Task<Model> GetModelByIdAsync(int accountId, int id);
        Task<Model> AddModelAsync(Model model);
        Task<Model> UpdateModelAsync(Model model);
        Task DeleteModelAsync(int id);
    }
}
