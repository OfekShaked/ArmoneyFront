using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMeProject.Models
{
    public class UserModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string PasswordValidator { get; set; }

        public string phone { get; set; }
        public string soldier_type { get; set; }
        public string soldier_tash_type { get; set; }
        public bool is_lone_soldier { get; set; }
        public int current_money { get; set; }
        public int money_addons { get; set; }
        public int additional_income { get; set; }
        public string target_type { get; set; }
        public int money_target { get; set; }
        public int days_home { get; set; }

    }
}
