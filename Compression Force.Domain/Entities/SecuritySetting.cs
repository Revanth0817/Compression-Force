namespace Compression_Force.Domain.Entities
{
    public class SecuritySetting
    {
        public int Id { get; set; }
        public int ApplicationTimeoutMinutes { get; set; }
        public int PasswordExpiryDays { get; set; }
        public int MaxWrongAttempts { get; set; }
    }
}
