using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation: MonoBehaviour
{
    public static CharacterCreation instance;

    public UIInput nameInput;
    public GameObject[] characterPerfabs;
    public GameObject[] characterGameObject;
    public int selectedIndex = 0;
    private int length;//可供选择个数
                       // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    void Start () {
        length = characterPerfabs.Length;
        characterGameObject = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            characterGameObject[i] = GameObject.Instantiate(characterPerfabs[i], transform.position, transform.rotation) as GameObject;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCharacterShow();

    }
    //控制显示职业
    private void UpdateCharacterShow()
    {
        characterGameObject[selectedIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i!=selectedIndex)
            {
                characterGameObject[i].SetActive(false);
            }
        }
    }

    //职业选择左右无限循环
    public void OnCharacterLeft()
    {
        if (CharacterCreation.instance.selectedIndex > 0)
        {
            CharacterCreation.instance.selectedIndex -= 1;
        }
        else
        {
            CharacterCreation.instance.selectedIndex = CharacterCreation.instance.characterGameObject.Length-1;
        }
        UpdateCharacterShow();

    }

    public void OnCharacterRight()
    {

        if (CharacterCreation.instance.selectedIndex < CharacterCreation.instance.characterGameObject.Length-1)
        {
            CharacterCreation.instance.selectedIndex += 1;
        }
        else
        {
            CharacterCreation.instance.selectedIndex = 0;
        }
        UpdateCharacterShow();

    }



    public void OnOKButton()
    {
        //保存角色选择及名字数据
        PlayerPrefs.SetInt("selectedIndex", selectedIndex);
        PlayerPrefs.SetString("nameInput", nameInput.value);
        //加载下一个场景


    }
}
