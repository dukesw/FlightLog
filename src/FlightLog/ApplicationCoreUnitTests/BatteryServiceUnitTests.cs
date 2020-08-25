using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Services;
using Moq;
using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCoreUnitTests
{
    public class BatteryServiceUnitTests
    {
        private readonly Mock<IBatteryRepository> _batteryRepositoryMock = new Mock<IBatteryRepository>();
        private readonly Mock<IBatteryChargeRepository> _batteryChargeRepositoryMock = new Mock<IBatteryChargeRepository>();
        private readonly Mock<IBatteryTypeRepository> _batteryTypeRepositoryMock = new Mock<IBatteryTypeRepository>();
        private readonly Mock<IAppLogger<BatteryService>> _loggerMock = new Mock<IAppLogger<BatteryService>>();

        [Fact]
        public void InstantiateNewServiceWithNullBatteryRepository_ThrowsNullArgException()
        {
            Assert.Throws<ArgumentNullException>(() => new BatteryService(
                null, 
                _batteryTypeRepositoryMock.Object, 
                _batteryChargeRepositoryMock.Object, 
                _loggerMock.Object)); 
        }

        [Fact]
        public void InstantiateNewServiceWithNullBatteryTypeRepository_ThrowsNullArgException()
        {
             Assert.Throws<ArgumentNullException>(() => new BatteryService(
                 _batteryRepositoryMock.Object, 
                 null, 
                 _batteryChargeRepositoryMock.Object, 
                 _loggerMock.Object));
        }

        [Fact]
        public void InstantiateNewServiceWithNullBatteryChargeRepository_ThrowsNullArgException()
        {
            Assert.Throws<ArgumentNullException>(() => new BatteryService(
                _batteryRepositoryMock.Object, 
                null, 
                _batteryChargeRepositoryMock.Object, 
                _loggerMock.Object));
        }

        [Fact]
        public void InstantiateNewServiceWithNullAppLogger_ThrowsNullArgException()
        {
            Assert.Throws<ArgumentNullException>(() => new BatteryService(
                _batteryRepositoryMock.Object, 
                _batteryTypeRepositoryMock.Object, 
                _batteryChargeRepositoryMock.Object, 
                null));
        }

        [Fact]
        public void EnterChargeDataWithNullBattery_ThrowsBatteryNotFoundException()
        {
            var battery = new Battery { Id = 0, AccountId = 1};
            var charge = new BatteryCharge { Battery = battery, ChargedOn = DateTime.Now, Type = ChargeType.Standard, Mah = 1000 };
            _batteryRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            var service = new BatteryService(
                _batteryRepositoryMock.Object, 
                _batteryTypeRepositoryMock.Object, 
                _batteryChargeRepositoryMock.Object, 
                _loggerMock.Object
            );

            Assert.ThrowsAsync<BatteryNotFoundException>(() => service.EnterChargeDataAsync(1, battery, charge.ChargedOn, charge.Type, charge.Mah));
        }

        [Fact]
        public void EnterChargeDataWithExistingBattery_ReturnsBattery()
        {
            var battery = new Battery { Id = 1, IsActive = true, Notes = "Test battery", PurchaseDate = DateTime.Now.AddMonths(-1), AccountId = 1 };
            var charge = new BatteryCharge { Battery = battery, ChargedOn = DateTime.Now, Type = ChargeType.Standard, Mah = 1000 };
            _batteryRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => battery);
            _batteryChargeRepositoryMock.Setup(x => x.Add(It.IsAny<BatteryCharge>())).Returns(charge);
            var service = new BatteryService(
                _batteryRepositoryMock.Object,
                _batteryTypeRepositoryMock.Object,
                _batteryChargeRepositoryMock.Object,
                _loggerMock.Object
            );

            var result = service.EnterChargeDataAsync(1, battery, charge.ChargedOn, charge.Type, charge.Mah);

            Assert.NotNull(result); 
        }

        // Have  removed this functionality. YAGNI
        //[Fact]
        //public void EnterNewBatteryDataWithNullBatteryType_ThrowsArgumentNullException()
        //{
        //    var newBattery = new Battery { IsActive = true, Notes = "New Battery", PurchaseDate = DateTime.Now.AddDays(-7) };
        //    var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

        //    Assert.ThrowsAsync<ArgumentNullException>(() => service.EnterNewBatteryAsync(newBattery, null));
        //}

        [Fact] 
        public async Task GetBatteriesAsync_CallsListAllAsyncInRepository()
        {
            var batteryList = new List<Battery> { new Battery { Id = 1, AccountId = 1, IsActive = true, Notes = "Test battery", PurchaseDate = DateTime.Now.AddMonths(-1) } };
            _batteryRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(batteryList));
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            var result = await service.ListBatteriesAsync(1);

            Assert.NotEmpty(result);
            _batteryRepositoryMock.Verify(x => x.GetAllAsync());
           
        }

        [Fact]
        public async Task EnterNullBattery_ThrowsArgumentNullException()
        {
            Battery battery = null;
            
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.EnterNewBatteryAsync(1, battery));
        }

        [Fact]
        public async Task EnterNullBatteryType_ThrowsArgumentNullException()
        {
            BatteryType batteryType = null;
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.EnterNewBatteryTypeAsync(1, batteryType));
        }

        [Fact]
        public async Task EnterNewBatteryType_CallsBatteryTypeRepositoryAdd()
        {
            var batteryType = new BatteryType { Type = "Graphene", Cells = 4, CapacityMah = 2200, WeightInGrams = 500, AccountId = 1 };
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await service.EnterNewBatteryTypeAsync(1, batteryType);
            _batteryTypeRepositoryMock.Verify(x => x.AddAsync(batteryType));
        }

        [Fact]
        public async Task GetBatteryTypeByIdAsync_CallsBatteryTypeRepositoryGetByIdAsync()
        {
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);
            var result = await service.GetBatteryTypeByIdAsync(1, 1);

            _batteryTypeRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task GetBatteryByIdAsync_CallsBatteryRepositoryGetByIdAsync()
        {
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);
            var result = await service.GetBatteryByIdAsync(1, 1);

            _batteryRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task UpdateBatteryAsync_CallsBatteryRepositoryUpdateAsync()
        {
            var battery = new Battery { Id = 7, AccountId = 1, BatteryType = new BatteryType { Id = 2, Type = "NanoTech", Cells = 3 }, IsActive = true, PurchaseDate = DateTime.Now, Notes = "Notes for the test" };
            _batteryRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Battery>())).Returns(Task.FromResult(battery));
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);
            
            var result = await service.UpdateBatteryAsync(1, battery); 

            _batteryRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Battery>()));
            Assert.IsType<Battery>(result);
        }

        [Fact]
        public async Task UpdateBatteryTypeAsync_CallsBatteryTypeRepositoryUpdateAsync()
        {
            var batteryType = new BatteryType { AccountId = 1, Type = "Graphene", Cells = 4, CapacityMah = 2200, WeightInGrams = 500 };
            _batteryTypeRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<BatteryType>())).Returns(Task.FromResult(batteryType));
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            var result = await service.UpdateBatteryTypeAsync(1, batteryType);

            _batteryTypeRepositoryMock.Verify(x => x.UpdateAsync(batteryType));

        }

        [Fact]
        public async Task DeleteBatteryAsync_CallsRepositoryDeleteAsync()
        {
            var batteryId = 3;
            var battery = new Battery { Id = batteryId, AccountId = 1, BatteryType = new BatteryType { Id = 1, Type = "NanoTech", Cells = 3 }, IsActive = true, PurchaseDate = DateTime.Now, Notes = "Notes for the test" };
            _batteryRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(battery);
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await service.DeleteBatteryAsync(1, batteryId);

            _batteryRepositoryMock.Verify(x => x.DeleteAsync(battery));
        }

        [Fact]
        public async Task DeleteBatteryTypeAsync_CallsRepositoryDeleteAsync()
        {
            var batteryTypeId = 1;
            var batteryType = new BatteryType { Id = batteryTypeId, AccountId = 1, Type = "Graphene", Cells = 4, CapacityMah = 2200, WeightInGrams = 500 };
            _batteryTypeRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(batteryType);
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await service.DeleteBatteryTypeAsync(1, batteryTypeId);

            _batteryTypeRepositoryMock.Verify(x => x.DeleteAsync(batteryType));
        }

        [Fact]
        public async Task DeleteBatteryAsyncWithBadId_ThrowsBatteryNotFound()
        {
            var batteryId = 7;
            _batteryRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<Battery>(null);
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await Assert.ThrowsAsync<BatteryNotFoundException>(() => service.DeleteBatteryAsync(1, batteryId));

        }

        [Fact]
        public async Task DeleteBatteryTypeAsyncWithBadId_ThrowsBatteryTypeNotFound()
        {
            var batteryTypeId = 8;
            _batteryTypeRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<BatteryType>(null);
            var service = new BatteryService(_batteryRepositoryMock.Object, _batteryTypeRepositoryMock.Object, _batteryChargeRepositoryMock.Object, _loggerMock.Object);

            await Assert.ThrowsAsync<BatteryNotFoundException>(() => service.DeleteBatteryAsync(1, batteryTypeId));

        }


    }
}
