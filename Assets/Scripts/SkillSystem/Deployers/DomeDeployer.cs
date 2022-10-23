using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class DomeDeployer : SkillDeployer
    {

        private void Start()
        {
            DeploySkill();
        }
        private void Update()
        {
            Vector3 playerPos = SkillData.owner.transform.position;
            gameObject.transform.position = new Vector3(playerPos.x, playerPos.y + 1.82f, playerPos.z);
            
        }
        public override void DeploySkill()
        {
            PlayerController.isSkilling = true;
            StartCoroutine(wait());
            Destroy(gameObject, 3.4f);
        }
        private IEnumerator wait()
        {
            yield return new WaitForSeconds(0.4f);
            PlayerController.isSkilling = false;
        }
    }
}
