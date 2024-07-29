using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.Configuration.Database;
public sealed class IdentityColumnConfig
{
    public long Seed { get; set; }
    public int Increment { get; set; } = 1;
}
