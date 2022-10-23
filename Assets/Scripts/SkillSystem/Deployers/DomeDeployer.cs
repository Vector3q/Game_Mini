using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class DomeDeployer : SkillDeployer
    {
        float durationtime = 0.2f;

        private void Start()
        {
            DeploySkill();
            
        }
        private void Update()
        {
            Vector3 playerPos = SkillData.owner.transform.position;
            gameObject.transform.position = new Vector3(playerPos.x, playerPos.y + 1.82f, playerPos.z);
            if (Input.GetKey(KeyCode.I))
            {
                return;
            }

            Destroy(gameObject);
        }
        public override void DeploySkill()
        {
            Destroy(gameObject, 3.2f);
        }

    }
}
