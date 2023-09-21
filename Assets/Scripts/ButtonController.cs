using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject m_map;
    public GameObject m_magPanel;
    public GameObject m_inventory;

    public AudioClip clip;
    public bool m_invenActive = false;
    public void ClickMapActive()
    {
        Sound();
        m_map.SetActive(true);
    }

    public void ClickMagActive()
    {
        Sound();
        m_magPanel.SetActive(true);
    }
    public void ClickMagDisactive()
    {
        Sound();
        m_magPanel.SetActive(false);
    }
    public void ClickMapDisactive()
    {
        Sound();
        m_map.SetActive(false);
    }
    public void ClickInvenActive()
    {
        Sound();
        if (m_invenActive == false)
        {
            m_inventory.SetActive(true);
            m_invenActive = true;
        }
        else if (m_invenActive == true)
        {
            m_inventory.SetActive(false);
            m_invenActive = false;
        }
    }

    public void Sound()
    {
        SoundManager.instance.SFXPlay("button", clip);
    }
}
