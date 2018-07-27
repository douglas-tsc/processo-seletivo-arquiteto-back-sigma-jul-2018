﻿using System;

namespace Sigma.PatrimonioApi.Services
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message, params object[] args);
    }
}
