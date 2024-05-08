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
    [Table("Recurrings")]
    public class RecurringSelect
    {
        [Key]
        public int rdd_id { get; set; }
        public int? rdd_debit_acc_id_fk { get; set; }
        public int? rdd_credit_acc_id_fk { get; set; }
        public string rdd_description { get; set; }
        public decimal? rdd_amount { get; set; }
        public int? rdd_day_number { get; set; }
        public bool rdd_status { get; set; } = false;
        [Computed]
        public int acc_holder_id_debit { get; set; }
        [Computed]
        public int acc_holder_id_credit { get; set; }
        [Computed]
        public string acc_number_debit { get; set; }
        [Computed]
        public string acc_number_credit { get; set; }
        [Computed]
        public string acc_holder_name_debit { get; set; }
        [Computed]
        public string acc_holder_name_credit { get; set; }
        [Computed]
        public string acc_account_type_debit { get; set; }
        [Computed]
        public string acc_account_type_credit { get; set; }
    }


    [Table("Recurrings")]
    public class RecurringInsert
    {
        public string rdd_description { get; set; }
        public int? rdd_debit_acc_id_fk { get; set; }
        public int? rdd_credit_acc_id_fk { get; set; }
        public decimal? rdd_amount { get; set; }
        public int? rdd_day_number { get; set; }
    }

    [Table("Recurrings")]
    public class RecurringUpdate
    {
        [Key]
        public int rdd_id { get; set; }
        public string rdd_description { get; set; }
        public int? rdd_debit_acc_id_fk { get; set; }
        public int? rdd_credit_acc_id_fk { get; set; }
        public decimal? rdd_amount { get; set; }
        public int? rdd_day_number { get; set; }
    }
}
