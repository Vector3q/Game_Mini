using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class RoitDeployer : SkillDeployer
    {
        float timer;
        bool flag = false;
        private void Start()
        {
            DeploySkill();
        }
        private void Update()
        {
            if(flag)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, SkillData.owner.transform.position.y + (3 + 10 * timer), gameObject.transform.position.z);
            }
            timer += 0.01f;
            Debug.Log(timer);
        }
        public override void DeploySkill()
        {
            
            gameObject.transform.position = new Vector3(SkillData.owner.transform.position.x, SkillData.owner.transform.position.y - 10f, SkillData.owner.transform.position.z);
            StartCoroutine(wait());
            Destroy(gameObject, 3f);    
        }

        private IEnumerator wait()
        {
            
            yield return new WaitForSeconds(0.4f);
            flag = true;
            gameObject.transform.position = new Vector3(SkillData.owner.transform.position.x + (SkillData.owner.transform.localScale.x/1.4f) * 1f, SkillData.owner.transform.position.y + 3f, SkillData.owner.transform.position.z);
            timer = 0;
        }
    }
}
