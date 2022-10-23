using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToU : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((gameObject.transform.position.x > target.transform.position.x ? 1 : -1), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
