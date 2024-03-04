using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Utils
{
    internal class Helpers
    {
        public static string prefix_plus = "[+]";
        public static string prefix_minus = "[-]";
        public static string prefix_star = "[*]";

        public static string WriteLine(string text, int symbol) //0 = -, 1 = +, * = 2
        {
            if (symbol == 0)
            {
                Console.WriteLine($" {prefix_minus} {text}"); // -
            }
            else if (symbol == 1)
            {
                Console.WriteLine($" {prefix_plus} {text}"); //+
            }
            else if (symbol == 2)
            {
                Console.WriteLine($" {prefix_star} {text}"); //*
            }
            else //IF NOT EXITS
            {
                MessageBox.Show($"prefix: {symbol.ToString()} not exists", "Error 001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            return text;
        }

        public static string WriteReadLine(string text, int symbol) //0 = -, 1 = +, * = 2
        {
            if (symbol == 0)
            {
                Console.Write($" {prefix_minus} {text}"); // -
            }
            else if (symbol == 1)
            {
                Console.Write($" {prefix_plus} {text}"); //+
            }
            else if (symbol == 2)
            {
                Console.Write($" {prefix_star} {text}"); //*
            }
            else //IF NOT EXITS
            {
                MessageBox.Show($"prefix: {symbol.ToString()} not exists", "Error 001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            return text;
        }

        public static string Blank()
        {
            string text = " \n";

            Console.Write($"{text}");

            return text;
        }

        public static string Welcome(string username)
        {
            string text = $" Welcome dear, {username}\n";

            Console.Write($"{text}");

            return text;
        }

    }
}
