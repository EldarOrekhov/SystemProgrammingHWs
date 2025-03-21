using System;
using System.Text.RegularExpressions;

namespace UserValidationLib
{
    public static class UserValidator
    {
        public static bool ValidateFullName(string fullName)
        {
            return Regex.IsMatch(fullName, "^[А-Яа-яA-Za-z]+( [А-Яа-яA-Za-z]+){1,2}$");
        }

        public static bool ValidateAge(string age)
        {
            return int.TryParse(age, out int result) && result > 0 && result < 150;
        }

        public static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?[0-9]{10,15}$");

        }

        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
        }
    }
}
