using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.Models.Entities;
public class LocalizedCalendarEventBlurb
{
    #region Database properties
    public long CalendarEventId { get; set; }
    public CultureInfo Culture { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    #endregion

    #region Navigation properties
    public CalendarEvent CalendarEvent { get; set; }
    #endregion
}
