using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.Models.Entities;
public class Location
{
    #region Database properties
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    #endregion

    #region Navigation properties
    public List<CalendarEvent> CalendarEvents { get; set; } = new();
    #endregion
}
