using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class SkillDeployer : MonoBehaviour
    {
        private SkillData skillData;
        public SkillData SkillData
        {
            get
            {
                return skillData;
            }
            set
            {
                skillData = value;
            }
        }
        private void InitDeployer()
        {

        }
    }
}
