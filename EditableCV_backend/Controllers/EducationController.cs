using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.EducationInstitutionData;
using EditableCV_backend.DataTransferObjects.EducationalInstitutionDto;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/education")]
  [ApiController]
  public class EducationController : ControllerBase
  {
    public EducationController(IEducationRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<InstitutionReadDto>> GetAllInstitutions()
    {
      IEnumerable<EducationalInstitution> institutions = _repository.GetAllInstitutions();
      return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(institutions));
    }
    [HttpGet("{id}", Name = "GetInstitutionById")]
    public ActionResult<InstitutionReadDto> GetInstitutionById(int id)
    {
      EducationalInstitution institution = _repository.GetInstitutionById(id);
      if (institution == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<InstitutionReadDto>(institution));
    }
    [HttpPost]
    public ActionResult<InstitutionReadDto> PostInstitution(InstitutionCreateDto createInstitution)
    {
      EducationalInstitution institution = _mapper.Map<EducationalInstitution>(createInstitution);
      if (!institution.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received education data is invalid");
        return BadRequest(ModelState);
      }
      _repository.CreateInstitution(institution);
      _repository.SaveChanges();
      InstitutionReadDto readInstitution = _mapper.Map<InstitutionReadDto>(institution);
      return CreatedAtRoute(nameof(GetInstitutionById), new { Id = readInstitution.Id }, readInstitution);
    }
    [HttpPut("{id}")]
    public ActionResult PutInstitution(int id, InstitutionUpdateDto updateInstitution)
    {
      EducationalInstitution institution = _repository.GetInstitutionById(id);
      if (institution == null)
      {
        return NotFound();
      }
      // update institution for db context
      var resultInstitution = _mapper.Map(updateInstitution, institution);
      if (!resultInstitution.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received education data is invalid");
        return BadRequest(ModelState);
      }
      // does nothing for current implementation, but it should be called because under _repository may be another implementation
      _repository.UpdateInstitution(resultInstitution);
      _repository.SaveChanges();
      return NoContent();
    }
    [HttpPatch("{id}")]
    public ActionResult PatchInstitution(int id, JsonPatchDocument<InstitutionUpdateDto> patchDocument)
    {
      EducationalInstitution institution = _repository.GetInstitutionById(id);
      if (institution == null)
      {
        return NotFound();
      }

      InstitutionUpdateDto institutionToPatch = _mapper.Map<InstitutionUpdateDto>(institution);
      patchDocument.ApplyTo(institutionToPatch, ModelState);
      // updated institution for db context
      EducationalInstitution resultInstitution = _mapper.Map(institutionToPatch, institution);
      if (!resultInstitution.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received education data is invalid");
        return BadRequest(ModelState);
      }
      // does nothing for current implementation, but it should be called because under _repository may be another implementation
      _repository.UpdateInstitution(resultInstitution);
      _repository.SaveChanges();
      return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult<InstitutionReadDto> DeleteInstitution(int id)
    {
      EducationalInstitution institution = _repository.GetInstitutionById(id);
      if (institution == null)
      {
        return NotFound();
      }
      _repository.DeleteInstitution(institution);
      _repository.SaveChanges();
      return Ok(_mapper.Map<InstitutionReadDto>(institution));
    }

    private IEducationRepository _repository;
    private IMapper _mapper;
  }
}
