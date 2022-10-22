using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public class BoomDeployer : SkillDeployer
    {
        //ը������Ķ���������
        Animator anim;
        Collider2D cd;
        bool isBoom;
        private void Start()
        {
            cd.gameObject.SetActive(false);
            isBoom = false;
            DeploySkill();
        }
        public override void DeploySkill()
        {
            StartCoroutine(waitForBoom());
        }

        public IEnumerator waitForBoom()
        {
            yield return new WaitForSeconds(2f);
            //���Ŷ���

            //�ȴ�ָ��֡��

            //����˺�
        }
    }
}