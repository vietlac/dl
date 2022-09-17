using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace VietLacSo2022
{
    public class Utils
    {
        public static bool IsEmail(string email)
        {
            var valid = true;
            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch (Exception)
            {
                valid = false;
            }
            return valid;
        }
    }
}
