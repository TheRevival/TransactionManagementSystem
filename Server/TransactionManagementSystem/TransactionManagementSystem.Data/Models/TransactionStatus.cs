namespace TransactionManagementSystem.Data.Models
{
    public class TransactionStatus
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}