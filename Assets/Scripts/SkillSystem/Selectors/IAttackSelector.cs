using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game.Skill
{
    public abstract class IAttackSelector
    {
        /// <summary>
        /// 搜索目标
        /// </summary>
        /// <param name="data">技能数据</param>
        /// <param name="skillTF">技能所在对象的位置信息</param>
        /// <returns>搜索到目标Transform数组</returns>
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            Transform[] allTarget = this._getAllTargets(data);
            return this._filteringTargets(allTarget,data,skillTF);
        }

        /// <summary>
        /// 根据tag获取所有目标
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