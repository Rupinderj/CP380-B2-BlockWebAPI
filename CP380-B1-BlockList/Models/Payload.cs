
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

   public class Payload
    {
        public string user { get; set; }
        public TransactionTypes transactionType { get; set; }
        public int amount { get; set; }
        public string item { get; set; }

        public Payload(string user, TransactionTypes transaction, int amount, string item)
        {
            this.user = user;
            this.transactionType = transaction;
            this.amount = amount;
            this.item = item;
        }
    }
}
