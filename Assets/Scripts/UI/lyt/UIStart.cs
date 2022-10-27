using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    public GameObject start;
    public GameObject loadFirst;

    public void closeGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void skip()
    {
        start.SetActive(true);
        loadFirst.SetActive(false);
    }
}
