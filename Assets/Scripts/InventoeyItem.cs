using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoeyItem : UIDragDropItem {

    private UISprite sprite;
    void awake()
    {
        sprite = this.GetComponent<UISprite>();
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface!=null )
        {
            print(surface.tag);
        }
    }

    public void SetId(int Id)
    {
        ObjectsInfo.ObjectInfo info= ObjectsInfo._instance.GetObjectInfoById(Id);
        sprite.spriteName = info.Icon;

    }
}
