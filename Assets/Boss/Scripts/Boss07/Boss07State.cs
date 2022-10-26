using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss07State : MonoBehaviour
{
    public static int HP;
    public static Vector2[] target;
    public static int index = 0;
    void Start()
    {
        target = new Vector2[2];
        target[0] = new Vector2(-30,5);
        target[1] = new Vector2(30, 5);
        HP = 5;
    }
}
