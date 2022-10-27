using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class BackAttackDeployer : SkillDeployer
    {
        GameObject boss;
        private void Start()
        {
            DeploySkill();
        }
        public override void DeploySkill()
        {
            boss = GameObject.FindGameObjectWithTag("Enemy");
            StartCoroutine(wait());
            Debug.Log("old" + SkillData.owner.transform.position);
            Destroy(gameObject, 2f);
        }

        private IEnumerator wait()
        {
            yield return new WaitForSeconds(0.5f);
            if(boss.transform.position.x > 30f || boss.transform.position.x < -30f)
                SkillData.owner.transform.position = new Vector3(0, SkillData.owner.transform.position.y, SkillData.owner.transform.position.z);
            else
                SkillData.owner.transform.position = new Vector3(boss.transform.position.x + boss.transform.localScale.x/2 + 4, SkillData.owner.transform.position.y, SkillData.owner.transform.position.z);
            //Debug.Log("new" + new Vector3(boss.transform.position.x + boss.transform.localScale.x, SkillData.owner.transform.position.y, SkillData.owner.transform.position.z));
        }
    }
}
