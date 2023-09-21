using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GameStart()
    {
        LoadingSceneController.LoadScene("MainScene"); //로딩 거쳐서 갈림길로 넘어가기
    }

    public void OnClickSlide()
    {
        LoadingSceneController.LoadScene("SlidingPuzzle"); //슬라이딩 퍼즐겜
    }

    public void OnClickBackSlide()
    {
        SceneManager.LoadScene("MiniGame4Scene"); //활주 귀환(슬라이딩)
        GameManager.Instance.m_slideClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void OnClickRotate()
    {
        LoadingSceneController.LoadScene("RotatePuzzle"); //로테이팅 퍼즐겜
    }

    public void OnClickBackRotate()
    {
        SceneManager.LoadScene("MiniGame1Scene"); //회전 귀환(로테이팅)
        GameManager.Instance.m_rotateClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void OnClickJigsaw()
    {
        LoadingSceneController.LoadScene("JigsawPuzzle"); //직소
    }

    public void OnClickBackJigsaw()
    {
        SceneManager.LoadScene("MiniGame3Scene"); //올바름 귀환(직소)
        GameManager.Instance.m_jigsawClear = true;
        GameManager.Instance.m_gameClear = true;
    }

    public void OnClickIce()
    {
        LoadingSceneController.LoadScene("IceGame"); //빙판게임
    }

    public void OnClickBackIce()
    {
        SceneManager.LoadScene("MiniGame2Scene"); //시작 숲 귀환(빙판)
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
