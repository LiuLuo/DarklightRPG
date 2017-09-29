using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private PlayerMove move;
	void Start () {
        move = this.GetComponent<PlayerMove>();
	}
    private void LateUpdate()
    {
        //根据从PlayerMove获取的状态播放动画
        if (move.state==PlayerState.Moving)
        {
            PlayAnim("Sword-Walk");
        }
        else if(move.state == PlayerState.Idle)
        {
            PlayAnim("Sword-Idle");
        }        
    }
    void PlayAnim(string animName)
    {
        this.GetComponent<Animation>().CrossFade(animName);
    }
}
