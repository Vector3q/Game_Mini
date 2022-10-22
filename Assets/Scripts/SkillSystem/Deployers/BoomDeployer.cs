using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public class BoomDeployer : SkillDeployer
    {
        bool isBoom;
        private void Start()
        {
            isBoom = false;
            DeploySkill();
        }
        public override void DeploySkill()
        {
            
        }

        public IEnumerator waitForBoom()
        {
            yield return new WaitForSeconds(2f);
        }
    }
}