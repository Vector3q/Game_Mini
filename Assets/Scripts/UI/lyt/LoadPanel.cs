using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPanel : MonoBehaviour
{
    private float duration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(winLoad), duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void winLoad()
    {
        Debug.Log("——————————————————");
        SceneManager.LoadScene("MainScene");
    }
}
