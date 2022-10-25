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
    private Text bossInfo1;
    private Text bossInfo2;
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
        bossInfo1 = getinfo.transform.Find("bossInfo1").GetComponent<Text>();
        bossInfo2 = getinfo.transform.Find("bossInfo2").GetComponent<Text>();
        loadInfo = load.transform.Find("loadInfo").GetComponent<Text>();
        loseInfo = lose.transform.Find("loseInfo").GetComponent<Text>();

        List<string> bossInfo = info.getBossInfo();
        bossInfo1.text = tooLongHandle(bossInfo[0])[0] + "\n" + tooLongHandle(bossInfo[0])[1] + '\n' + '\n' + tooLongHandle(bossInfo[1])[0] + "\n" + tooLongHandle(bossInfo[1])[1];
        loadInfo.text = info.getLoadInfo();
        loseInfo.text = info.getLossInfo();
        //bossName.text = "击杀者：" + info.getBossName();
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
    private float showLoseDuration = 5f; // lose界面显示多长时间

    private void onLoseShow()
    {
        lose.SetActive(true);
        Invoke(nameof(LoseShow), showLoseDuration);
    }

    private void LoseShow()
    {
        SceneManager.LoadScene("Start_Scene");
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
    #endregion

    private string[] tooLongHandle(string info)
    {
        string[] lines;
        lines = info.Split(new char[] { '*' });
        return lines;
    }
}
