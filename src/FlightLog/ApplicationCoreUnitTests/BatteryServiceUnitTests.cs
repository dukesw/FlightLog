using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using DukeSoftware.FlightLog.ApplicationCore.Services;
using Moq;
using System;
using Xunit;


namespace ApplicationCoreUnitTests
{
    public class BatteryServiceUnitTests
    {
        [Fact]
        public void InstantiateNewServiceWithNullBatteryRepository_ThrowsNullArgException()
        {
            var batteryTypeRepositoryMock = new Mock<IBatteryTypeRepository>();
            var loggerMock = new Mock<IAppLogger<BatteryService>>();

            Assert.Throws<ArgumentNullException>(() => new BatteryService(null, batteryTypeRepositoryMock.Object, loggerMock.Object));
        }

        [Fact]
        public void InstantiateNewServiceWithNullBatteryTypeRepository_ThrowsNullArgException()
        {
            var batteryRepositoryMock = new Mock<IBatteryRepository>();
            var loggerMock = new Mock<IAppLogger<BatteryService>>();

            Assert.Throws<ArgumentNullException>(() => new BatteryService(batteryRepositoryMock.Object, null, loggerMock.Object));
        }

        [Fact]
        public void InstantiateNewServiceWithNullAppLogger_ThrowsNullArgException()
        {
            var batteryRepositoryMock = new Mock<IBatteryRepository>();
            var batteryTypeRepositoryMock = new Mock<IBatteryTypeRepository>();

            Assert.Throws<ArgumentNullException>(() => new BatteryService(batteryRepositoryMock.Object, batteryTypeRepositoryMock.Object, null));
        }
    }
}
