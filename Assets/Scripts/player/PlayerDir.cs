using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour {

    public GameObject effect_click_prefab;
    private bool isMoving=false;
    public  Vector3 targetPosition = Vector3.zero;
    private PlayerMove playerMove;

 void Start()
    {
        targetPosition = transform.position;
        playerMove = this.GetComponent<PlayerMove>();
    }
    // Update is called once per frame
    void Update () {
        //点击发射射线检测碰撞事件
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);//将鼠标在屏幕点下的坐标转换为一条射线
            RaycastHit hitinfo;
            bool isCollier = Physics.Raycast(ray, out hitinfo);
            if (isCollier&&hitinfo.collider.tag==Tags.ground)
            {
                isMoving = true;
                ShowClickEffect(hitinfo.point);
                LookAtTarget(hitinfo.point);
            }        
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }
        if (isMoving)
        {
            //从鼠标位置发射一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            bool isCollier = Physics.Raycast(ray, out hitinfo);
            if (isCollier && hitinfo.collider.tag == Tags.ground)
            {
                LookAtTarget(hitinfo.point);
            }         
        }
        else if(playerMove.isMoving)
        {
            LookAtTarget(targetPosition);
        }
	}
    //实例化点击效果
    void ShowClickEffect(Vector3 hitpoint)
    {
        //将特效位置y轴向上浮动优化显示
        hitpoint = new Vector3(hitpoint.x, hitpoint.y + 1f, hitpoint.z);
        //产生特效
        GameObject.Instantiate(effect_click_prefab,hitpoint,Quaternion.identity);
    }
    void LookAtTarget(Vector3 hitPoint)
    {   //获得目标位置坐标点
        targetPosition = hitPoint;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        //让角色朝向到目标位置
        this.transform.LookAt(targetPosition);

    }
}
