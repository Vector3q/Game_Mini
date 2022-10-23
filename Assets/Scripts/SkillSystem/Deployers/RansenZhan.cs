using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class RansenZhan : SkillDeployer
    {
        private void Start()
        {
            PlayerController.isSkilling = true;
            DeploySkill();
        }
        public override void DeploySkill()
        {
            StartCoroutine(wait());
            //Debug.Log("ÂÝÐýÕ¶");
            Destroy(gameObject, 1f);
            
            //Debug.Log("ÂÝÐýÕ¶");
        }
        private IEnumerator wait()
        {
            yield return new WaitForSeconds(0.95f);
            PlayerController.isSkilling = false;
        }

    }
}