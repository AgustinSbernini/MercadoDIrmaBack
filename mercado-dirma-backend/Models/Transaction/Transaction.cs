namespace mercado_dirma_backend.Models.Transaction
{
    public class Transaction
    {
        public int IdTransaction { get; set; }
        public TransactionType TransactionType { get; set; }
        public User UserFrom { get; set; }
        public User UserTo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
