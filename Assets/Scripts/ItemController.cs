using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class ItemController : MonoBehaviour
{
    public ItemData ItemData;

    [ContextMenu("To Json Data")]//뒤따라오는 함수를 실행하는 메뉴버튼추가
    void SaveItemDataToJson()
    {
        //json 문자열로 변형하고 싶은 문자열을 넣어주면 json형태의 문자열이 출력
        string jsonData = JsonUtility.ToJson(ItemData, true);
        //현재 실행중인 유니티 프로젝트 경로
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("From Json Data")]//뒤따라오는 함수를 실행하는 메뉴버튼추가
    void LoadItemDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        ItemData = JsonUtility.FromJson<ItemData>(jsonData);
    }
}

[System.Serializable]
public class ItemData //json으로 저장시 불필요한 monobehaviour정보까지 함께저장됨을 막음
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