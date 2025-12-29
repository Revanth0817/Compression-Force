using System;
using System.Collections.Generic;

namespace Compression_Force.Domain.Entities;

public partial class ServoCalibration
{
    public int Id { get; set; }

    public DateTime? DateTime { get; set; }

    public double? Axis1Position { get; set; }

    public double? Axis2Position { get; set; }

    public double? Axis3Position { get; set; }

    public double? Axis4Position { get; set; }

    public double? Axis5Position { get; set; }

    public double? Axis6Position { get; set; }

    public double? Axis7Position { get; set; }

    public double? Axis8Position { get; set; }

    public double? Axis9Position { get; set; }

    public double? Axis10Position { get; set; }
}
