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
            Destroy(gameObject, 1.5f);
        }
    }
}