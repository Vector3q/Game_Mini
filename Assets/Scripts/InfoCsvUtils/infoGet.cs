using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoGet : MonoBehaviour
{
    public List<GameObject> bossObjs;


    List<List<string>> bosslist = new List<List<string>>(); 
    List<List<string>> information = new List<List<string>>();
    List<List<string>> lyrics = new List<List<string>>();
    List<int> bossRandomSeq = new List<int>();

    public int curBossCount = 0;

    void OnEnable()
    {
        bosslist = CSVUtils.ParseCSV("bosslist", 1);
        information = CSVUtils.ParseCSV("information", 1);
        lyrics = CSVUtils.ParseCSV("lyrics", 1);

        bossRandomSeq = getRandomSeq(7);
    }

    void Start()
    {
        Debug.Log(getStartInfo());
        Debug.Log(getDieInfo());

        List<string> bossInfo1 = getBossInfo(2);
        Debug.Log(bossInfo1[0]);
        Debug.Log(bossInfo1[1]);
    }



    /// <summary>
    /// 获取游戏开始/胜利后加载界面文案
    /// </summary>
    public string getStartInfo()
    {

        List<string> startTexts = CSVUtils.GetDataArray<string>(lyrics[0][1], '#');
        List<int> randomID = getRandomSeq(startTexts.Count);
        return startTexts[randomID[0]];
    }

    /// <summary>
    /// 获取死亡时界面加载文案
    /// </summary>
    public string getDieInfo()
    {
        List<string> dieTexts = CSVUtils.GetDataArray<string>(lyrics[1][1], '#');
        List<int> randomID = getRandomSeq(dieTexts.Count);
        return dieTexts[randomID[0]];
    }

    /// <summary>
    /// 获取当前boss信息
    /// </summary>
    /// <param name="stage">当前是第几关</param>
    public List<string> getBossInfo(int stage)
    {
        
        //Debug.Log(bossRandomSeq[curBossCount]+1);
        List<string> bossInfo = parseBossInfo(bossRandomSeq[curBossCount]+1);
        return bossInfo;
    }



    /// 获取指定编号boss的信息
    public List<string> parseBossInfo(int id)
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


}
