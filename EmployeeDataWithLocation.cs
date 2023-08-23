using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MachineAssignment.Models
{
    public class EmployeeDataWithLocation
    {
        public Employee Employee { get; set; }
        public List<Country> CountryList { get; set; }
        public List<State> StateList { get; set; }
        public List<City> CityList { get; set; }
    }
}