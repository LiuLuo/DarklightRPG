using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonContainer : MonoBehaviour{

    //1。数据保存和场景之间游戏数据传递使用PlayerPrefs
    //2.场景分类
        //2.1开始场景
        //2.2角色选择界面
        //2.3玩家游戏界面

    //加载新游戏
    public void OnNewGanme()
    {
        //加载2.2角色选择场景
        PlayerPrefs.SetInt("DataFromSave", 0);
    }

    //加载已有存档
    public void OnLoadGanme()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);//表示数据来自保存
        //加载2.3玩家游戏界面

    }


}
