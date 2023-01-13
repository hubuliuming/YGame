using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableAllChildrenOfSlectedGameObject : MonoBehaviour
{
    public int selectNumber;

    public GameObject modelParentGameObject;
    public List<GameObject> modelList = new List<GameObject>();

    public GameObject buttonParentGameObject;
    public List<Button> buttonList = new List<Button>();

    private int _index;
    
    private void Awake()
    {
        GetAllModel();
        GetAllButton();
    }

    //获取全部 Model
    public void GetAllModel()
    {
        for (int i = 0; i < modelParentGameObject.transform.childCount; i++)
        {
            modelList.Add(modelParentGameObject.transform.GetChild(i).gameObject);
        }
    }

    //获取全部 Button
    public void GetAllButton()
    {
        for (int i = 0; i < buttonParentGameObject.transform.childCount; i++)
        {
            var btn = buttonParentGameObject.transform.GetChild(i).GetComponent<Button>();
            var index = i;
            btn.onClick.AddListener(() =>
            {
                _index = index;
                EnableSelectModel();
            });
            buttonList.Add(btn);
        }
    }

    //隐藏所有模型
    public void DisableAllModel()
    {
        foreach (var model in modelList)
        {
            model.SetActive(false);
        }
    }

    //显示所选模型
    public void EnableSelectModel()
    {
        modelList[_index].SetActive(true);
    }
}