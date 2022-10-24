using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Skill
{
    public class FlyDeployer : SkillDeployer
    {
        GameObject player;
        private void Start()
        {
            player = SkillData.owner;
            DeploySkill();

        }
        public override void DeploySkill()
        {
            Destroy(gameObject,2.0f);
            if (!player.GetComponent<PlayerController>().isOnGround)
            {
                player.GetComponent<PlayerController>().fallGravityScale = 0.5f;
                StartCoroutine(wait());
            }
        }
        private IEnumerator wait()
        {
            yield return new WaitForSeconds(1.6f);
            player.GetComponent<PlayerController>().fallGravityScale = 12f;
            Destroy(gameObject);
        }
    }

}