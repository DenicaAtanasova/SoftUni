﻿
namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string DefaultMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException()
            : base(DefaultMessage)
        {
        }
    }
}
