using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class JigsawPuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject ClearPanel;

    public static int remainingPieces = 63;

    public static bool isClear;

    void Start()
    {
        isClear = false;
        ClearPanel.SetActive(false);
    }

    void Update()
    {
        if(remainingPieces == 0)
        {
            isClear = true;
            ClearPanel.SetActive(true);
        }
    }
}
