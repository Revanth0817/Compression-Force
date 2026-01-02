using System;

namespace CompressionForce.Domain.Entities;

public partial class AlarmLog
{
    public int Id { get; set; }   // ✅ PRIMARY KEY

    public string? AlramCode { get; set; }
    public DateTime? AlarmCreatedTime { get; set; }
    public string? AlarmDescription { get; set; }
    public string? UserName { get; set; }
    public string? BatchNumber { get; set; }
}
