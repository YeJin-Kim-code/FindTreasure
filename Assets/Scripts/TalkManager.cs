using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "전설에 따르면 이 숲 깊숙히 성적을 올려주는 보물상자가 있다고 들었어!","일단 들어와봤지만 여기가 어딘지 하나도 모르겠다.", "혹시 길찾는데 도움이 될만한 것이 있을까?" ,"지도같은거 말이야", "한 번 주변을 둘러보자"});
        talkData.Add(1001, new string[] { "지도를 찾은것같다", "오른쪽 상단에 지도 아이콘이 생성되었다." ,"아래쪽에 메세지가 있지만 자세히 보이지 않는다.", "돋보기 같은게 있으면 좋을텐데..."});
        talkData.Add(1002, new string[] { "돋보기를 찾았다.", "오른쪽 상단에 돋보기 아이콘이 생성되었다.", "돋보기모양을 누르면 메세지를 확인할 수 있을 것 같다" });
        talkData.Add(1003, new string[] { "돋보기로 지도를 확대해보았다.", "사과와 수박은 굿", "바나나와 호박은 노멀", "그 외에는 조합하지 마시오", "...대체 무슨 의미지?" });

        talkData.Add(1010, new string[] { "새로운 숲에 들어온 것 같다.", "지도가 살짝 바뀐것같네", "돋보기를 사용해보자" });
        talkData.Add(1011, new string[] { "퍼즐을 해결했다!", "새로운 아이템을 획득했다!", "인벤토리를 확인해보자" });


        talkData.Add(1050, new string[] { "길 끝에 보물이 있는 것 같다.", "보물 앞에 서보자." });
        talkData.Add(1051, new string[] { "드디어 보물을 찾았다!.", "한번 열어보자." });
        talkData.Add(1052, new string[] { "지도에 힌트가 있었지?.", "적절히 조합해서 넣어보자" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
