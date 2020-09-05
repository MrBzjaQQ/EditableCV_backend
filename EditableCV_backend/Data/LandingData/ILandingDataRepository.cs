using EditableCV_backend.DataTransferObjects.LandingDto;
using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.LandingData
{
  public interface ILandingDataRepository
  {
    LandingDataModel GetLandingData();
  }
}
