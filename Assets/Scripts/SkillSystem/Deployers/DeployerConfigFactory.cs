using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Skill
{
    public class DeployerConfigFactory
    {
        public static IAttackSelector CreateAttackSelector(SkillData data)
        {
            return _createObject<IAttackSelector>("Skill." + data.selectorType + "AttackSelector");
        }

        public static List<IImpactEffect> CreateImpactEffect(SkillData data)
        {
            List<IImpactEffect> result = new List<IImpactEffect>();
            foreach (string impact in data.impactType)
            {
                result.Add(_createObject<IImpactEffect>("Skill." + impact + "Impact"));
            }
            return result;
        }

        private static T _createObject<T>(string className) where T : class
        {
            Type type = Type.GetType(className);
            return Activator.CreateInstance(type) as T;
        }
    }
}
