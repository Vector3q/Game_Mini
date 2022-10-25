using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class RoitDeployer : SkillDeployer
    {
        private void Start()
        {
            
            DeploySkill();
        }
        private void Update()
        {
            gameObject.transform.position = new Vector3(SkillData.owner.transform.position.x+1f, SkillData.owner.transform.position.y+3f, SkillData.owner.transform.position.z);
        }
        public override void DeploySkill()
        {
            Destroy(gameObject, 1f);
        }
    }
}
