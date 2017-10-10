using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Service;
using TestAssignment.Models;

namespace TestAssignment.Business
{
    public class RepositoryDecimalToText : IRepositoryDecimalToText
    {
        // Main method to get the string of text
        public InformationModel GetInformation(string name, decimal number)
        {
            return new InformationModel
            {
                MyName = name,
                MyOriginalNumber = Math.Round(number, 2).ToString(),
                MyCurrentcyNumberText = TextFromNumber(number)
            };
        }

        // Method to convert the text equivalent to provided number
        private string TextFromNumber(decimal number)
        {
            var numberInWords = string.Empty;
            var wholeNumber = 0;
            string dollers = string.Empty;
            string cents = string.Empty;
            try
            {
                // Seperate the whole number and digits after decimal
                number = Math.Round(number, 2);
                var numberParts = number.ToString().Split('.');
                wholeNumber = int.Parse(numberParts[0]);
                if (numberParts[1] != null)
                {
                    cents = numberParts[1];
                    cents = cents.Length == 1 ? cents + "0" : cents;
                }
            }
            catch
            {
                // in case of error make whole number as 0
                cents = "00";
                wholeNumber = (int)(number);
                dollers = "";
            }
            finally
            {
                // Display the message in case everything is Zero
                if (wholeNumber == 0 && cents == "00")
                {
                    numberInWords = "ZERO DOLLARS AND ZERO CENTS";
                }
                // Display the message when there is no whole number
                else if (wholeNumber == 0 && cents != "00")
                {
                    cents = ConvertnumInText(int.Parse(cents));
                    numberInWords = "ZERO DOLLARS AND " + cents.ToUpper() + "CENTS";
                }
                // Dsiplay text when there is no cents
                else if (wholeNumber != 0 && cents == "00")
                {
                    dollers = ConvertnumInText(wholeNumber);
                    numberInWords = dollers.ToUpper() + "DOLLARS AND ZERO CENTS";
                }
                // Convert the number into Text now
                else
                {
                    dollers = ConvertnumInText(wholeNumber);
                    cents = ConvertnumInText(int.Parse(cents));
                    numberInWords = dollers.ToUpper() + "DOLLARS AND " + cents.ToUpper() + "CENTS";
                }
            }
            return numberInWords;
        }

        // Convert the number into needed Text
        private string ConvertnumInText(int n)
        {
            if (n == 0)
                return "";
            // Text for 1-19
            else if (n > 0 && n <= 19)
            {
                var arr = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                return arr[n - 1] + " ";
            }
            // Text for 20,30,40...90
            else if (n >= 20 && n <= 99)
            {
                var arr = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return arr[n / 10 - 2] + " " + ConvertnumInText(n % 10);
            }
            // Text for 100-199
            else if (n >= 100 && n <= 199)
            {
                return "One Hundred " + ConvertnumInText(n % 100);
            }
            // Text for 200-999
            else if (n >= 200 && n <= 999)
            {
                return ConvertnumInText(n / 100) + "Hundred " + ConvertnumInText(n % 100);
            }
            //Text for Thousands
            else if (n >= 1000 && n <= 1999)
            {
                return "One Thousand " + ConvertnumInText(n % 1000);
            }
            // Text for 10 Thousands
            else if (n >= 2000 && n <= 999999)
            {
                return ConvertnumInText(n / 1000) + "Thousand " + ConvertnumInText(n % 1000);
            }
            // Text for Million
            else if (n >= 1000000 && n <= 1999999)
            {
                return "One Million " + ConvertnumInText(n % 1000000);
            }
            // Text for more than a Million
            else if (n >= 1000000 && n <= 999999999)
            {
                return ConvertnumInText(n / 1000000) + "Million " + ConvertnumInText(n % 1000000);
            }
            // Text for Billion
            else if (n >= 1000000000 && n <= 1999999999)
            {
                return "One Billion " + ConvertnumInText(n % 1000000000);
            }
            // Text for More than a Billion
            else
            {
                return ConvertnumInText(n / 1000000000) + "Billion " + ConvertnumInText(n % 1000000000);
            }
        }
    }
}