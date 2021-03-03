namespace Neoris.Ionleap.CrossCutting.Utils.Business
{
    public static class Cuit
    {
        public static string GenerateCuit(string dni, string sex)
        {
            if (dni.Length == 7)
            {
                dni = dni.PadLeft(8, '0');
            }

            int number = 0;
            int z = 0;
            string prefix = "";
            int rest = 0;

            switch (sex)
            {
                case "M":
                    prefix = "20";
                    number = (2 * 5) + (0 * 4);
                    break;
                case "F":
                    prefix = "27";
                    number = (2 * 5) + (7 * 4);
                    break;
                case "J":
                    prefix = "30";
                    number = (3 * 5) + (0 * 4);
                    break;
                case "X":
                    prefix = "23";
                    number = (2 * 5) + (3 * 4);
                    break;
            }

            number = (number + (int.Parse(dni.Substring(0, 1)) * 3));
            number = (number + (int.Parse(dni.Substring(1, 1)) * 2));
            number = (number + (int.Parse(dni.Substring(2, 1)) * 7));
            number = (number + (int.Parse(dni.Substring(3, 1)) * 6));
            number = (number + (int.Parse(dni.Substring(4, 1)) * 5));
            number = (number + (int.Parse(dni.Substring(5, 1)) * 4));
            number = (number + (int.Parse(dni.Substring(6, 1)) * 3));
            number = (number + (int.Parse(dni.Substring(7, 1)) * 2));
            rest = (number % 11);
            z = (11 - rest);

            if ((z == 11))
            {
                return (prefix + ((dni + "0")));
            }
            else if ((rest == 1))
            {
                return GenerateCuit(dni, "X");
            }
            else
            {
                return (prefix + ((dni + (z.ToString().Trim()))));
            }
        }

        public static bool ValidateCuit(string cuit)
        {
            if (cuit == null)
            {
                return false;
            }

            cuit = cuit.Replace("-", "");

            if (cuit.Length > 11 || cuit.Length < 11 || cuit.Length == 0)
            {
                return false;
            }
            string cuitToValidate = string.Empty;
            bool isValid = false;

            for (int i = 0; i < cuit.Length; i++)
            {
                var character = cuit[i];
                if ((character > 47) && (character < 58))
                {
                    cuitToValidate = cuitToValidate + character;
                }
            }

            cuit = cuitToValidate;
            isValid = (cuit.Length == 11);
            if (isValid)
            {
                int digitToVerify = 0;
                int adder = 0;
                int product = 0;
                int coefficient = 0;
                int substract = 5;
                for (int i = 0; i < 10; i++)
                {
                    if (i == 4) substract = 11;
                    product = cuit[i];
                    product -= 48;
                    coefficient = substract - i;
                    product = product * coefficient;
                    adder = adder + product;
                }

                int result = adder - (11 * (adder / 11));
                result = 11 - result;

                if (result != 11)
                {
                    digitToVerify = result;
                }

                isValid = (cuit[10].ToString() == digitToVerify.ToString());
            }

            return isValid;
        }
    }
}