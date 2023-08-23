using Grpc.Core;
using MachineAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace MachineAssignment.HelperMethods
{
    public class EmployeeCRUDHelperMethods
    {
        private SqlHelperMethods sqlHelperMethods;

        public EmployeeCRUDHelperMethods()
        {
            this.sqlHelperMethods = new SqlHelperMethods();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            DataTable dataTable =  sqlHelperMethods.ExecuteDataTable("stp_Emp_getEmployees");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Employee employee = new Employee();
                Country country = new Country
                {
                    CountryId = (int)dataTable.Rows[i]["CountryId"],
                    CountryName = (dataTable.Rows[i]["CountryName"]).ToString()
                };
                State state = new State
                {
                    Row_Id = (int)dataTable.Rows[i]["StateId"],
                    StateName = (dataTable.Rows[i]["StateName"]).ToString(),
                    CountryId = (int)dataTable.Rows[i]["CountryId"],

                };
                City city = new City
                {
                    Row_Id = (int)dataTable.Rows[i]["CityId"],
                    StateId = (int)dataTable.Rows[i]["StateId"],
                    CityName = (dataTable.Rows[i]["CityName"]).ToString()
                };

                employee.FirstName = dataTable.Rows[i]["FirstName"].ToString();
                employee.LastName = dataTable.Rows[i]["LastName"].ToString();
                employee.EmployeeCode = dataTable.Rows[i]["EmployeeCode"].ToString();
                employee.EmployeeId = (int)dataTable.Rows[i]["Row_Id"];
                employee.EmailAddress = dataTable.Rows[i]["EmailAddress"].ToString();
                employee.MobileNumber = dataTable.Rows[i]["MobileNumber"].ToString();
                employee.PanNumber = dataTable.Rows[i]["PanNumber"].ToString();
                employee.PassportNumber = dataTable.Rows[i]["PassportNumber"].ToString();
                employee.DateOfBirth = (DateTime)dataTable.Rows[i]["DateOfBirth"];
                employee.DateOfJoinee = (DateTime)dataTable.Rows[i]["DateOfJoinee"];
                employee.Country = country;
                employee.State = state;
                employee.City = city;
                employee.ProfileImage = dataTable.Rows[i]["ProfileImage"].ToString();
                employee.Gender = (byte)dataTable.Rows[i]["Gender"];
                employee.IsActive = (bool)dataTable.Rows[i]["IsActive"];

                employees.Add(employee);
            }
            return employees;
        }

        public EmployeeDataWithLocation GetEmployeeDataById(int employeeId, HttpServerUtilityBase server)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@EmployeeId", employeeId);
            DataSet dataSet = sqlHelperMethods.ExecuteDataset("stp_Emp_GetEmployeeById", parameters);
            var dataTable = dataSet.Tables[0];


            Country country = new Country
            {
                CountryId = (int)dataTable.Rows[0]["CountryId"],
                CountryName = (dataTable.Rows[0]["CountryName"]).ToString()
            };
            State state = new State
            {
                Row_Id = (int)dataTable.Rows[0]["StateId"],
                StateName = (dataTable.Rows[0]["StateName"]).ToString(),
                CountryId = (int)dataTable.Rows[0]["CountryId"],

            };
            City city = new City
            {
                Row_Id = (int)dataTable.Rows[0]["CityId"],
                StateId = (int)dataTable.Rows[0]["StateId"],
                CityName = (dataTable.Rows[0]["CityName"]).ToString()
            };

            string imageNameFromDB = dataTable.Rows[0]["ProfileImage"].ToString();
            //string imagePath = Path.Combine(server.MapPath("~/Content/Uploads/Employee/"), imageNameFromDB);
            //string url = Path.Combine(VirtualPathUtility.ToAbsolute("~/Content/Uploads/Employee/"), imageNameFromDB);

            Employee employee = new Employee();
            employee.FirstName = dataTable.Rows[0]["FirstName"].ToString();
            employee.LastName = dataTable.Rows[0]["LastName"].ToString();
            employee.EmployeeCode = dataTable.Rows[0]["EmployeeCode"].ToString();
            employee.EmployeeId = (int)dataTable.Rows[0]["Row_Id"];
            employee.EmailAddress = dataTable.Rows[0]["EmailAddress"].ToString();
            employee.MobileNumber = dataTable.Rows[0]["MobileNumber"].ToString();
            employee.PanNumber = dataTable.Rows[0]["PanNumber"].ToString();
            employee.PassportNumber = dataTable.Rows[0]["PassportNumber"].ToString();
            employee.DateOfBirth = (DateTime)dataTable.Rows[0]["DateOfBirth"];
            employee.DateOfJoinee = (DateTime)dataTable.Rows[0]["DateOfJoinee"];
            employee.Country = country;
            employee.State = state;
            employee.City = city;
            employee.ProfileImage = imageNameFromDB;
            employee.Gender = (byte)dataTable.Rows[0]["Gender"];
            employee.IsActive = (bool)dataTable.Rows[0]["IsActive"];


            EmployeeDataWithLocation employeeData = new EmployeeDataWithLocation();
            employeeData.Employee = employee;
            employeeData.CountryList = GetCountriesByDataset(dataSet);
            employeeData.StateList = GetStatesByDataset(dataSet);
            employeeData.CityList = GetCitiesByDataset(dataSet);

            return employeeData;
        }

        //Get Countries
        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            DataTable dataTable = sqlHelperMethods.ExecuteDataTable("stp_Emp_GetCountries");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                Country country = new Country();
                country.CountryId = (int)dataTable.Rows[i]["Row_Id"];
                country.CountryName = (dataTable.Rows[i]["CountryName"]).ToString();

                countries.Add(country);
            }
            return countries;
        }

        public List<State> GetStates(int countryId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@countryId", countryId);
            List<State> states = new List<State>();
            DataTable dataTable = sqlHelperMethods.ExecuteDataTable("stp_Emp_GetStates",parameters);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                State state = new State();
                state.Row_Id = (int)dataTable.Rows[i]["Row_Id"];
                state.CountryId = (int)dataTable.Rows[i]["CountryId"];
                state.StateName = (dataTable.Rows[i]["StateName"]).ToString();

                states.Add(state);
            }
            return states;
        }

        public List<City> GetCities(int stateId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@StateId", stateId);
            List<City> cities = new List<City>();
            DataTable dataTable = sqlHelperMethods.ExecuteDataTable("stp_Emp_GetCities",parameters);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                City city = new City();
                city.Row_Id = (int)dataTable.Rows[i]["Row_Id"];
                city.StateId = (int)dataTable.Rows[i]["StateId"];
                city.CityName = (dataTable.Rows[i]["CityName"]).ToString();
                cities.Add(city);
            }
            return cities;
        }

        public List<State> GetStatesByDataset(DataSet dataSet)
        {

            var statesTable = dataSet.Tables[2];
            List<State> states = new List<State>();

            for (int i = 0; i < statesTable.Rows.Count; i++)
            {
                State stateModel = new State();
                stateModel.Row_Id = (int)statesTable.Rows[i]["Row_Id"];
                stateModel.StateName = statesTable.Rows[i]["StateName"].ToString();
                stateModel.CountryId = (int)statesTable.Rows[i]["CountryId"];
                states.Add(stateModel);
            }

            return states;
        }

        public List<Country> GetCountriesByDataset(DataSet dataSet)
        {

            var countriesTable = dataSet.Tables[1];
            List<Country> countries = new List<Country>();

            for (int i = 0; i < countriesTable.Rows.Count; i++)
            {
                Country countryModel = new Country();
                countryModel.CountryId = (int)countriesTable.Rows[i]["Row_Id"];
                countryModel.CountryName = countriesTable.Rows[i]["CountryName"].ToString();
                countries.Add(countryModel);
            }

            return countries;
        }

        public List<City> GetCitiesByDataset(DataSet dataSet)
        {

            var citiesTable = dataSet.Tables[3];
            List<City> cities = new List<City>();

            for (int i = 0; i < citiesTable.Rows.Count; i++)
            {
                City cityModel = new City();
                cityModel.Row_Id = (int)citiesTable.Rows[i]["Row_Id"];
                cityModel.StateId = (int)citiesTable.Rows[i]["StateId"];
                cityModel.CityName = citiesTable.Rows[i]["CityName"].ToString();
                cities.Add(cityModel);
            }
            return cities;
        }

        //Create
        public void CreateEmployee(Employee employee, HttpServerUtilityBase server)
        {
            string uniqueFileName = saveImageFile(employee.ProfileImageFile, server);

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(@"FirstName", employee.FirstName);
            parameters.Add(@"LastName", employee.LastName);
            parameters.Add(@"CountryId", employee.Country.CountryId);
            parameters.Add(@"StateId", employee.State.Row_Id);
            parameters.Add(@"CityId", employee.City.Row_Id);
            parameters.Add(@"EmailAddress", employee.EmailAddress);
            parameters.Add(@"MobileNumber", employee.MobileNumber);
            parameters.Add(@"PanNumber", employee.PanNumber);
            parameters.Add(@"PassportNumber", employee.PassportNumber);
            parameters.Add(@"ProfileImage", uniqueFileName);
            parameters.Add(@"Gender", employee.Gender);
            parameters.Add(@"DateOfJoinee", employee.DateOfJoinee);
            parameters.Add("@DateOfBirth", employee.DateOfBirth);
            //parameters.Add(@"IsActive", employee.IsActive);

            var result = sqlHelperMethods.ExecuteSqlNonQuery("stp_Emp_InsertEmployee",parameters);
        }

        //Update
        public void UpdateEmployee(Employee employee, HttpServerUtilityBase server)
        {
            string uniqueFileName = saveImageFile(employee.ProfileImageFile, server);

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(@"EmployeeId", employee.EmployeeId);
            parameters.Add(@"FirstName", employee.FirstName);
            parameters.Add(@"LastName", employee.LastName);
            parameters.Add(@"CountryId", employee.Country.CountryId);
            parameters.Add(@"StateId", employee.State.Row_Id);
            parameters.Add(@"CityId", employee.City.Row_Id);
            parameters.Add(@"EmailAddress", employee.EmailAddress);
            parameters.Add(@"MobileNumber", employee.MobileNumber);
            parameters.Add(@"PanNumber", employee.PanNumber);
            parameters.Add(@"PassportNumber", employee.PassportNumber);
            parameters.Add(@"ProfileImage", uniqueFileName);
            parameters.Add(@"Gender", employee.Gender);
            parameters.Add(@"IsActive", employee.IsActive);
            parameters.Add(@"DateOfJoinee", employee.DateOfJoinee);
            parameters.Add("@DateOfBirth", employee.DateOfBirth);

            var result = sqlHelperMethods.ExecuteSqlNonQuery("stp_emp_update", parameters);
        }

        //Delete
        public void DeleteEmployee(int employeeId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add(@"EmployeeId", employeeId);
            var result = sqlHelperMethods.ExecuteSqlNonQuery("stp_emp_deleteEmp", parameters);
        }

        public string saveImageFile(HttpPostedFileBase profileImageFile, HttpServerUtilityBase server)
        {
            string uniqueFileName = "";
            if (profileImageFile != null && profileImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(profileImageFile.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                string filePath = Path.Combine(server.MapPath("~/Content/Uploads/Employee/"), uniqueFileName);
                profileImageFile.SaveAs(filePath);
                //profileImage = filePath; // Save the file name in the model property
            }
            return uniqueFileName;
        }

    }
}