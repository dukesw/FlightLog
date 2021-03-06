﻿// Copyright DukeSoftware 2018 $(itemName)
using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface ILocationRepository : IRepository<Location>, IAsyncRepository<Location>
    {
    }
}