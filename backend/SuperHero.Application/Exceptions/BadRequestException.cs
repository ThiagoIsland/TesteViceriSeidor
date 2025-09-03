using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroi.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string error) : base(error) { }
    }
}
