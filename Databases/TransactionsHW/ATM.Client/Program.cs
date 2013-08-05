using System;
using System.Linq;
using System.Transactions;
using ATM.Data;

namespace ATM.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WithdrawMoney(200, "1234567890", "4321");
        }

        public static void WithdrawMoney(decimal amount, string cardNumber, string cardPIN)
        {
            AtmContext atmContext = new AtmContext();
            using (atmContext)
            {
                TransactionScope transaction = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions()
                    {
                        // This isolation level locks only the current account.
                        // The account can be read but can't be modified.
                        // The other accounts are not locked
                        IsolationLevel = IsolationLevel.RepeatableRead
                    });

                using (transaction)
                {
                    try
                    {
                        CardAccount account = atmContext.CardAccounts
                            .FirstOrDefault(
                                c => c.CardNumber == cardNumber &&
                                c.CardPIN == cardPIN &&
                                c.CardCash >= amount);

                        decimal oldCash = account.CardCash;
                        decimal newCash = account.CardCash - amount;

                        account.CardCash = newCash;
                        atmContext.SaveChanges();

                        UpdateTransactionsHistory(atmContext, account, oldCash, newCash);

                        transaction.Complete();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("No such card exists or the cash in the card is not enough");
                    }
                }
            }
        }

        public static void UpdateTransactionsHistory(AtmContext atmContext, CardAccount account, decimal oldCash, decimal newCash)
        {
            TransactionScope transaction = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions()
                    {
                        // Nested transactions must have the same isolation level
                        IsolationLevel = IsolationLevel.RepeatableRead
                    });

            using (transaction)
            {
                TransactionsHistory tranHistory = new TransactionsHistory()
                {
                    CardAccount = account,
                    OldCash = oldCash,
                    NewCash = newCash
                };

                atmContext.TransactionsHistories.Add(tranHistory);
                atmContext.SaveChanges();

                transaction.Complete();
            }
        }
    }
}
