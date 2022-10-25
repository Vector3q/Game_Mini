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

    private void Start()
    {
        bossInfo1 = getinfo.transform.Find("bossInfo1").GetComponent<Text>();
        bossInfo2 = getinfo.transform.Find("bossInfo2").GetComponent<Text>();
        loadInfo = load.transform.Find("loadInfo").GetComponent<Text>();
        loseInfo = lose.transform.Find("loseInfo").GetComponent<Text>();

        List<string> bossInfo = info.getBossInfo();
        bossInfo1.text = bossInfo[0];
        bossInfo2.text = bossInfo[1];
        loadInfo.text = info.getLoadInfo();
        loseInfo.text = info.getLossInfo();
        bossName.text = "击杀者：" + info.getBossName();

        GameEvents.current.onBossDie += onPortalOpen;
        GameEvents.current.onPlayerDie += onLoseShow;
    }

    void OnDestroy()
    {
        GameEvents.current.onBossDie -= onPortalOpen;
        GameEvents.current.onPlayerDie -= onLoseShow;
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
        bossStart = true;
        info.battleStart();
    }
    #endregion
}
