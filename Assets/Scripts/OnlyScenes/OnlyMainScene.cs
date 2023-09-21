using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyMainScene : MonoBehaviour
{
    public GameObject m_map;
    public GameObject m_mag;
    void Update()
    {
        CheckMap();
        CheckMag();
    }

    public void CheckMap()
    {
        if(GameManager.Instance.m_mapActive == true)
        {
            Destroy(m_map);
        }
    }
    public void CheckMag()
    {
        if (GameManager.Instance.m_magActive == true)
        {
            Destroy(m_mag);
        }
    }
}
