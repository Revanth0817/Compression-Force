using System;

namespace Compression_Force.Domain.Entities;

public partial class AuditTrail
{
    public int Id { get; set; }   // ✅ PRIMARY KEY

    public DateTime? DateTime { get; set; }
    public string? UserName { get; set; }
    public string? EventDescription { get; set; }
    public string? Activity { get; set; }
    public string? BatchNumber { get; set; }
    public string? Password { get; set; }
}
