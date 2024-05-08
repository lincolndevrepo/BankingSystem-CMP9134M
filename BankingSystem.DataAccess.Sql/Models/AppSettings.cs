using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DataAccess.Sql.Models
{
    [Table("AppSettings")]
    public class AppSettingsSelect
    {
        [Key]
        public int aps_id { get; set; }
        public string aps_code_level_1 { get; set; } = "0";
        public string aps_code_level_2 { get; set; } = "00";
        public string aps_code_level_3 { get; set; } = "000";
        public string aps_code_level_4 { get; set; } = "000";
        public string aps_code_level_5 { get; set; } = "000";
        public string aps_code_level_6 { get; set; } = "00";
        public int aps_default_cash_account_id { get; set; }
        public int aps_default_bank_account_id { get; set; }
        public int aps_default_debtors_id { get; set; }
        public int aps_default_creditors_id { get; set; }
    }

    [Table("AppSettings")]
    public class AppSettingsInsert
    {
        [Key]
        public string aps_code_level_1 { get; set; } = "0";
        public string aps_code_level_2 { get; set; } = "00";
        public string aps_code_level_3 { get; set; } = "000";
        public string aps_code_level_4 { get; set; } = "000";
        public string aps_code_level_5 { get; set; } = "000";
        public string aps_code_level_6 { get; set; } = "00";
        public int aps_default_cash_account_id { get; set; }
        public int aps_default_bank_account_id { get; set; }
        public int aps_default_debtors_id { get; set; }
        public int aps_default_creditors_id { get; set; }
    }

    [Table("AppSettings")]
    public class AppSettingsUpdate
    {
        [Key]
        public int aps_id { get; set; }
        public string aps_code_level_1 { get; set; } = "0";
        public string aps_code_level_2 { get; set; } = "00";
        public string aps_code_level_3 { get; set; } = "000";
        public string aps_code_level_4 { get; set; } = "000";
        public string aps_code_level_5 { get; set; } = "000";
        public string aps_code_level_6 { get; set; } = "00";
        public int aps_default_cash_account_id { get; set; }
        public int aps_default_bank_account_id { get; set; }
        public int aps_default_debtors_id { get; set; }
        public int aps_default_creditors_id { get; set; }
    }
}
