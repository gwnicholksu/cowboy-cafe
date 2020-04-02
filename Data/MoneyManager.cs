using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Manage the money held in the register or in hand
    /// </summary>
    public class MoneyManager
    {
        /// <summary>
        /// The money in the cash register
        /// </summary>
        public static CashRegisterModelView Register { get; private set; } = new CashRegisterModelView();

        /// <summary>
        /// The cash in hand
        /// </summary>
        public CashInHand Hand { get; private set; } = new CashInHand();

        /// <summary>
        /// Add the hand to the register and calculate how much change we need to give.
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public string CalculateChange(double total)
        {
            double changeToGive = Hand.TotalValue - total;

            AddHandToRegister();
            StringBuilder output = new StringBuilder();

            Register.Hundreds -= NumberToGive(Register.Hundreds, 100.00, output, ref changeToGive, new string[2] { "Hundred", "Hundreds" });
            Register.Fifties -= NumberToGive(Register.Fifties, 50.00, output, ref changeToGive, new string[2] { "Fifty", "Fifties" });
            Register.Twenties -= NumberToGive(Register.Twenties, 20.00, output, ref changeToGive, new string[2] { "Twenty", "Twenties" });
            Register.Tens -= NumberToGive(Register.Tens, 10.00, output, ref changeToGive, new string[2] { "Ten", "Tens" });
            Register.Fives -= NumberToGive(Register.Fives, 5.00, output, ref changeToGive, new string[2] { "Five", "Fives" });
            Register.Twos -= NumberToGive(Register.Twos, 2.00, output, ref changeToGive, new string[2] { "Two", "Twos" });
            Register.Dollars -= NumberToGive(Register.Dollars, 1.00, output, ref changeToGive, new string[2] { "Dollar Coin", "Dollar Coins" });
            Register.Ones -= NumberToGive(Register.Ones, 1.00, output, ref changeToGive, new string[2] { "Ones", "Ones" });
            Register.HalfDollars -= NumberToGive(Register.HalfDollars, 0.50, output, ref changeToGive, new string[2] { "Half-Dollar", "Half-Dollars" });
            Register.Quarters -= NumberToGive(Register.Quarters, 0.25, output, ref changeToGive, new string[2] { "Quarter", "Quarters" });
            Register.Dimes -= NumberToGive(Register.Dimes, 0.10, output, ref changeToGive, new string[2] { "Dime", "Dimes" });
            Register.Nickels -= NumberToGive(Register.Nickels, 0.05, output, ref changeToGive, new string[2] { "Nickel", "Nickels" });
            Register.Pennies -= NumberToGive(Register.Pennies, 0.01, output, ref changeToGive, new string[2] { "Penny", "Pennies" });

            if (changeToGive >= 0.01) throw new InvalidOperationException();

            return output.ToString();
        }

        /// <summary>
        /// Add all the coins and bills back into the register
        /// </summary>
        private void AddHandToRegister()
        {
            Register.Pennies += Hand.Pennies;
            Register.Nickels += Hand.Nickels;
            Register.Dimes += Hand.Dimes;
            Register.Quarters += Hand.Quarters;
            Register.HalfDollars += Hand.HalfDollars;
            Register.Dollars += Hand.Dollars;
            Register.Twos += Hand.Twos;
            Register.Fives += Hand.Fives;
            Register.Tens += Hand.Tens;
            Register.Twenties += Hand.Twenties;
            Register.Fifties += Hand.Fifties;
            Register.Hundreds += Hand.Hundreds;
        }

        /// <summary>
        /// Find the number of some currency to give as change
        /// </summary>
        /// <param name="numberAvailable">The number of a coin or bill</param>
        /// <param name="value">The worth of this denomination</param>
        /// <param name="output">The string saying what to give</param>
        /// <param name="total">Reference to the total cost</param>
        /// <param name="name">A size 2 array of the singular and plural name of the denomination</param>
        /// <returns>Number of this denomination to give</returns>
        private int NumberToGive(int numberAvailable, double value, StringBuilder output, ref double total, string[] name)
        {
            int numberNeeded = (int)(total / value);

            int numberToUse = Math.Min(numberAvailable, numberNeeded);

            if (numberToUse == 1) output.AppendLine($"{numberToUse} {name[0]}");
            if (numberToUse > 1) output.AppendLine($"{numberToUse} {name[1]}");

            total -= numberToUse * value;

            return numberToUse;
        }
    }
}
