using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Models;

namespace TestAssignment.Service
{
    // Interface to implement the Service Layer
    public interface IRepositoryDecimalToText
    {
        // Interface to have the business log for number display
        InformationModel GetInformation(string Name, decimal number);
    }
}