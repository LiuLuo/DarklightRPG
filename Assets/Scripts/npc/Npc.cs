using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {
    
    public void OnMouseEnter()
    {

        CursorManager._instance.SetNpcTalk();
        //CursorManager.singleton.SetNpcTalk();
        //print("11");
    }
    public void OnMouseExit()
    {
        CursorManager._instance.SetNormal();
      
    }
}
