using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.Models.Entities;
public class CalendarEvent
{
    #region Database properties
    public long Id { get; set; }
    public EventType Type { get; set; }
    public Guid IngressImageId { get; set; } = Guid.NewGuid();
    public long LocationId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Author { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public List<string>? CssColorClasses { get; set; }
    #endregion

    #region Computed properties
    public string BlobStorageFileName => $"CalendarEvent-{IngressImageId}";
    #endregion

    #region Navigation properties
    public Location Location { get; set; }
    public List<LocalizedCalendarEventBlurb> LocalizedBlurbs { get; set; }
    #endregion
}
