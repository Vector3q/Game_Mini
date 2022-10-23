using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    string str;
    Text tex;
    int i = 0;   //调整这个可以调整出现的速度
    int index = 0;
    string str1 = "";
    bool ison = true;

    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<Text>();
        str = tex.text;
        tex.text = "";
        i = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (ison)
        {
            i -= 1;
            if (i <= 0)
            {
                if (index >= str.Length)
                {
                    ison = false;
                    return;
                }
                str1 = str1 + str[index].ToString();
                tex.text = str1;
                index += 1;
                i = 15;
            }
        }

    }


}
