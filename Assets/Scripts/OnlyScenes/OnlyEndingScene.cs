using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OnlyEndingScene : MonoBehaviour
{
    public GameObject m_firstPanel;
    //public GameObject m_secondPanel;
    public Text m_endText;
    public bool m_clickAgain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_firstPanel.active == true)
        {
            m_clickAgain = true;
        }
    }

    public void ButtonClick()
    {
        if(m_clickAgain == false)
        {
            m_firstPanel.SetActive(true);
            m_endText.text = "Click again";
        }
        else if(m_clickAgain == true)
        {
            SceneManager.LoadScene("Intro");
        }
        
    }

}
