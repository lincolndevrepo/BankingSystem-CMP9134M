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
    [Table("Accounts")]
    public class AccountSelect
    {
        [Key]
        public int acc_id { get; set; }
        public string acc_account_number { get; set; }
        public string acc_holder_id { get; set; }
        public string acc_holder_name { get; set; }
        public DateTime? acc_holder_dob { get; set; }
        public string acc_holder_phone { get; set; }
        public string acc_holder_address_door { get; set; }
        public string acc_holder_address_street { get; set; }
        public string acc_holder_address_city { get; set; }
        public string acc_holder_address_post_code { get; set; }
        [Computed]
        public string acc_holder_address { get; set; }
        public string acc_account_type { get; set; }
        public DateTime? acc_opening_date { get; set; } = DateTime.Today;
        public bool acc_checkbook_requested { get; set; } = false;
        public bool acc_checkbook_issued { get; set; } = false;
        public bool acc_card_requested { get; set; } = false;
        public bool acc_card_issued { get; set; } = false;
        public string acc_card_number { get; set; }
        public DateTime? acc_card_issue_date { get; set; } = DateTime.Today;
        public DateTime? acc_card_expiry_date { get; set; } = DateTime.Today;
        public bool acc_is_closed { get; set; } = false;
    }

    [Table("Accounts")]
    public class AccountInsert
    {
        public string acc_holder_id { get; set; }
        public string acc_holder_name { get; set; }
        public DateTime? acc_holder_dob { get; set; }
        public string acc_holder_phone { get; set; }
        public string acc_holder_address_door { get; set; }
        public string acc_holder_address_street { get; set; }
        public string acc_holder_address_city { get; set; }
        public string acc_holder_address_post_code { get; set; }
        public string acc_account_type { get; set; }
        public DateTime? acc_opening_date { get; set; }
        public bool acc_is_closed { get; set; }
    }

    [Table("Accounts")]
    public class AccountUpdate
    {
        [Key]
        public int acc_id { get; set; }
        public string acc_holder_id { get; set; }
        public string acc_holder_name { get; set; }
        public DateTime? acc_holder_dob { get; set; }
        public string acc_holder_phone { get; set; }
        public string acc_holder_address_door { get; set; }
        public string acc_holder_address_street { get; set; }
        public string acc_holder_address_city { get; set; }
        public string acc_holder_address_post_code { get; set; }
        public string acc_account_type { get; set; }
        public DateTime? acc_opening_date { get; set; }
        public bool acc_is_closed { get; set; }
    }

    [Table("Accounts")]
    public class AccountCheckbookAndCardUpdate
    {
        [Key]
        public int acc_id { get; set; }
        public bool acc_checkbook_requested { get; set; } = false;
        public bool acc_checkbook_issued { get; set; } = false;
        public bool acc_card_requested { get; set; } = false;
        public bool acc_card_issued { get; set; } = false;
        public string acc_card_number { get; set; }
        public DateTime? acc_card_issue_date { get; set; } = DateTime.Today;
        public DateTime? acc_card_expiry_date { get; set; } = DateTime.Today;
    }
}
