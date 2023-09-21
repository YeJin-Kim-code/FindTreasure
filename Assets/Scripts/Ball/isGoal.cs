using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class isGoal : MonoBehaviour
{
    [SerializeField]
    private GameObject ClearPanel;

    public static bool isClear;

    void Start()
    {
        isClear = false;
        ClearPanel.SetActive(false);
    }

    public void GameClear()
    {
        isClear = true;
        ClearPanel.SetActive(true);
    }
}
