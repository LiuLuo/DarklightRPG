using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
  

    public Texture2D cousor_normal;
    public Texture2D cousor_npc_talk;
    public Texture2D cousor_attack;
    public Texture2D cousor_lockTarget;
    public Texture2D cousor_pick;


    public Vector2 hotspot = Vector2.zero;//z左上角
    private CursorMode mode = CursorMode.Auto;//鼠标指针模式类型

    public static CursorManager _instance;
    private void Awake()
    {
        _instance = this;
    }

    public void SetNormal()
    {
        Cursor.SetCursor(cousor_normal,hotspot,mode);
    }

    public void SetNpcTalk()
    {
        Cursor.SetCursor(cousor_npc_talk, hotspot, mode);
    }

}
