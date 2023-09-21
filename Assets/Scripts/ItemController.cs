using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class ItemController : MonoBehaviour
{
    public ItemData ItemData;

    [ContextMenu("To Json Data")]//�ڵ������ �Լ��� �����ϴ� �޴���ư�߰�
    void SaveItemDataToJson()
    {
        //json ���ڿ��� �����ϰ� ���� ���ڿ��� �־��ָ� json������ ���ڿ��� ���
        string jsonData = JsonUtility.ToJson(ItemData, true);
        //���� �������� ����Ƽ ������Ʈ ���
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("From Json Data")]//�ڵ������ �Լ��� �����ϴ� �޴���ư�߰�
    void LoadItemDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        ItemData = JsonUtility.FromJson<ItemData>(jsonData);
    }
}

[System.Serializable]
public class ItemData //json���� ����� ���ʿ��� monobehaviour�������� �Բ�������� ����
{
    public List<ItemDetailData> itemDetail;
}
[System.Serializable]
public class ItemDetailData
{
    public int itemNum;
    public string itemName;
    public GameObject m_item;
}