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
            player.GetComponent<PlayerController>().fallGravityScale = 0.5f;
            StartCoroutine(wait());
        }
        private IEnumerator wait()
        {
            yield return new WaitForSeconds(2f);
            player.GetComponent<PlayerController>().fallGravityScale = 12f;
            Destroy(gameObject);
        }
    }

}