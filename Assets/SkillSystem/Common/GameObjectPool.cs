using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public interface IResetable
    {
        void OnReset();
    }

    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {
        private Dictionary<string, List<GameObject>> cache;

        public override void Init()
        {
            base.Init();
            cache = new Dictionary<string, List<GameObject>>();
        }
        public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rot)
        {
            GameObject go = FindUsableObject(key);

            if (go == null)
            {
                go = AddObject(key, prefab);
            }

            go.transform.position = pos;
            go.transform.rotation = rot;
            go.SetActive(true);
            foreach(var item in go.GetComponents<IResetable>())
            {
                item.OnReset();
            }
            return go;
        }

        private GameObject AddObject(string key, GameObject prefab)
        {
            GameObject go = Instantiate(prefab);

            if (!cache.ContainsKey(key))
                cache.Add(key, new List<GameObject>());
            cache[key].Add(go);
            return go;
        }

        private GameObject FindUsableObject(string key)
        {
            if (cache.ContainsKey(key))
                return cache[key].Find(g => !g.activeInHierarchy);
            return null;
        }

        public void CollectObject(GameObject go, float delay = 0)
        {
            StartCoroutine(CollectObjectDelay(go, delay));
        }
        private IEnumerator CollectObjectDelay(GameObject go, float delay)
        {
            yield return new WaitForSeconds(delay);
            go.SetActive(false);
        }

        public void Clear(string key)
        {
            for(int i = cache[key].Count - 1; i>=0; i--)
            {
                Destroy(cache[key][i]);
            }

            cache.Remove(key);
        }

        public void ClearAll()
        {
            //foreach(var key in cache.Keys)
            //{
            //    Clear(key);
            //}
            List<string> KeyList = new List<string>(cache.Keys);
            foreach(var key in KeyList)
            {
                Clear(key);
                
            }
        }
    }

    public class test
    {
        private void a()
        {
            
        }
    }
}
