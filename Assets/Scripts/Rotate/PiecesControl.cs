using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pieces;
    [SerializeField]
    private GameObject ClearPanel;

    public static bool isClear;

    void Start()
    {
        isClear = false;
        ClearPanel.SetActive(false);
    }

    void Update()
    {
        if(pieces[0].rotation.z == 0 &&
            pieces[1].rotation.z == 0 &&
            pieces[2].rotation.z == 0 &&
            pieces[3].rotation.z == 0 &&
            pieces[4].rotation.z == 0 &&
            pieces[5].rotation.z == 0 &&
            pieces[6].rotation.z == 0 &&
            pieces[7].rotation.z == 0 &&
            pieces[8].rotation.z == 0 &&
            pieces[9].rotation.z == 0 &&
            pieces[10].rotation.z == 0 &&
            pieces[11].rotation.z == 0 &&
            pieces[12].rotation.z == 0 &&
            pieces[13].rotation.z == 0 &&
            pieces[14].rotation.z == 0 &&
            pieces[15].rotation.z == 0 &&
            pieces[16].rotation.z == 0 &&
            pieces[17].rotation.z == 0 &&
            pieces[18].rotation.z == 0 &&
            pieces[19].rotation.z == 0 &&
            pieces[20].rotation.z == 0 &&
            pieces[21].rotation.z == 0 &&
            pieces[22].rotation.z == 0 &&
            pieces[23].rotation.z == 0 &&
            pieces[24].rotation.z == 0 &&
            pieces[25].rotation.z == 0 &&
            pieces[26].rotation.z == 0 &&
            pieces[27].rotation.z == 0 &&
            pieces[28].rotation.z == 0 &&
            pieces[30].rotation.z == 0 &&
            pieces[31].rotation.z == 0 &&
            pieces[32].rotation.z == 0 &&
            pieces[33].rotation.z == 0 &&
            pieces[34].rotation.z == 0)
        {
            isClear = true;
            ClearPanel.SetActive(true);
        }
    }
}
