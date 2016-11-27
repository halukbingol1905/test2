using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;

namespace MoreTaxiMVC.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public bool IsValid(string _username, string _pwd)
        {
            string _sql = "Select userName From Users Where userMail='" + _username + "' And userPass='" + _pwd + "'";
            using (var cn = new SqlConnection("Data Source=10.134.5.16;user id=pmorOyf57 _ moredb;password=jr0OnW3a;database=moreDB"))
            {
                cn.Open();
                using (var cmd = new SqlCommand(_sql, cn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}