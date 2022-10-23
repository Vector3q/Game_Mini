using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Explode : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        var position = gameObject.transform.position;
        gameObject.transform.position = new Vector3(position.x, position.y - speed, position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            Destroy(gameObject);
    }
}
