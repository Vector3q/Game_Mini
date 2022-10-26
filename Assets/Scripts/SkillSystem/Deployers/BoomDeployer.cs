using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public class BoomDeployer : SkillDeployer
    {
        //炸弹物体的动画控制器
        Animator anim;
        Collider2D cd;
        Vector3 originalTrans;
        private void Start()
        {
            originalTrans = gameObject.transform.position;
            gameObject.transform.position = new Vector3(originalTrans.x, originalTrans.y + 0.5f, originalTrans.z);
            
            DeploySkill();
        }
        public override void DeploySkill()
        {
            Destroy(gameObject, 2.8f);
        }
    }
}