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
    [Table("Transactions")]
    public class TransactionSelect
    {
        [Key]
        public int trn_id { get; set; }
        public DateTime? trn_date { get; set; }
        public string trn_type { get; set; }
        public string trn_receipt_no { get; set; }
        public int? trn_acc_id_fk { get; set; }
        [Computed]
        public string acc_holder_name { get; set; }
        [Computed]
        public string acc_account_type { get; set; }
        public string trn_description { get; set; }
        [Computed]
        public decimal trn_opn_balance { get; set; } = 0;
        public decimal trn_dramount { get; set; } = 0;
        public decimal trn_cramount { get; set; } = 0;
        [Computed]
        public decimal trn_cls_balance { get; set; } = 0;
        [Computed]
        public int? trn_acc_id_fk_to { get; set; }
        [Computed]
        public string acc_holder_name_to { get; set; }
        [Computed]
        public string acc_account_type_to { get; set; }
    }

    [Table("Transactions")]
    public class TransactionInsert
    {
        public DateTime? trn_date { get; set; }
        public string trn_type { get; set; }
        public string trn_receipt_no { get; set; }
        public int? trn_acc_id_fk { get; set; }
        public string trn_description { get; set; }
        public decimal? trn_dramount { get; set; } = 0;
        public decimal? trn_cramount { get; set; } = 0;
        [Computed]
        public int? trn_acc_id_fk_to { get; set; }
        [Computed]
        public string acc_holder_name_to { get; set; }
        [Computed]
        public string acc_account_type_to { get; set; }
    }

    [Table("Transactions")]
    public class TransactionUpdate
    {
        [Key]
        public int trn_id { get; set; }
        public DateTime? trn_date { get; set; }
        public string trn_type { get; set; }
        public string trn_receipt_no { get; set; }
        public int? trn_acc_id_fk { get; set; }
        public string trn_description { get; set; }
        public decimal? trn_dramount { get; set; }
        public decimal? trn_cramount { get; set; }
    }

    public class TransactionHistory
    {
        [Key]
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public string acc_id { get; set; }
        public string acc_holder_name { get; set; }
        public string acc_account_type { get; set; }
        public string acc_account_number { get; set; }
        public string acc_holder_id { get; set; }
        public DateTime? acc_holder_dob { get; set; }
        public string acc_holder_phone { get; set; }
        public string acc_holder_address_door { get; set; }
        public string acc_holder_address_street { get; set; }
        public string acc_holder_address_city { get; set; }
        public string acc_holder_address_post_code { get; set; }
        public string acc_holder_address { get; set; }
        public DateTime? acc_opening_date { get; set; }
        public bool? acc_checkbook_requested { get; set; }
        public bool? acc_checkbook_issued { get; set; }
        public bool? acc_card_requested { get; set; }
        public string acc_card_number { get; set; }
        public DateTime? acc_card_issue_date { get; set; }
        public DateTime? acc_card_expiry_date { get; set; }
        public bool? acc_card_status { get; set; }
        public bool acc_is_closed { get; set; }
    }
}
