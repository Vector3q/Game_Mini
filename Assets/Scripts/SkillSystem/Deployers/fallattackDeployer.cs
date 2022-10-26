using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public class fallattackDeployer : SkillDeployer
    {
        GameObject player;
        private void Start()
        {
            player = SkillData.owner;
            DeploySkill();
        }
        public override void DeploySkill()
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
            player.GetComponent<PlayerController>().maxJumpVelocity = 80f;
            player.GetComponent<PlayerController>().maxFallVelocity = 40f;
            player.GetComponent<PlayerController>().jumpGravityScale = 40f;
            player.GetComponent<PlayerController>().fallGravityScale = 40f;
            StartCoroutine(wait());
            Destroy(gameObject, 2f);
        }
        private IEnumerator wait()
        {
            yield return new WaitForSeconds(0.6f);
            player.GetComponent<PlayerController>().maxJumpVelocity = 25f;
            player.GetComponent<PlayerController>().maxFallVelocity = 25f;
            player.GetComponent<PlayerController>().jumpGravityScale = 5f;
            player.GetComponent<PlayerController>().fallGravityScale = 12f;
            Destroy(gameObject);
        }
    }
}