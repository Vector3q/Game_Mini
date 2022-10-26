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
        Vector3 originalTrans;
        private void Start()
        {
            originalTrans = gameObject.transform.position;
            gameObject.transform.position = new Vector3(originalTrans.x, originalTrans.y + 0.5f, originalTrans.z);
            
            DeploySkill();
        }
        public override void DeploySkill()
        {
            Destroy(gameObject, 5f);
            StartCoroutine(waitForBoom());
        }

        public IEnumerator waitForBoom()
        {
            yield return new WaitForSeconds(5f);
            //���Ŷ���

            //�ȴ�ָ��֡��

            //����˺�
        }
    }
}