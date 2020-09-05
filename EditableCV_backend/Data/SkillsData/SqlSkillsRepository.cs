using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.Skills
{
  public class SqlSkillsRepository : ISkillsRepository
  {
    public SqlSkillsRepository(ResumeContext context)
    {
      _context = context;
    }
    public void CreateSkill(Skill skill)
    {
      _context.Skills.Add(skill);
    }

    public void DeleteSkill(Skill skill)
    {
      _context.Skills.Remove(skill);
    }

    public IEnumerable<Skill> GetAllSkills()
    {
      return _context.Skills.ToList();
    }

    public Skill GetSkillById(int id)
    {
      return _context.Skills.FirstOrDefault(skill => skill.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }

    public void UpdateSkill(Skill skill)
    {
      // Nothing here
    }

    private ResumeContext _context;
  }
}
