using DukeSoftware.FlightLog.ApplicationCore.Entities;
using DukeSoftware.FlightLog.ApplicationCore.Exceptions;
using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Services;
using Moq;
using System;
using Xunit;


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
            var battery = new Battery { Id = 0 };
            var charge = new BatteryCharge { Battery = battery, ChargedOn = DateTime.Now, Type = ChargeType.Standard, Mah = 1000 };
            _batteryRepositoryMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(() => null);
            var service = new BatteryService(
                _batteryRepositoryMock.Object, 
                _batteryTypeRepositoryMock.Object, 
                _batteryChargeRepositoryMock.Object, 
                _loggerMock.Object
            );

            Assert.ThrowsAsync<BatteryNotFoundException>(() => service.EnterChargeDataAsync(battery, charge.ChargedOn, charge.Type, charge.Mah));
        }

        [Fact]
        public void EnterChargeDataWithExistingBattery_ReturnsBattery()
        {
            var battery = new Battery { Id = 1, IsActive = true, Notes = "Test battery", PurchaseDate = DateTime.Now.AddMonths(-1) };
            var charge = new BatteryCharge { Battery = battery, ChargedOn = DateTime.Now, Type = ChargeType.Standard, Mah = 1000 };
            _batteryRepositoryMock.Setup(x => x.GetById(It.IsAny<long>())).Returns(() => battery);
            _batteryChargeRepositoryMock.Setup(x => x.Add(It.IsAny<BatteryCharge>())).Returns(charge);
            var service = new BatteryService(
                _batteryRepositoryMock.Object,
                _batteryTypeRepositoryMock.Object,
                _batteryChargeRepositoryMock.Object,
                _loggerMock.Object
            );

            var result = service.EnterChargeDataAsync(battery, charge.ChargedOn, charge.Type, charge.Mah);

            Assert.NotNull(result); 
        }
    }
}
