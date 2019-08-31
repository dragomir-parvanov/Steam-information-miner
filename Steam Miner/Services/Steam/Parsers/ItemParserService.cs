namespace Steam_Miner.Services.Steam.Parsers
{
    using System.Collections.Generic;
    using System.Linq;
    using Steam_Miner.Models;

    /// <inheritdoc/>
    public class ItemParserService : IItemParserService
    {
        /// <inheritdoc/>
        public decimal PriceParse(string output)
        {
            output = output.Replace(',', '.');

            // leaving only the digits.
            for (int i = 0; i < output.Length; i++)
            {
                if (!char.IsDigit(output[i]) && output[i] != '.')
                    {
                    output = output.Remove(i, 1);
                    i--;
                    }
            }

            if (output.Last() == '.')
            {
                output = output.Substring(0, output.Length - 1);
            }

            return decimal.Parse(output);
        }

        /// <inheritdoc/>
        public int VolumeParse(string ouput)
        {
            if (ouput == null)
            {
                // no items sold for 24 hours.
                return 0;
            }

            return int.Parse(ouput.Replace(",", string.Empty));
        }
    }
}
