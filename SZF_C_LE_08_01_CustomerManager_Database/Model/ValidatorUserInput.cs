using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace SZF_C_LE_08_01_CustomerManager_Database.Model
{
    class ValidatorUserInput
    {
  
        
        public static bool ValidateCustomerFirstName(string? input)
        {
            string pattern = @"^[A-ZÖÄÜ][A-Za-zÄÖÜäöüß]*([- ][A-ZÖÄÜ][A-Za-zÄÖÜäöüß]+)*$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültige Kundenvorname.\n" +
                                    "Die Eingabe darf nicht leer sein.");


                if (input.Length > 50)
                    errorMessage = ("Ungültige Kundenvorname.\n" +
                                    "Das Wort darf nicht mehr als 50 Zeichen enthalten.");

                else
                    errorMessage = ("Ungültige Kundenvorname.\n" +
                                "Der Name soll aus Buchstaben bestehen und mit einem Großbuchstaben beginnen.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }   
        }

        public static bool ValidateCustomerLastName(string? input)
        {
            string pattern = @"^[A-ZÖÄÜ][A-Za-zÄÖÜäöüß]*([- ][A-ZÖÄÜ][A-Za-zÄÖÜäöüß]+)*$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültige Kundennachname.\n" +
                                    "Die Eingabe darf nicht leer sein.");


                if (input.Length > 50)
                    errorMessage = ("Ungültige Kundennachname.\n" +
                                    "Das Wort darf nicht mehr als 50 Zeichen enthalten.");

                else
                    errorMessage = ("Ungültige Kundennachname.\n" +
                                "Der Name soll aus Buchstaben bestehen und mit einem Großbuchstaben beginnen.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static bool ValidateStreetName(string? input)
        {
            string pattern = @"^[A-ZÖÄÜ][A-Za-zÄÖÜäöüß]*([- ][A-ZÖÄÜ][A-Za-zÄÖÜäöüß\.]+)*$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültiger Straßenname.\n" +
                                    "Die Eingabe darf nicht leer sein.");


                if (input.Length > 50)
                    errorMessage = ("Ungültiger Straßenname.\n" +
                                    "Das Wort darf nicht mehr als 50 Zeichen enthalten.");

                else
                    errorMessage = ("Ungültiger Straßenname.\n" +
                                    "Der Name soll aus Buchstaben bestehen und mit einem Großbuchstaben beginnen\n" +
                                    "Zulässige Abkürzungen wie Str., Pl., usw.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static bool ValidateHausNumber(string? input)
        {
            string pattern = @"^[0-9][A-Za-zÄÖÜäöüß0-9\/]*$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültiger Straßenname.\n" +
                                    "Die Eingabe darf nicht leer sein.");


                if (input.Length > 10)
                    errorMessage = ("Ungültiger Straßenname.\n" +
                                    "Das Wort darf nicht mehr als 10 Zeichen enthalten.");

                else
                    errorMessage = ("Ungültiger Hausnummer.\n" +
                                    "\"Die Hausnummer kann Ziffern, Buchstaben und das Zeichen '/' enthalten.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static bool ValidatePostIndex(string? input)
        {
            string pattern = "^[0-9]{4}$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültige Postleitzahl.\n" +
                                    "Die Eingabe darf nicht leer sein.");

                else
                    errorMessage = ("Ungültige Postleitzahl.\n" +
                                    "Geben Sie eine Zahl mit genau vier Ziffern ein.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static bool ValidateCityName(string? input)
        {
            string pattern = @"^[A-ZÖÄÜ][A-Za-zÄÖÜäöüß\.]*([- ][A-ZÖÄÜ][A-Za-zÄÖÜäöüß\.]+)*$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültige Stadt.\n" +
                                    "Die Eingabe darf nicht leer sein.");


                if (input.Length > 10)
                    errorMessage = ("Ungültige Stadt.\n" +
                                    "Das Wort darf nicht mehr als 10 Zeichen enthalten.");

                else
                    errorMessage = ("Ungültiger Straßenname.\n" +
                                    "Der Name soll aus Buchstaben bestehen und mit einem Großbuchstaben beginnen\n" +
                                    "Zulässige Abkürzungen wie St. usw.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public static bool ValidateEmail(string? input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+(\.[a-zA-Z]{2,})*$";
            string errorMessage = string.Empty;

            if (Regex.IsMatch(input, pattern))
                return true;

            else
            {

                if (string.IsNullOrWhiteSpace(input))
                    errorMessage = ("Ungültige Email.\n" +
                                    "Die Eingabe darf nicht leer sein.");


                if (input.Length > 10)
                    errorMessage = ("Ungültige Email.\n" +
                                    "Das Wort darf nicht mehr als 10 Zeichen enthalten.");

                else
                    errorMessage = ("Ungültiger Email.");

                MessageBox.Show(errorMessage, "Warnung",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }


    }
}
