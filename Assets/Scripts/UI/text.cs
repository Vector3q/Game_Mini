using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class text : MonoBehaviour
{
    string str;
    Text tex;
    int i = 0;
    int index = 0;
    string str1 = "";
    bool ison = true;

    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<Text>();
        str = tex.text;
        tex.text = "";
        i = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ison)
        {
            i -= 1;
            if (i <= 0)
            {
                if (index >= str.Length)
                {
                    ison = false;
                    //Invoke("Scenechange", 1);
                    return;
                }
                str1 = str1 + str[index].ToString();
                tex.text = str1;
                index += 1;
                i = 4;
            }
        }

    }
}
