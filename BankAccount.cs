using System;
using System.Dynamic;
namespace BankAccountNS
{
    /// &lt;summary&gt;
    /// Bank account demo class.
    /// &lt;/summary&gt;
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";
        private readonly string m_customerName;
        private double m_balance;
        private BankAccount() { }
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        ///  Метод для расчета дебита с проверками
        /// </summary>
        /// <param name="amount"> Поле для хранения данных о счёте </param>
        /// <exception cref="ArgumentOutOfRangeException"> Если сумма меньше нуля или меньше снимаемой суммы выводится исключение и сообщение об ошибке</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
{
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
{
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Метод для расчета кредита с проверками
        /// </summary>
        /// <param name="amount"> Поле для хранения данных о счёте </param>
        /// <exception cref="ArgumentOutOfRangeException"> Если сумма меньше нуля выводится исключение и сообщение об ошибке</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
{
                throw new System.ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr.Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}