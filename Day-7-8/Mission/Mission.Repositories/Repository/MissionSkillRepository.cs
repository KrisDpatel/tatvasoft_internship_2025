using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.MissionSkill;
using Mission.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.Repository
{
    public class MissionSkillRepository(MissionDbContext dbcontext):IMissionSkillRepository
    {
        private readonly MissionDbContext _dbContext = dbcontext;

        public async Task AddMissionSkillsAsync(UpsertMissionSkillRequestModel model)
        {
            var missionSkill = new MissionSkill()
            {
                SkillName = model.SkillName,
                 Status = model.Status,
            };

            _dbContext.MissionSkills.Add(missionSkill);
            await _dbContext.SaveChangesAsync();

        } 

        public async Task<List<MissionSkillListResponseModel>> GetMissionSkillListAsync()
        {
            return await _dbContext.MissionSkills.Select(m=> new MissionSkillListResponseModel()
            {
                Id = m.Id,
                SkillName = m.SkillName,
                Status = m.Status
            }).ToListAsync();
        }

        public async Task<MissionSkillListResponseModel?> GetMissionSkillByIdAsync(int missionskillId)
        {
            var missionskill = _dbContext.MissionSkills.Find(missionskillId);
            if (missionskill == null)
            {
                return null;
            }

            return new MissionSkillListResponseModel()
            {
                Id = missionskill.Id,
                SkillName = missionskill.SkillName,
                Status = missionskill.Status,
            };

        }

        public async Task<ResponseResult> UpdateMissionSkill(UpsertMissionSkillRequestModel model)
        {
            var missionSkill = _dbContext.MissionSkills.Find(model.Id);
            var result = new ResponseResult();

            if(missionSkill == null)
            {
                result.Message = "mission not found";
                return result;
            }

            
                missionSkill.SkillName = model.SkillName;
                missionSkill.Status = model.Status;

            result.Message = "updated";
            result.Result = ResponseStatus.Success;

            _dbContext.MissionSkills.Update(missionSkill);
            await _dbContext.SaveChangesAsync();
            return result;

        }

       public async Task<bool> DeleteMissionSkill(int id)
        {
            var missionSkill = _dbContext.MissionSkills.Find(id);

            if(missionSkill == null)
            {
                return false;
            }

            _dbContext.MissionSkills.Remove(missionSkill);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
