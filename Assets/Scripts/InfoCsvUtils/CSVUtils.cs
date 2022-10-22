using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// CSV工具
/// </summary>
public static class CSVUtils
{
    const string CSVDir = "Text/";//CSV目录

    /// <summary>
    /// 解析CSV
    /// </summary>
    public static List<List<string>> ParseCSV(string path, int beginParseRow)
    {
        List<List<string>> dataList = new List<List<string>>();

        var ta = Resources.Load<TextAsset>(CSVDir + path);
        if (ta == null)
        {
            Debug.LogError("CSV文件不存在：" + CSVDir + path);
            return dataList;
        }
        string[] rowCollection = ta.text.Split('\n');
        for (int row = beginParseRow; row < rowCollection.Length; row++)
        {
            if (string.IsNullOrEmpty(rowCollection[row])) continue;
            rowCollection[row] = rowCollection[row].Replace("\r", "");
            string[] colCollection = rowCollection[row].Split(',');

            List<string> tempList = new List<string>();
            for (int col = 0; col < colCollection.Length; col++)
            {
                tempList.Add(colCollection[col]);
            }
            dataList.Add(tempList);
        }
        return dataList;
    }

    /// <summary>
    /// 得到数据数组
    /// </summary>
    public static List<T> GetDataArray<T>(string dataStr, char separator)
    {
        List<T> dataList = new List<T>();
        string[] dataArray = dataStr.Split(separator);
        for (int i = 0; i < dataArray.Length; i++)
        {
            if (string.IsNullOrEmpty(dataArray[i])) continue;
            dataArray[i] = dataArray[i].Replace("\r", "");
            try
            {
                T data = (T)Convert.ChangeType(dataArray[i], typeof(T));
                dataList.Add(data);
            }
            catch
            {
                Debug.LogError($"string类型转{typeof(T)}失败：{dataArray[i]}");
            }
        }
        return dataList;
    }

    /// <summary>
    /// 固定数组中的不重复随机
    /// </summary>
    /// <param name="nums">数组</param>
    /// <param name="count">要随机的个数</param>
    /// <returns></returns>
    public static List<T> GetRandom<T>(this List<T> nums, int count)
    {
        if (count > nums.Count)
        {
            Debug.LogError("要取的个数大于数组长度！");
            return null;
        }

        List<T> result = new List<T>();
        List<int> id = new List<int>();

        for (int i = 0; i < nums.Count; i++)
        {
            id.Add(i);
        }

        int r;
        while (id.Count > nums.Count - count)
        {
            r = UnityEngine.Random.Range(0, id.Count);
            result.Add(nums[id[r]]);
            id.Remove(id[r]);
        }
        return (result);
    }
}