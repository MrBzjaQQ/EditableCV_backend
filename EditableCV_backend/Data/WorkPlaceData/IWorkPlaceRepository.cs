﻿using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.WorkPlaceData
{
  public interface IWorkPlaceRepository : IRepository
  {
    IEnumerable<WorkPlace> GetAllWorkPlaces();
    WorkPlace GetWorkPlaceById(int id);
    void CreateWorkPlace(WorkPlace place);
    void UpdateWorkPlace(WorkPlace place);
    void DeleteWorkPlace(WorkPlace place);
  }
}
