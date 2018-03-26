using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CredoGarantApp.Models
{
    public class Request
    {
        //Tables
        [Key]
        public int RequestID { get; set; }
        [Display(Name = "Requesting Firm's Name:")]
        public string RequestingFirmName { get; set; }
        [Display(Name = "Loading Address:")]
        [Required]
        public string LoadingAddress { get; set; }
        [Display(Name = "Loading Date and Time:")]
        [DataType(DataType.DateTime)]
        [Required]
        public System.DateTime LoadingDateTime { get; set; }
        [Display(Name = "Unloading Address:")]
        [Required]
        public string UnloadingAdress { get; set; }
        [Display(Name = "Unloading Date and Time:")]
        [DataType(DataType.DateTime)]
        [Required]
        public System.DateTime UnloadingDateTime { get; set; }
        [Display(Name = "Person for contact's email:")]
        [Required]
        public string EmailOfContact { get; set; }
        [Display(Name = "Person for contact's phone:")]
        [Required]
        public string PhoneOfContact { get; set; }
    }
}