using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;//主角
    private Vector3 offsetPosition;//位置偏移

    public float distance = 0;
    public float scrollSpeed ;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;//通过标签查找人物
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = player.position + offsetPosition;

        ScrollView();
    }
    void ScrollView()
    {
        //print(Input.GetAxis("Mouse ScrollWheel"));
        distance = offsetPosition.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);
        offsetPosition = offsetPosition.normalized * distance;
    }
}
