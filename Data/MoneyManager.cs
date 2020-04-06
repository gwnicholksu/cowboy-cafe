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

            int[] registerValues = Register.Values;
            int[] handValues = Hand.Values;

            // Add Hand to register
            for (int i = 0; i < registerValues.Length; i++)
                registerValues[i] += handValues[i];

            StringBuilder output = new StringBuilder();

            registerValues[0] -= NumberToGive(registerValues[0], 100.00, output, ref changeToGive, new string[2] { "Hundred", "Hundreds" });
            registerValues[1] -= NumberToGive(registerValues[1], 50.00, output, ref changeToGive, new string[2] { "Fifty", "Fifties" });
            registerValues[2] -= NumberToGive(registerValues[2], 20.00, output, ref changeToGive, new string[2] { "Twenty", "Twenties" });
            registerValues[3] -= NumberToGive(registerValues[3], 10.00, output, ref changeToGive, new string[2] { "Ten", "Tens" });
            registerValues[4] -= NumberToGive(registerValues[4], 5.00, output, ref changeToGive, new string[2] { "Five", "Fives" });
            registerValues[5] -= NumberToGive(registerValues[5], 2.00, output, ref changeToGive, new string[2] { "Two", "Twos" });
            registerValues[7] -= NumberToGive(registerValues[7], 1.00, output, ref changeToGive, new string[2] { "Dollar Coin", "Dollar Coins" });
            registerValues[6] -= NumberToGive(registerValues[6], 1.00, output, ref changeToGive, new string[2] { "Ones", "Ones" });
            registerValues[8] -= NumberToGive(registerValues[8], 0.50, output, ref changeToGive, new string[2] { "Half-Dollar", "Half-Dollars" });
            registerValues[9] -= NumberToGive(registerValues[9], 0.25, output, ref changeToGive, new string[2] { "Quarter", "Quarters" });
            registerValues[10] -= NumberToGive(registerValues[10], 0.10, output, ref changeToGive, new string[2] { "Dime", "Dimes" });
            registerValues[11] -= NumberToGive(registerValues[11], 0.05, output, ref changeToGive, new string[2] { "Nickel", "Nickels" });

            if (changeToGive % 0.01 > 0.005) changeToGive += 0.01; // Double precision rounding error
            registerValues[12] -= NumberToGive(registerValues[12], 0.01, output, ref changeToGive, new string[2] { "Penny", "Pennies" });

            if (changeToGive >= 0.01) throw new InvalidOperationException();

            // Make the change official
            Register.Values = registerValues;
            Hand.Values = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return output.ToString();
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
