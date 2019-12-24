// Copyright DukeSoftware 2018 $(file)
using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            var notes = "Testing - IntegrationTests";
            var battery = new Battery { IsActive = true, PurchaseDate = DateTime.Now, Notes = notes };
            var result = _repository.Add(battery);

            Assert.NotNull(result);
            Assert.True(result.Notes == notes);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public void Repository_GetExistingById()
        {
            var id = _repository.ListAll().First().Id;

            var result = _repository.GetById(id);

            Assert.NotNull(result);
            Assert.True(id == result.Id);
        }

        [Fact]
        public void Repository_GetExistingList()
        {
            var allBatteries = _repository.ListAll().ToList();

            Assert.NotNull(allBatteries);
            Assert.True(allBatteries.Count > 0);

        }

        [Fact]
        public void Repository_UpdateExisting()
        {

            var battery = _repository.ListAll().First();
            var batteryId = battery.Id;
            var notesText = "Updated notes - integration testing";
            battery.Notes = notesText;
            battery.IsActive = false;

            var result = _repository.Update(battery);

            Assert.True(result.Id == batteryId);
            Assert.True(result.Notes == notesText);
            Assert.True(!result.IsActive);
        }

        [Fact]
        public void Repository_DeleteExistingLinq()
        {
            var startCount = _repository.ListAll().Count();
            Battery battery = _repository.ListAll().FirstOrDefault();

            _repository.Delete(battery);

            var endCount = _repository.ListAll().Count();
            Assert.Equal(startCount - 1, endCount);
        }

    }
}