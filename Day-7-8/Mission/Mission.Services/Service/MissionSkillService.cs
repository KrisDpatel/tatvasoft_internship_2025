using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.MissionSkill;
using Mission.Repositories.IRepository;
using Mission.Repositories.Repository;
using Mission.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services.Service
{
    public class MissionSkillService(IMissionSkillRepository missionSkillRepository): IMissionSkillService
    {
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;

        public async Task AddMissionSkillsAsync(UpsertMissionSkillRequestModel model)
        {
            await _missionSkillRepository.AddMissionSkillsAsync(model);
            return;
        }

         public async Task<List<MissionSkillListResponseModel>> GetMissionSkillListAsync()
        {
            return await _missionSkillRepository.GetMissionSkillListAsync();
            
        }

        public async Task<MissionSkillListResponseModel?> GetMissionSkillByIdAsync(int missionskillId)
        {
            return await _missionSkillRepository.GetMissionSkillByIdAsync(missionskillId);
            
        }

        public async Task<ResponseResult> UpdateMissionSkill(UpsertMissionSkillRequestModel model)
        {
            return await _missionSkillRepository.UpdateMissionSkill(model);
        }

        public async Task<bool> DeleteMissionSkill(int id)
        {
            return await _missionSkillRepository.DeleteMissionSkill(id);
        }

    }
}
