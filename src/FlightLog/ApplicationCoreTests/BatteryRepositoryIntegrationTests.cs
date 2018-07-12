// Copyright DukeSoftware 2018 $(file)
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;

using Xunit;

namespace DukeSoftware.FlightLog.ApplicationCoreIntegrationTests
{
    public class BatteryRepositoryIntegrationTests
    {
        private readonly FlightLogContext _dbContext;
        private readonly IBatteryRepository _repository;
        private readonly string _connectionString = "Server=.\\SQL2016Dev;Database=FlightLogv2IntegrationTest;User=sa;Password=Password1!;MultipleActiveResultSets=true";

        public BatteryRepositoryIntegrationTests()
        {
            var dbOptions = new DbContextOptionsBuilder<FlightLogContext>()
                .UseSqlServer(_connectionString)
                .Options;
            _dbContext = new FlightLogContext(dbOptions);
            _repository = new BatteryRepository(_dbContext);
        }

        [Fact]
        public void Repository_InsertNewBattery()
        {
            var battery = new Battery { IsActive = true, PurchaseDate = DateTime.Now, Notes = "Testing - IntegrationTests" };
            var result = _repository.Add(battery);

            Assert.NotNull(result);
        }

        [Fact]
        public void Repository_GetExistingBattery()
        {
            var allBatteries = _repository.ListAll();

            Assert.NotNull(allBatteries);

        }

        [Fact]
        public void Repository_UpdateExsiting()
        {
            var battery = _repository.GetById(1);
            battery.Notes = "Updated notes - integration testing";
            battery.IsActive = false;
            _repository.Update(battery);

        }

        [Fact]
        public void Repository_DeleteExisting()
        {
            var battery = _repository.GetById(2);
            _repository.Delete(battery);
        }
    }
}