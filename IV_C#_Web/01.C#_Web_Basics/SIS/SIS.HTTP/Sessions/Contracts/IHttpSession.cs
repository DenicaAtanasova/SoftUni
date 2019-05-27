﻿namespace SIS.HTTP.Sessions.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object GetParameters(string parameterName);

        bool ContainsParameter(string parameterName);

        void AddParameter(string parameterName, object parameter);

        void ClearParameters();
    }
}