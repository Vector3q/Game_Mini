using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Skill
{
    public class CharacterSkillManager : MonoBehaviour
    {
        [HideInInspector]
        public SkillData[] skills; // �����б�
        public Animator anima = null;

        private void Start()
        {
            foreach(SkillData skill in skills)
            {
                this.InitSkill(skill);
            }
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="data"></param>
        private void InitSkill(SkillData data)
        {
            //prefabName --> skillPrefab
            data.skillPrefab = Resources.Load<GameObject>("Skill/" + data.prefabName);
            if(data.skillPrefab == null)
            {
                Debug.LogError("Skill prefab not found: " + data.prefabName);
                return;
            }
            data.owner = this.gameObject;
        }
        /// <summary>
        /// ���ݼ���ID��ȡ�������ݣ�����鼼���Ƿ����
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns>�������ݣ��������������ؿ�</returns>
        public SkillData PrepareSkill(int id)
        {
            SkillData data = this.skills.First(x => x.skillID == id);

            if(data == null)
            {
                Debug.LogError("Skill not found: " + id);
                return null;
            }

            if (data.coolRemain <= 0)
                return data;
            else
                return null;
        }

        /// <summary>
        /// ���ɼ���
        /// </summary>
        /// <param name="data">��������</param>
        public void GenerateSkill(SkillData data)
        {
            if(data == null)
            {
                Debug.LogError("Cannot generate null skill");
                return;
            }
            //��������Ԥ����
            GameObject skillGo = Instantiate(data.skillPrefab, this.transform.position, this.transform.rotation);

            //���ݼ�������
            SkillDeployer deployer = skillGo.GetComponent<SkillDeployer>();
            deployer.SkillData = data;

            //���ż��ܶ���
            if(data.animationName != "")
            {
                anima.SetTrigger(data.animationName);
            }

            //ִ�м���
            //

            //���ټ���
            

            //������ȴ
            StartCoroutine(CoolTimeDown(data));
        }

        /// <summary>
        /// ������ȴ
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IEnumerator CoolTimeDown(SkillData data)
        {
            data.coolRemain = data.coolTime;
            while (data.coolRemain > 0)
            {
                yield return new WaitForSeconds(0.02f);
                data.coolRemain -= 0.02f;
            }
        }
    }


}