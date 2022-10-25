using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 打中Boss，相机震动
/// </summary>
public class ScreenShake : MonoBehaviour
{
    public float shake;
    public float setShake;
    Vector3 originalPos;
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    private void Update()
    {
        originalPos = gameObject.transform.position;
    }


    IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(0.33f);
        while (shake >= 0.5f)
        {
            transform.position = new Vector3(
            UnityEngine.Random.Range(0f, shake * 2f) - shake + originalPos.x,
            UnityEngine.Random.Range(0f, shake * 1f) + shake + originalPos.y,
            originalPos.z);
            shake = shake / 1.05f;
            yield return null;
        }
        shake = 0;
        transform.position = originalPos;
        yield return null;
    }
    public void CallShake()
    {
        shake = setShake;
        
        StartCoroutine(CameraShake());
    }
}