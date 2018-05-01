using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\tWelcome!! Let's get to know a little about you");
            Console.WriteLine();
            Console.WriteLine();
            bool truth = false;
            do
            {

                Console.Write("Please write your first name, start with a capital letter PLEASE:  ");
                string Name = Console.ReadLine();

                if (NameChecker(Name))
                {
                    Console.WriteLine($"Valid name, welcome {Name}!!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Sorry, name is not valid!");
                    Console.WriteLine();
                    truth = true;
                    continue;
                }

                Console.Write("Please insert your email:  ");
                string Email = Console.ReadLine();

                if (EmailChecker(Email))
                {
                    Console.WriteLine($"{Email} is valid.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{Email} is invalid.");
                    Console.WriteLine();
                    truth = true;
                    continue;
                }

                Console.Write("Please write a valid phone number in the format Three Digits - Three Digits - 4 Digits:  ");
                string PhoneNumber = Console.ReadLine();
                if (PhoneNumberChecker(PhoneNumber))
                {
                    Console.WriteLine("Phone number is valid");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Phone number is invalid");
                    Console.WriteLine();
                    truth = true;
                    continue;
                }

                Console.WriteLine("Please insert a DD/MM/YYYY:  ");
                string Date = Console.ReadLine();
                if (DateChecker(Date))
                {
                    Console.WriteLine("Date is valid!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Sorry, date is invalid!");
                    Console.WriteLine();
                    truth = true;
                    continue;
                }

                Console.WriteLine("Please insert HTML element(s) you want to validate below");
                string Html = Console.ReadLine();
                Console.WriteLine();
                if (HtmlValidator(Html))
                {
                    Console.WriteLine("HTML element is valid!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Not an HTML!");
                    Console.WriteLine();
                    truth = false;
                    continue;
                }

                truth = Continue(); 
            } while (truth);
            
        }

        public static bool DateChecker(string date)
        {
            string[] DateNumberArray = date.Split(' ');
            for (int i = 0; i < DateNumberArray.Length; i++)
            {
                if (DateValidator(DateNumberArray[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool PhoneNumberChecker(string phoneNumber)
        {
            string[] PhoneNumberArray = phoneNumber.Split(' ');
            for (int i = 0; i < PhoneNumberArray.Length; i++)
            {
                if (PhoneValidator(PhoneNumberArray[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool EmailChecker(string email)
        {
            string[] EmailArray = email.Split(' ');
            for (int i = 0; i < EmailArray.Length; i++)
            {
                if (EmailValidator(EmailArray[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool NameChecker(string name)
        {
            string[] NameArray = name.Split(' ');
            for (int i = 0; i < NameArray.Length; i++)
            {
                if (NameValidator(NameArray[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

        public static bool HtmlValidator(string html)
        {
            if (((Regex.IsMatch(html, @"\<[a-z]{1}\>") && (Regex.IsMatch(html, @"\<\/[a-z]{1}\>")))))
            {
                return true;
            }
            else if ((Regex.IsMatch(html, @"\<[a-z]{1}\d{1}\>")&&(Regex.IsMatch(html, @"\<\/[a-z]{1}\d{1}\>"))))
            {
                return true;
            }

            return false;
        }

        public static bool NameValidator(string name)
        {
            return (Regex.IsMatch(name, @"\b[A-Z]{1}[a-z]{0,29}\b"));
            
            //else
            //{
            //    Regex.Replace(name, " ", "");
            //    Console.WriteLine(name);
            //    return false;
            //}
            //return false;
        } 

        public static bool EmailValidator(string emailAddress)
        {
            return Regex.IsMatch(emailAddress, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        }

        public static bool PhoneValidator(string phoneDigits) // Can prob also convert in main and input int instead
        {
            return Regex.IsMatch(phoneDigits, @"\b(\d{3}[-, .]){2}\d{4}\b");
        }

        public static bool DateValidator(string date) //Might be a way to use string, but def need to look up formatter
        {
            return Regex.IsMatch(date, @"\b(\d{1,2}[-, .,\/]){2}(\d{2}|\d{4})\b");
        }

        public static bool Continue()
        {
            while (true)
            {
                Console.Write("\t\t\t\t\t\tContinue? (y/n): ");

                string jump = Console.ReadLine().ToUpper();

                if (jump == "N")
                {
                    return false;
                }
                else if (jump == "Y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Input was not \"y\" or \"n\"! Please try again!");
                    continue;
                }
            }
        }
        //public static bool IsUpper(this string value)
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        if (char.IsLower(value[i]))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public static bool IsLower(this string value)
        //{
        //    // Consider string to be lowercase if it has no uppercase letters.
        //    for (int i = 0; i < value.Length; i++)
        //    {
        //        if (char.IsUpper(value[i]))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
