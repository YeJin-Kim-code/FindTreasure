using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update

    public int m_itemNum;
    public string m_itemName;

    void Start()//�������� ���ڳ� �̸��� ���� �б⸦ ������ ��縦 �ٸ��� ����
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
