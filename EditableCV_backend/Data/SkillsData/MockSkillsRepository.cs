using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.Skills
{
  public class MockSkillsRepository : ISkillsRepository
  {
    public MockSkillsRepository()
    {
      _skills = new List<Skill>()
      {
        new Skill()
        {
          Id = 1,
          Name = "Name 1",
          Description = "Description 1",
        },
        new Skill()
        {
          Id = 2,
          Name = "Name 2",
          Description = "Description 2",
        },
      };
      SaveChanges();
    }
    public void CreateSkill(Skill skill)
    {
      _skills.Add(skill);
    }

    public void DeleteSkill(Skill skill)
    {
      _skills.Remove(skill);
    }

    public IEnumerable<Skill> GetAllSkills()
    {
      return new List<Skill>(_savedSkills);
    }

    public Skill GetSkillById(int id)
    {
      return _savedSkills.FirstOrDefault(skill => skill.Id == id);
    }

    public bool SaveChanges()
    {
      _savedSkills = new List<Skill>(_skills);
      return true;
    }

    public void UpdateSkill(Skill skill)
    {
      var foundSkill = _skills.Find(item => item.Id == skill.Id);
      int index = _skills.IndexOf(foundSkill);
      _skills[index] = new Skill(skill);
    }
    public List<Skill> _skills;
    public List<Skill> _savedSkills;
  }
}
