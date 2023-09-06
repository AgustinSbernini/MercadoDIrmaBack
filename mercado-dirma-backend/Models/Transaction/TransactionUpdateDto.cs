namespace mercado_dirma_backend.Models.Transaction
{
    public class TransactionUpdateDto
    {
        public int IdTransaction { get; set; }
        public TransactionType TransactionType { get; set; }
        public int IdUserFrom { get; set; }
        public int IdUserTo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
