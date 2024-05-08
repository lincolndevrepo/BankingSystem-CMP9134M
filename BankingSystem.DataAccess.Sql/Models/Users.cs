using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace BankingSystem.DataAccess.Sql.Models
{
    [Table("Users")]
    public class UserSelect
    {
        [Key]
        public int usr_id { get; set; }
        public string usr_firstname { get; set; }
        public string usr_lastname { get; set; }
        public string usr_email { get; set; }
        public string usr_password { get; set; }
        public string usr_phone { get; set; }
        public bool? usr_is_active { get; set; }
    }

    [Table("Users")]
    public class UserInsert
    {
        public string usr_firstname { get; set; }
        public string usr_lastname { get; set; }
        public string usr_email { get; set; }
        public string usr_password { get; set; }
        public string usr_phone { get; set; }
        public bool? usr_is_active { get; set; }
    }

    [Table("Users")]
    public class UserUpdate
    {
        [Key]
        public int usr_id { get; set; }
        public string usr_firstname { get; set; }
        public string usr_lastname { get; set; }
        [Computed]
        public string usr_email { get; set; }
        public string usr_password { get; set; }
        public string usr_phone { get; set; }
        public bool? usr_is_active { get; set; }
    }

    [Table("Users")]
    public class UserChangePassword
    {
        [Key]
        public int usr_id { get; set; }
        [Computed]
        public string usr_firstname { get; set; }
        [Computed]
        public string usr_lastname { get; set; }
        [Computed]
        public string usr_email { get; set; }
        public string usr_password { get; set; }
    }
}
