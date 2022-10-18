using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public class DamageImapact : IImpactEffect
    {
        public void Execute(SkillDeployer deployer)
        {
            foreach(Transform target in deployer.SkillData.attackTargets)
            {
                //target.GetComponent //µôÑª
                deployer.Destroy();
                return;
            }
        }
    }
}
