using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour {

    public void OnMouseEnter()
    {
        CursorManager._instance.SetNpcTalk();
    }
    public void OnMouseExit()
    {
        CursorManager._instance.SetNormal();
      
    }
}
