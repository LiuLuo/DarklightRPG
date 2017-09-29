using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {


    private bool isAnyKeyDown = false;

    private GameObject buttonContainer;
    // Use this for initialization
    void Start() {
        buttonContainer = this.transform.parent.Find("buttonContainer").gameObject;

    }

    // Update is called once per frame
    void Update() {
        //按下任意键显示进入游戏窗口
        if (isAnyKeyDown == false)
        {
            if (Input.anyKey)
            {

                ShowButton();
            }
        }
    }

    void ShowButton()
    {
        this.gameObject.SetActive(false);
        buttonContainer.SetActive(true);
        isAnyKeyDown = true;
    }
}
