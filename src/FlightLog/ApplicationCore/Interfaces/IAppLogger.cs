// Copyright DukeSoftware 2018
using System;

namespace DukeSoftware.FlightLog.ApplicationCore.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogDebug(string message, params object[] args);

        void LogError(Exception exception, string message, params object[] args);

        void LogInformation(string message, params object[] args);

        void LogWarning(string message, params object[] args);
    }
}