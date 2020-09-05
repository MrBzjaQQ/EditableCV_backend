using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.Skills;
using EditableCV_backend.DataTransferObjects.SkillDto;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/skills")]
  [ApiController]
  public class SkillsController : ControllerBase
  {
    public SkillsController(ISkillsRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SkillReadDto>> GetAllSkills()
    {
      var skills = _repository.GetAllSkills();
      return Ok(_mapper.Map<IEnumerable<SkillReadDto>>(skills));
    }

    [HttpGet("{id}", Name="GetSkillById")]
    public ActionResult<SkillReadDto> GetSkillById(int id)
    {
      var skill = _repository.GetSkillById(id);
      if (skill == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<SkillReadDto>(skill));
    }

    [HttpPost]
    public ActionResult<SkillReadDto> PostSkill(SkillCreateDto skillCreateDto)
    {
      Skill skill = _mapper.Map<Skill>(skillCreateDto);
      if (!skill.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received skill data is invalid");
        return BadRequest(ModelState);
      }
      _repository.CreateSkill(skill);
      _repository.SaveChanges();
      SkillReadDto skillReadDto = _mapper.Map<SkillReadDto>(skill);
      return CreatedAtRoute(nameof(GetSkillById), new { Id = skillReadDto.Id }, skillReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult PutSkill(int id, SkillUpdateDto skillUpdateDto)
    {
      Skill skillFromRepo = _repository.GetSkillById(id);
      if (skillFromRepo == null)
      {
        return NotFound();
      }
      _mapper.Map(skillUpdateDto, skillFromRepo);
      _repository.UpdateSkill(skillFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchSkill(int id, JsonPatchDocument<SkillUpdateDto> patchDocument)
    {
      Skill skillFromRepo = _repository.GetSkillById(id);
      if (skillFromRepo == null)
      {
        return NotFound();
      }
      SkillUpdateDto skillUpdateDto = _mapper.Map<SkillUpdateDto>(skillFromRepo);
      patchDocument.ApplyTo(skillUpdateDto, ModelState);
      Skill skill = _mapper.Map(skillUpdateDto, skillFromRepo);
      if (!skillFromRepo.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received skill data is invalid");
        return BadRequest(ModelState);
      }
      _repository.UpdateSkill(skillFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<SkillReadDto> DeleteSkill(int id)
    {
      Skill skillFromRepo = _repository.GetSkillById(id);
      if (skillFromRepo == null)
      {
        return NotFound();
      }
      _repository.DeleteSkill(skillFromRepo);
      _repository.SaveChanges();
      return Ok(_mapper.Map<SkillReadDto>(skillFromRepo));
    }

    private ISkillsRepository _repository;
    private IMapper _mapper;
  }
}
