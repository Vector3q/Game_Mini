using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDebug : MonoBehaviour
{
    public UIManager uiM;
    public infoGet inf;
    public GameObject debugPanel;

    public void OpenPanel()
    {
        debugPanel.SetActive(true);
    }

    public void DebugBoss1()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 0;
        inf.Test();
        uiM.Test();
    }

    public void DebugBoss2()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 1;
        inf.Test();
        uiM.Test();
    }

    public void DebugBoss3()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 2;
        inf.Test();
        uiM.Test();
    }

    public void DebugBoss4()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 3;
        inf.Test();
        uiM.Test();
    }

    public void DebugBoss5()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 4;
        inf.Test();
        uiM.Test();
    }

    public void DebugBoss6()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 5;
        inf.Test();
        uiM.Test();
    }

    public void DebugBoss7()
    {
        inf.DebugSingeBoss = true;
        inf.DebugWhichBoss = 6;
        inf.Test();
        uiM.Test();
    }

    public void DebugOrder()
    {
        inf.DebugBossInorder = true;
        inf.Test();
        uiM.Test();
    }
}
