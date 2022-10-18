using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class RansenZhan : SkillDeployer
    {
        private void Start()
        {
            DeploySkill();
        }
        public override void DeploySkill()
        {
            Debug.Log(11);
            Destroy(gameObject, 0.5f);
            Debug.Log(11);
        }

    }
}