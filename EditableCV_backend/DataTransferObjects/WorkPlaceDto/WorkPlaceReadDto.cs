using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.WorkPlaceDto
{
  public class WorkPlaceReadDto
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public string Experience { get; set; }
    public DateTime StartWorkingDate { get; set; }
    public bool IsCurrentlyWorking {
      get
      {
        return DateTime.Compare(EndWorkingDate, DateTime.Now) > 0;
      }
      set
      {
        IsCurrentlyWorking = value;
      }
    }
    public DateTime EndWorkingDate { get; set; }
  }
}
