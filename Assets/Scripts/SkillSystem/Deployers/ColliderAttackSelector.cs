using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Skill
{
    public class ColliderAttackSelector : IAttackSelector
    {
        protected override Transform[] _filteringTargets(Transform[] allTargets, SkillData data, Transform skillTF)
        {
            return allTargets.Where(target => {
                Collider2D collider = skillTF.GetComponent<Collider2D>();
                return collider.IsTouching(target.GetComponent<Collider2D>());
            }).ToArray();
        }
    }
}
