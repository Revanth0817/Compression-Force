using System;

namespace Compression_Force.Domain.Entities
{
    public class UserManagement
    {
        public int Id { get; set; }

        public string ERname { get; set; }
        public string ERemail { get; set; }
        public string ERpassword { get; set; }
        public string ERlevel { get; set; }

        public bool IsActive { get; set; }           // ✅ FIX 1
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }    // ✅ FIX 3
        public DateTime? LastLoginDate { get; set; } // ✅ FIX 2
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockedUntil { get; set; }

    }
}
