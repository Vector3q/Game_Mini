using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public interface IImpactEffect
    {
        void Execute(SkillDeployer deployer);
    }

}