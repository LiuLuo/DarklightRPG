using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;//主角
    private Vector3 offsetPosition;//位置偏移

    public float distance = 0;
    public float scrollSpeed=4 ;

    private bool isRotate=false;
    public float rotateSpeed=1;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;//通过标签查找人物
       // transform.LookAt(player.position);会固定死视角角度
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = player.position + offsetPosition;
        RotateView();//视野旋转
        ScrollView();//视野远近
      
    }
    void ScrollView()
    {
        //print(Input.GetAxis("Mouse ScrollWheel"));
        distance = offsetPosition.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * -scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);
        offsetPosition = offsetPosition.normalized * distance;
    }
   void  RotateView()
    {
        Input.GetAxis("Mouse X");
        Input.GetAxis("Mouse Y");
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }
        if (isRotate)
        {
            transform.RotateAround(player.position,Vector3.up,rotateSpeed * Input.GetAxis("Mouse X"));
            Vector3 originPos = transform.position;
            Quaternion originRotation = transform.rotation;

            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));//影响了position,rotate
            float x = transform.eulerAngles.x;
            if (x<10||x>80)//超出范围取消旋转
            {
                transform.position = originPos;
                transform.rotation = originRotation;
            }
       
        }
        offsetPosition = transform.position - player.position;
    }
}