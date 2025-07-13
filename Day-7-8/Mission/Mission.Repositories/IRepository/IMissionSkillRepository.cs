using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.MissionSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepository
{
    public interface IMissionSkillRepository
    {
        Task AddMissionSkillsAsync(UpsertMissionSkillRequestModel model);
        Task<List<MissionSkillListResponseModel>> GetMissionSkillListAsync();

        Task<MissionSkillListResponseModel?> GetMissionSkillByIdAsync(int missionskillId);

        Task<ResponseResult> UpdateMissionSkill(UpsertMissionSkillRequestModel model);

        Task<bool> DeleteMissionSkill(int id);
    }
}
