using System;
using System.Collections.Generic;

namespace DntAppApi.core.Entities
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contactno { get; set; }
        public int? Gender { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public int? Stateid { get; set; }
        public int? Cityid { get; set; }
        public int? Countryid { get; set; }
        public string Profilepicture { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Isloginallowed { get; set; }
        public bool? Isemailverified { get; set; }
    }
}
