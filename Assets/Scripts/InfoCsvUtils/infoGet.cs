using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoGet : MonoBehaviour
{
    public List<GameObject> bossObjs;
    public GameObject bossImage;

    [Header("Debug")]
    public bool DebugSingeBoss = false;
    public int DebugWhichBoss = 0;
    public bool DebugBossInorder = false;

    static List<List<string>> bosslist = new List<List<string>>(); 
    static List<List<string>> information = new List<List<string>>();
    static List<List<string>> lyrics = new List<List<string>>();
    static List<int> bossRandomSeq = new List<int>();

    public static int curStage = 0;

    void OnEnable()
    {
        bosslist = CSVUtils.ParseCSV("bosslist", 1);
        information = CSVUtils.ParseCSV("information", 1);
        lyrics = CSVUtils.ParseCSV("lyrics", 1);

        BossSeqInit();
    }

    void Start()
    {

    }

    public void BossSeqInit()
    {
        bossRandomSeq = getRandomSeq(bossObjs.Count);
        curStage = 0;
    }

    /// <summary>
    /// 获取游戏开始/胜利后加载界面文案
    /// </summary>
    public string getLoadInfo()
    {
        List<string> startTexts = CSVUtils.GetDataArray<string>(lyrics[0][1], '#');
        List<int> randomID = getRandomSeq(startTexts.Count);
        Debug.Log("随机到的开始/切换界面文案是：" + startTexts[randomID[0]]);
        return startTexts[randomID[0]];
    }

    /// <summary>
    /// 获取死亡时界面加载文案
    /// </summary>
    public string getLossInfo()
    {
        List<string> dieTexts = CSVUtils.GetDataArray<string>(lyrics[1][1], '#');
        List<int> randomID = getRandomSeq(dieTexts.Count);
        Debug.Log("随机到的死亡界面文案是：" + dieTexts[randomID[0]]);
        return dieTexts[randomID[0]];
    }

    public void battleStart()
    {
        Instantiate(bossObjs[bossRandomSeq[curStage]]);
        if (++curStage >= bossObjs.Count)
        {
            curStage = 0;
        }
    }

    /// <summary>
    /// 获取当前boss名字
    /// </summary>
    public string getBossName()
    {
        string name = bosslist[bossRandomSeq[curStage]][2];
        Debug.Log("该Boss的名字是：" + name);
        return name;
    }

    public void refreshBossImage()
    {
        bossImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("BossPic/boss" + (bossRandomSeq[curStage]+1));
    }

    /// <summary>
    /// 获取一次boss信息（自动增加关卡数）
    /// </summary>
    public List<string> getBossInfo()
    {
        //Debug.Log("boss数组："+bossRandomSeq.Count);
        //Debug.Log("curStage"+curStage);

        List<string> bossInfo = getOneBossInfo(curStage);

        return bossInfo;
    }

    #region private Functions
    /// <summary>
    /// 获取指定关卡的boss信息
    /// </summary>
    /// <param name="stage">获取第几关（取值1-7）的boss信息</param>
    private List<string> getOneBossInfo(int stage)
    {
        Debug.Log("当前是第"+(stage+1)+"关，关卡随机到的BOSS是<B00"+(bossRandomSeq[stage]+1)+">");
        List<string> bossInfo = parseBossInfo(bossRandomSeq[stage]+1);
        Debug.Log("该BOSS的第一条信息是：" + bossInfo[0]);
        Debug.Log("该BOSS的第二条信息是：" + bossInfo[1]);
        return bossInfo;
    }

    /// 获取指定编号boss的信息
    private List<string> parseBossInfo(int id)
    {
        List<string> bossInfo = new List<string>();

        List<int> keyNums = parseBossKeys(id - 1);

        foreach (int keyNum in keyNums)
        {
            //Debug.Log(keyNum);

            List<string> lines = parseLines(keyNum);

            List<int> randomID = getRandomSeq(lines.Count);

            bossInfo.Add(lines[randomID[0]]);


        }
        return bossInfo;
    }

    private List<int> parseBossKeys(int id)
    {

        return CSVUtils.GetDataArray<int>(bosslist[id][1], '#');        
    }

    private List<string> parseLines(int keyNum)
    {
        List<string> lines = new List<string>();

        return CSVUtils.GetDataArray<string>(information[keyNum-1][1], '#');
    }


    /// <summary>
    /// 获取指定整数范围内随机序列
    /// </summary>
    /// <param name="count">随机范围</param>

    private List<int> getRandomSeq(int count)
    {
        List<int> result = new List<int>();
        List<int> seq = new List<int>();

        for (int i = 0; i < count; i++)
        {
            seq.Add(i);
        }

        int r;
        while (seq.Count > 0)
        {
            r = UnityEngine.Random.Range(0, seq.Count);
            result.Add(seq[r]);
            seq.Remove(seq[r]);
        }
        return result;
    }
    #endregion

    #region Debug
    public void Test()
    {
        if (DebugSingeBoss)
        {
            for (int i = 0; i < bossObjs.Count; ++i)
            {
                bossRandomSeq[i] = DebugWhichBoss;
            }
        }

        if (DebugBossInorder)
        {
            for (int i = 0; i < bossObjs.Count; i++)
            {
                bossRandomSeq[i] = i;
            }
        }
    }

    #endregion
}
