using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.Common
{
    public class ErrorCodes
    {
        ErrorCodes() { }
        public const int Invalid_Building_Name = 1000;
        public const int Invalid_Number_Of_Units = 1001;
        public const int Invalid_Number_Of_Apartment = 1002;
        public const int Minimum_Violation_Of_Area = 1003;
        public const int Maximum_Violation_Of_Area = 1004;
    }
}
