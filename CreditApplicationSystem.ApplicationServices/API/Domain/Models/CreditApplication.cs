namespace CreditApplicationSystem.ApplicationServices.API.Domain.Models
{
    public class CreditApplication
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal AmountRequested { get; set; }
    }
}
