using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Skill
{
    public abstract class IAttackSelector
    {
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <param name="data">��������</param>
        /// <param name="skillTF">�������ڶ����λ����Ϣ</param>
        /// <returns>������Ŀ��Transform����</returns>
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            Transform[] allTarget = this._getAllTargets(data);
            return this._filteringTargets(allTarget,data,skillTF);
        }

        /// <summary>
        /// ����tag��ȡ����Ŀ��
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected Transform[] _getAllTargets(SkillData data)
        {
            List<Transform> targets = new List<Transform>();
            foreach(string tag in data.attackTargetTags)
            {
                targets.AddRange(GameObject.FindGameObjectsWithTag(tag).Select(go => go.transform));
            }
            return targets.ToArray();
        }

        protected virtual Transform[] _filteringTargets(Transform[] allTargets, SkillData data, Transform skillTF)
        {
            return allTargets;
        }
    }
}