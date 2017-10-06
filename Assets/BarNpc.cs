using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNpc : MonoBehaviour {

    public TweenPosition questTween;
    public bool isInTask = false;//任务状态表示
    public int killConut = 0;
    //private void OnMouseOver()//当鼠标位于Collider之上，会在每一帧调用
    //{
    //    print("11");
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        ShowQuest();
    //    }
    //}
    private void OnMouseDown()
    {
        ShowQuest();
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
    public void OnOkButtonClick()
    {

    }
    public void OnAcceptButtonClick()
    {

    }
    public void OnCancleButtonClick()
    {

    }
}
