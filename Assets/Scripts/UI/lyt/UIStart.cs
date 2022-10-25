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
        start.SetActive(false);
        loadFirst.SetActive(true);
    }
}
