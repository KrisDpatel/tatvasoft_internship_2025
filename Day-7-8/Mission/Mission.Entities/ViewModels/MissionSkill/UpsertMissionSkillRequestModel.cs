using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.ViewModels.MissionSkill
{
    public class UpsertMissionSkillRequestModel
    {
        public int Id { get; set; }
        public string SkillName { get; set; }

        public string Status { get; set; }

    }
}
