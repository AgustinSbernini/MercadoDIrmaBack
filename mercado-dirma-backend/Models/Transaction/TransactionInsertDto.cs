namespace mercado_dirma_backend.Models.Transaction
{
    public class TransactionInsertDto
    {
        public TransactionType TransactionType { get; set; }
        public int IdUserFrom { get; set; }
        public int IdUserTo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
