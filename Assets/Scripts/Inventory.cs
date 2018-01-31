using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory _instance;
    public List<InventoeyItemGrid> itemGrid = new List<InventoeyItemGrid>();

    private TweenPosition tween;
    private int coinCount = 1000;

    public UILabel coinUiLAbel;
  
    // Use this for initialization
    public static Inventory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Inventory();
        }
        return _instance;

    }

    void Awake()
    {
        tween = this.GetComponent<TweenPosition>();

    }
    private void Update()
    {
        coinUiLAbel.text = coinCount.ToString();
    }
    public void ShowInventory()
    {
        tween.gameObject.SetActive(true);
        tween.PlayForward();
    }
    public void HideInventory()
    {
        tween.PlayReverse();

    }

}
