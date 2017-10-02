using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Moving,
    Idle
}

public class PlayerMove : MonoBehaviour {
    public float speed;
    public PlayerState state = PlayerState.Idle;
    private PlayerDir dir;
    private CharacterController controller;

    public   bool isMoving = false;
	// Use this for initialization
	void Start () {
        //获取鼠标点击位置
        dir = this.GetComponent<PlayerDir>();
        //使用Unity角色控制器控制移动
        controller = this.GetComponent<CharacterController>();
	}
	void Update () {
        //计算人物位置与鼠标点击位置距离
        float distance = Vector3.Distance( dir.targetPosition,transform.position);
        if (distance>0.1f)//与目标位置距离，容错率
        {
            isMoving = true;//正在移动
            state = PlayerState.Moving;//动画枚举类型
            controller.SimpleMove(transform .forward*speed);//使用角色控制器进行移动
           // Debug.Log(distance.ToString());//调试
        }
        else
        {
            isMoving = false;//移动结束
            state = PlayerState.Idle;//待机动画枚举类型
        }
	}
}
