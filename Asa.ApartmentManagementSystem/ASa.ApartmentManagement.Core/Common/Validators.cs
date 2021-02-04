using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.Common
{
    public class Validators
    {
        public static void ValidateBuilding(BuildingDTO building)
        {
            const int MAX_BUILDING_NAME_LENGTH = 50;
            const int MINIMUM_BUILDING_UNITS_COUNT = 1;

            var buildingNameIsNotValid = string.IsNullOrWhiteSpace(building.Name) || building.Name.Length > MAX_BUILDING_NAME_LENGTH;
            if (buildingNameIsNotValid)
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty nor larger than {MAX_BUILDING_NAME_LENGTH} character");
            }

            if (building.NumberOfUnits < MINIMUM_BUILDING_UNITS_COUNT)
            {
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Units, $"The number of units cannot be less than {MINIMUM_BUILDING_UNITS_COUNT }.");
            }
        }

        public static void ValidateApartmentUnit(ApartmentUnitDTO apartment)
        {
            const decimal MAX_APARTMENT_AREA = 100;
            const decimal MIN_APARTMENT_AREA = 10;

            if (apartment.Number < 0)
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Apartment, "Apartment number cannot be less than 0.");

            if (apartment.Area > MAX_APARTMENT_AREA)
                throw new ValidationException(ErrorCodes.Maximum_Violation_Of_Area, $"The area of the apartment {apartment.Id} cannot be less than {MIN_APARTMENT_AREA} squaremeters.");

            if (apartment.Area < MIN_APARTMENT_AREA)
                throw new ValidationException(ErrorCodes.Minimum_Violation_Of_Area, $"The area of the apartment {apartment.Id} cannot be less than {MIN_APARTMENT_AREA} squaremeters.");
        }

        public static void ValidatePerson(PersonDTO person)
        {
            const int MIN_PERSON_NAME_LENGTH = 2;

            var personNameIsNotValid = string.IsNullOrWhiteSpace(person.Name) || person.Name.Length < MIN_PERSON_NAME_LENGTH;
            if (personNameIsNotValid)
            {
                throw new ValidationException(ErrorCodes.Invalid_Person_Name, $"Person name cannot be neither empty nor less than {MIN_PERSON_NAME_LENGTH} character");
            }
        }
    }
}
