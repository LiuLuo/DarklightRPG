using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNpc : Npc {

    public TweenPosition questTween;
    public UILabel dessLadbel;
    public GameObject acceptBtnGO;
    public GameObject okBtnGO;
    public GameObject cancelBtnGo;

    public bool isInTask = false;//任务状态表示
    public int killConut = 0;

    private PlayerStatus status;
    private void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    //private void OnMouseOver()//当鼠标位于Collider之上，会在每一帧调用  测试
    //{
    //    print("11");
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        ShowQuest();
    //    }
    //}
    private void OnMouseDown()
    {
        if (isInTask)
        {
            ShowTaskDest();
            ShowQuest();
        }
        else
        {
            ShowTaskProgress();
            ShowQuest();
        }
       
    }
    void ShowQuest()
    {
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();

    }
    void HideQuest()
    {
        questTween.PlayReverse();
    }
    public void OnCloseButtonClick()
    {
        HideQuest();
    }
    void ShowTaskDest()
    {
        dessLadbel.text = "任务:\n你已经杀死了" + killConut + "/只小野狼\n\n奖励:\n1000金币";
        okBtnGO.SetActive(true);
        acceptBtnGO.SetActive(false);
        cancelBtnGo.SetActive(false);
    }
    void ShowTaskProgress()
    {
        dessLadbel.text = "任务:\n杀死10只小野狼。\n\n奖励:\n1000金币。";
        okBtnGO.SetActive(false);
        acceptBtnGO.SetActive(true);
        cancelBtnGo.SetActive(true);
    }
    public void OnOkButtonClick()
    {
        print("11");
        if (killConut>=10)
        {
            status.GetConint(1000);
            killConut = 0;
            isInTask = false;
            HideQuest();
        }
        else
        {
            HideQuest();
        }

    }
    public void OnAcceptButtonClick()
    {
        isInTask = true;
        ShowTaskDest();
       
    }
    public void OnCancleButtonClick()
    {
     
       
        HideQuest();
    }
}
