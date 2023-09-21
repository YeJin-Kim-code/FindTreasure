using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFinalScene : MonoBehaviour
{
    public GameObject m_treasurePanel;
    public static bool m_treasureInput = true;
    public bool m_apple;
    public bool m_banana;
    public bool m_waterMelon;
    public bool m_pumkin;
    public SceneController m_sceneController;


    void Start()
    {
        GameManager.Instance.TalkCheck(1050);
    }

    // Update is called once per frame
    void Update()
    {
        if ( m_treasureInput == false)
        {
            m_treasurePanel.SetActive(true);

        }
        else
        {
            m_treasurePanel.SetActive(false);
        }

        CheckTreasureItem();
        CheckTreasureItem2();
        CheckEnding();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TalkCheck(1051);

        }
    }
    public void CheckTreasureItem()
    {
        if (FindObjectOfType<Canvas>().transform.GetChild(9).transform.GetChild(0).transform.GetChild(0).childCount == 0)
        {
            Debug.Log("Empty");
            return;
        }
        else if (FindObjectOfType<Canvas>().transform.GetChild(9).transform.GetChild(0).transform.GetChild(0).childCount == 1)
        {
            GameObject m_treasureItem1 = FindObjectOfType<Canvas>().transform.GetChild(9).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;
            if (m_treasureItem1 == GameObject.FindWithTag("Apple"))
            {
                m_apple = true;
                Debug.Log("appleee");
            }
            else if (m_treasureItem1 == GameObject.FindWithTag("Banana"))
            {
                m_banana = true;
            }
            else if (m_treasureItem1 == GameObject.FindWithTag("WaterMelon"))
            {
                m_waterMelon = true;
                Debug.Log("WATERMELON");
            }
            else if (m_treasureItem1 == GameObject.FindWithTag("Pumkin"))
            {
                m_pumkin = true;
            }
        }

    }
    public void CheckTreasureItem2()
    {

        if (FindObjectOfType<Canvas>().transform.GetChild(9).transform.GetChild(0).transform.GetChild(1).childCount == 0)
        {
            Debug.Log("Empty2");
            return;
        }
        else if (FindObjectOfType<Canvas>().transform.GetChild(9).transform.GetChild(0).transform.GetChild(1).childCount == 1)
        {
            GameObject m_treasureItem2 = FindObjectOfType<Canvas>().transform.GetChild(9).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject;
            if (m_treasureItem2 == GameObject.FindWithTag("Apple"))
            {
                m_apple = true;
                Debug.Log("appleee");
            }
            else if (m_treasureItem2 == GameObject.FindWithTag("Banana"))
            {
                m_banana = true;
                Debug.Log("BANANA");
            }
            else if (m_treasureItem2 == GameObject.FindWithTag("WaterMelon"))
            {
                m_waterMelon = true;
                Debug.Log("WATERMELON");
            }
            else if (m_treasureItem2 == GameObject.FindWithTag("Pumkin"))
            {
                m_pumkin = true;
                Debug.Log("PUMKIN");
            }
        }
    }
    public void CheckEnding()
    {
        if(m_apple==true && m_waterMelon == true)
        {
            Debug.Log("good");
            m_sceneController.GoodEndingScene();
        }
        else if(m_banana == true && m_pumkin == true)
        {
            Debug.Log("normal");
            m_sceneController.NormalEndingScene();
        }
        else if(m_apple==true&&m_banana==true || m_apple == true&& m_pumkin == true || m_banana==true&&m_waterMelon==true || m_waterMelon==true&&m_pumkin==true)
        {
            Debug.Log("bad");
            m_sceneController.BadEndingScene();
        }

    }
    public void treasureDisactive()//코루틴 써서
    {

    }
    public void GoodEnding()
    {

    }

    public void NormalEnding()
    {

    }

    public void BadEnding()
    {

    }

    public void Fadein()//이미지 하얀거 천천히 불투명하게
    {

    }
    
}
