using DukeSoftware.FlightLog.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DukeSoftware.GuardClauses;
using DukeSoftware.FlightLog.ApplicationCore.Entities;

namespace DukeSoftware.FlightLog.ApplicationCore.Services
{
    // The intention is that this function will look after any functions related to battey management. 
    // For example the mode that a battery is currently in (storage, charged, depleted), and when charged/flown how many mah were put back into it. 
    public class BatteryService : IBatteryService
    {
        private readonly IBatteryRepository _batteryRepository;
        private readonly IBatteryTypeRepository _batteryTypeRepository;
        private readonly IAppLogger<BatteryService> _logger;

        public BatteryService(IBatteryRepository batteryRepository, IBatteryTypeRepository batteryTypeRepository, IAppLogger<BatteryService> logger)
        {
            Guard.AgainstNull(batteryRepository, "batteryRepository");
            Guard.AgainstNull(batteryTypeRepository, "batteryTypeRepository");
            Guard.AgainstNull(logger, "logger");

            _batteryRepository = batteryRepository;
            _batteryTypeRepository = batteryTypeRepository;
            _logger = logger ;
        }

        public Battery EnterDischargeData(Battery battery, int mahUsed)
        {
            // Seems like we need a "discharge" object or event...
            // Perhaps this could be charge data... ??? not discharge. Then idea is that when you charge it, you know how much was added. Although if you put into storage mode that will not work... 
            // Think about this based on the process used... 
            // Charge, discharge, storage, repeat... 
            throw new NotImplementedException();
        }




    }
}
