using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update

    public int m_itemNum;
    public string m_itemName;

    void Start()//아이템의 숫자나 이름에 따라 분기를 가르고 대사를 다르게 설정
    {
        if (m_itemNum == GameManager.Instance.m_itemController.ItemData.itemDetail[m_itemNum].itemNum)
        {
            m_itemName = GameManager.Instance.m_itemController.ItemData.itemDetail[m_itemNum].itemName;
            Debug.Log(m_itemName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
