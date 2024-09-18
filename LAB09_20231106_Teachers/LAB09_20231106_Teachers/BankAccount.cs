using System;

namespace LAB09_20231106_Teachers
{
    public class BankAccount
    {
        private static string accountNumbers;
        private static readonly Random rnd = new Random();

        private string accountNumber;                   //Privát mező. Csak az osztályon belül érhető el.

        public string AccountNumber                     //Publikus property, vagy magyarul tulajdonság.
        {
            get                                         //A tulajdonság olvasásakor lefutó kód
            {
                return accountNumber;
            }
            set                                         //A tulajdonság írásakor lefutó kód.
            {
                accountNumber = value;
                if (!CheckIfExsist(AccountNumber))
                {
                    accountNumbers += $"|{value}";      //Eltároljuk a bankszálaszámot egy "adatbázisban".
                }
            }
        }

        public string Name { get; private set; }    //Auto property. Kívülről olvasható, de csak belülről írható.
        public decimal Balance { get; private set; }


        public BankAccount(string accountNumber, string name, decimal money)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = money;
        }

        public BankAccount(string name, decimal money)
        {
            AccountNumber = GenerateAccountNumber();
            Name = name;
            Balance = money;
        }

        //Lehetséges az egyik konstrukor hívása a másikból.
        public BankAccount(string accountNumber, string name) : this(accountNumber, name, 0)
        {
        }

        public BankAccount(string name)
        {
            AccountNumber = GenerateAccountNumber();
            Name = name;
            Balance = 0;
        }

        //Lehetséges az egyik konstrukor hívása a másikból.
        public BankAccount() : this("Anonymus")
        {
        }

        /// <summary>
        /// Olyan bankszámlaszámot generál amely NNNNNNNN-NNNNNNNN formátumú, és még nem létezik.
        /// </summary>
        private string GenerateAccountNumber()
        {
            string accountNumber = "";

            do
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        accountNumber += rnd.Next(0, 10);
                    }
                    if (i == 0)
                    {
                        accountNumber += "-";
                    }
                }
            } while (CheckIfExsist(accountNumber));

            return accountNumber;
        }

        /// <summary>
        /// Ellenőrzi hogy az átadott számlaszám szerepel e az "adatbázis"-ban.
        /// </summary>
        private static bool CheckIfExsist(string accountNumber)
        {
            string[] exsistingAccounts = accountNumbers.Split('|');
            for (int i = 0; i < exsistingAccounts.Length; i++)
            {
                if (exsistingAccounts[i] == accountNumber)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Kiírja a példány adattagjait.
        /// </summary>
        public string ShowMe()
        {
            return $"Name: {Name}\nAccount Number: {AccountNumber}\nBalance:{Balance}";
        }

        /// <summary>
        /// Csökkenti a példány pénzét megadott összeggel, amennyiben fizetőképes.
        /// </summary>
        public bool Pay(decimal amount)
        {
            if (amount > Balance)  //Nincs elég pénzünk
            {
                return false;
            }
            else if ((Balance < 0) && (amount > decimal.MaxValue + Balance))/* (balance - sum) would overflow */
            {
                return false;
            }
            else if ((Balance > 0) && (amount < decimal.MinValue + Balance))/* (balance - sum) would underflow */
            {
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

        /// <summary>
        /// Növeli a példány pénzét megadott összeggel, amennyiben lehetséges.
        /// </summary>
        public bool Increase(decimal amount)
        {
            if ((Balance > 0) && (amount > decimal.MaxValue - Balance))        /* (balance + sum) would overflow */
            {
                return false;
            }
            else if ((Balance < 0) && (amount < decimal.MinValue - Balance))   /* (balance + sum) would underflow */
            {
                return false;
            }
            else
            {
                Balance += amount;
                return true;
            }
        }

        /// <summary>
        /// Kamattal növeli a példány pénzét.
        /// </summary>
        public bool Interest(decimal percentage)
        {
            if (percentage < 0) // 0 alatti kamatot nem értelmezünk
            {
                return false;
            }
            else if (Balance > decimal.MaxValue / percentage)     /* (balance * sum) would overflow */
            {
                return false;
            }
            else if (Balance < decimal.MinValue / percentage)   /* (balance * sum) would underflow */
            {
                return false;
            }
            else
            {
                Balance *= percentage;
                return true;
            }
        }

        /// <summary>
        /// A példány pénzének egy részét egy másik példánynak küldi el, amennyiben lehetséges.
        /// </summary>
        public bool SendMoney(decimal amount, BankAccount receiver)
        {
            if (Pay(amount))
            {
                if (receiver.Increase(amount))
                {
                    return true;
                }
                else
                {
                    //A fogadó nem tudta elfogadni a pénzt, ezért visszaküldjük a mi számlánkra.
                    Increase(amount);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
