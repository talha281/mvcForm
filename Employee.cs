using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineAssignment.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public Country Country { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public State State { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public City City { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [StringLength(10, ErrorMessage = "Mobile Number must be 10 digits.", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Pan Number is required.")]
        [StringLength(10, ErrorMessage = "Pan Number must be 10 characters.", MinimumLength = 10)]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Pan Number should be in upper case letters and digits.")]
        [Remote("IsPanNumberUnique", "Home", HttpMethod = "POST", ErrorMessage = "Pan Number already exists.")]
        [Display(Name = "PAN Number")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Passport Number is required.")]
        [StringLength(9, ErrorMessage = "Passport Number must be 9 characters.", MinimumLength = 9)]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Passport Number should be in upper case letters and digits.")]
        [Remote("IsPassportNumberUnique", "Home", HttpMethod = "POST", ErrorMessage = "Passport Number already exists.")]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ProfileImageFile { get; set; }


        [Display(Name = "Upload File")]
        public string ProfileImage { get; set; }

        [Display(Name = "Gender")]
        public byte Gender { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date of Joinee")]
        [DataType(DataType.Date)]
        public DateTime DateOfJoinee { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }

    }
}