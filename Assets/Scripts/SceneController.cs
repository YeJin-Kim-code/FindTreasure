using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GameStart()
    {
        LoadingSceneController.LoadScene("MainScene"); //�ε� ���ļ� ������� �Ѿ��
    }

    public void OnClickSlide()
    {
        LoadingSceneController.LoadScene("SlidingPuzzle"); //�����̵� �����
    }

    public void OnClickBackSlide()
    {
        SceneManager.LoadScene("MiniGame4Scene"); //Ȱ�� ��ȯ(�����̵�)
        GameManager.Instance.m_slideClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void OnClickRotate()
    {
        LoadingSceneController.LoadScene("RotatePuzzle"); //�������� �����
    }

    public void OnClickBackRotate()
    {
        SceneManager.LoadScene("MiniGame1Scene"); //ȸ�� ��ȯ(��������)
        GameManager.Instance.m_rotateClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void OnClickJigsaw()
    {
        LoadingSceneController.LoadScene("JigsawPuzzle"); //����
    }

    public void OnClickBackJigsaw()
    {
        SceneManager.LoadScene("MiniGame3Scene"); //�ùٸ� ��ȯ(����)
        GameManager.Instance.m_jigsawClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void OnClickIce()
    {
        LoadingSceneController.LoadScene("IceGame"); //���ǰ���
    }

    public void OnClickBackIce()
    {
        SceneManager.LoadScene("MiniGame2Scene"); //���� �� ��ȯ(����)
        GameManager.Instance.m_iceClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void GoodEndingScene()
    {
        LoadingSceneController.LoadScene("GoodEnding");
    }
    public void BadEndingScene()
    {
        LoadingSceneController.LoadScene("BadEnding");
    }
    public void NormalEndingScene()
    {
        LoadingSceneController.LoadScene("NormalEnding");
    }
}
