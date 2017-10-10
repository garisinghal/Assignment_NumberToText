using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Models;

namespace TestAssignment.Service
{
    // Class to Implement Depedency Injection using Contructor Injection
    public class Container
    {
        private IRepositoryDecimalToText _resp;

        //Constructor Injection
        public Container(IRepositoryDecimalToText resp)
        {
            _resp = resp;
        }
        public InformationModel displayText(string name, decimal number)
        {
            return _resp.GetInformation(name, number);
        }
    }
}