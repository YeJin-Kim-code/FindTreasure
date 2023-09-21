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
        talkData.Add(1000, new string[] { "������ ������ �� �� ����� ������ �÷��ִ� �������ڰ� �ִٰ� �����!","�ϴ� ���ͺ����� ���Ⱑ ����� �ϳ��� �𸣰ڴ�.", "Ȥ�� ��ã�µ� ������ �ɸ��� ���� ������?" ,"���������� ���̾�", "�� �� �ֺ��� �ѷ�����"});
        talkData.Add(1001, new string[] { "������ ã���Ͱ���", "������ ��ܿ� ���� �������� �����Ǿ���." ,"�Ʒ��ʿ� �޼����� ������ �ڼ��� ������ �ʴ´�.", "������ ������ ������ �����ٵ�..."});
        talkData.Add(1002, new string[] { "�����⸦ ã�Ҵ�.", "������ ��ܿ� ������ �������� �����Ǿ���.", "���������� ������ �޼����� Ȯ���� �� ���� �� ����" });
        talkData.Add(1003, new string[] { "������� ������ Ȯ���غ��Ҵ�.", "����� ������ ��", "�ٳ����� ȣ���� ���", "�� �ܿ��� �������� ���ÿ�", "...��ü ���� �ǹ���?" });

        talkData.Add(1010, new string[] { "���ο� ���� ���� �� ����.", "������ ��¦ �ٲ�Ͱ���", "�����⸦ ����غ���" });
        talkData.Add(1011, new string[] { "������ �ذ��ߴ�!", "���ο� �������� ȹ���ߴ�!", "�κ��丮�� Ȯ���غ���" });


        talkData.Add(1050, new string[] { "�� ���� ������ �ִ� �� ����.", "���� �տ� ������." });
        talkData.Add(1051, new string[] { "���� ������ ã�Ҵ�!.", "�ѹ� �����." });
        talkData.Add(1052, new string[] { "������ ��Ʈ�� �־���?.", "������ �����ؼ� �־��" });

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
