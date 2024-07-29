using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.Configuration.Database;
public interface IDatabaseConfiguration
{
    DatabaseSection Database { get; set; }
}
