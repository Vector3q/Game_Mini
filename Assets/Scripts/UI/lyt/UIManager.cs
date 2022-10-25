using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool bossStart = false;
    public infoGet info;

    public GameObject getinfo;
    public GameObject getskill;
    public GameObject load;
    public GameObject lose;
    private Text bossInfo;
    private Text loadInfo;
    private Text loseInfo;
    public Text bossName;

    public GameObject bloodBar;

    private void OnEnable()
    {
        GameEvents.current.OnBossDie += onPortalOpen;
        GameEvents.current.OnPlayerDie += onLoseShow;
    }

    private void Start()
    {
        bossInfo = getinfo.transform.Find("bossInfo").GetComponent<Text>();
        loadInfo = load.transform.Find("loadInfo").GetComponent<Text>();
        loseInfo = lose.transform.Find("loseInfo").GetComponent<Text>();

        List<string> bossInf = info.getBossInfo();
        bossInfo.text = bossInf[0] + '\n' + '\n' + bossInf[1];
        loadInfo.text = loadInfo.text = tooLongHandle(info.getLoadInfo())[0] + "\n" + tooLongHandle(info.getLoadInfo())[1] + "\n" + tooLongHandle(info.getLoadInfo())[2];
        loseInfo.text = info.getLossInfo();
        bossName.text = "击杀者：" + info.getBossName();
    }

    void OnDestroy()
    {
        GameEvents.current.OnBossDie -= onPortalOpen;
        GameEvents.current.OnPlayerDie -= onLoseShow;
    }

    #region PortalRise
    public Animator animator = null;
    private float risePortalLate = 1f; // boss死后多久升起传送门

    private void onPortalOpen()
    {
        Invoke(nameof(portalOpen), risePortalLate);
    }

    private void portalOpen()
    {
        animator.SetTrigger("DoorRise");
    }

    #endregion

    #region LoseShow
    private float showLoseDuration = 4f; // lose界面显示多长时间

    private void onLoseShow()
    {
        lose.SetActive(true);
        Invoke(nameof(LoseShow), showLoseDuration);
    }

    public GameObject Restart;
    public GameObject Quit;

    private void LoseShow()
    {
        Restart.SetActive(true);
        Quit.SetActive(true);
    }

    #endregion

    #region Button
    public void backButton()
    {
        getinfo.SetActive(false);
    }

    public void skillButton()
    {
        getinfo.SetActive(false);
        getskill.SetActive(true);
    }

    public void skillBackButton()
    {
        getskill.SetActive(false);
        getinfo.SetActive(true);
    }

    public void battleButton()
    {
        getskill.SetActive(false);
        bloodBar.SetActive(true);
        bossStart = true;
        info.battleStart();
    }

    public void restartButton()
    {
        SceneManager.LoadScene("Start_Scene");
    }

    public void quitButton()
    {
        Application.Quit();
    }
    #endregion

    private string[] tooLongHandle(string info)
    {
        string[] lines;
        lines = info.Split(new char[] { '*' });
        return lines;
    }
}
