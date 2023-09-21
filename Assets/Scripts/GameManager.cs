using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour//, IPointerClickHandler
{
    public TalkManager talkManager;
    public ItemController m_itemController;
    public Text talkText;
    public GameObject talkPanel;
    public GameObject m_apple;
    public GameObject m_banana;
    public GameObject m_waterMelon;
    public GameObject m_pumkin;
    public GameObject m_mapicon;
    public GameObject m_magicon;
    public GameObject m_player;
    public bool isAction; // active된 상태에서는 플레이어가 움직이지 못하게 한다.
    public bool appleActive;
    public bool bananaActive;
    public bool m_mapActive = false;
    public bool m_magActive = false;
    public bool m_moveGate;
    public bool m_startTalk;
    public bool m_rotateClear;
    public bool m_iceClear;
    public bool m_jigsawClear;
    public bool m_slideClear;
    public bool m_gameClear;


    public int talkIndex;
    public int id;
    public Vector3 m_playerMainPosition;
    




    //싱글톤 구현

    //private static GameManager instance;

    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Start()
    {
        //수정
        TalkCheck(1000);
    }
    public void PanelActive()
    {
        isAction = true;
        talkPanel.SetActive(isAction);
    }

    public void PanelDisactive()
    {
        isAction = false;
        talkPanel.SetActive(isAction);
        if(id == 1051)//처리 다하면 id 0으로 초기화
        {
            OnlyFinalScene.m_treasureInput = false;
        }
    }
    private void Update()//미니게임 씬이나 엔딩씬이면 찾지않기
    {
        if(talkManager == null)
        {
            talkManager = FindObjectOfType<TalkManager>();
        }
        if(m_itemController == null)
        {
            m_itemController = FindObjectOfType<ItemController>();
        }

        if (talkPanel == null)
        {
            talkPanel = FindObjectOfType<Canvas>().transform.GetChild(1).gameObject;
        }
        if (talkText == null)
        {
            talkText = talkPanel.GetComponentInChildren<Text>();
        }
        if (m_apple == null)
        {
            m_apple = FindObjectOfType<Canvas>().transform.GetChild(6).transform.GetChild(0).transform.GetChild(0).gameObject;

        }
        if (m_banana == null)
        {
            m_banana = FindObjectOfType<Canvas>().transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).gameObject;

        }
        if (m_waterMelon == null)
        {
            m_waterMelon = FindObjectOfType<Canvas>().transform.GetChild(6).transform.GetChild(2).transform.GetChild(0).gameObject;

        }
        if (m_pumkin == null)
        {
            m_pumkin = FindObjectOfType<Canvas>().transform.GetChild(6).transform.GetChild(3).transform.GetChild(0).gameObject;

        }
        if (m_mapicon == null)
        {
            m_mapicon = FindObjectOfType<Canvas>().transform.GetChild(2).gameObject;

        }
        if(m_magicon == null)
        {
            m_magicon = FindObjectOfType<Canvas>().transform.GetChild(3).gameObject;
        }
        if(m_player == null)//플레이어 위치 고정
        {
            m_player = GameObject.FindWithTag("Player");
        }
        if(m_moveGate == true)//추후 수정
        {
            //m_player.gameObject. = m_playerMainPosition;
            //m_moveGate = false;
        }

        if(m_rotateClear == true)
        {
            m_apple.SetActive(true);
        }
        if(m_iceClear == true)
        {
            m_banana.SetActive(true);
        }
        if(m_jigsawClear == true)
        {
            m_waterMelon.SetActive(true);
        }
        if(m_slideClear == true)
        {
            m_pumkin.SetActive(true);
        }
        if(GameManager.instance.m_gameClear == true)
        {
            TalkCheck(1011);
            GameManager.instance.m_gameClear = false;
        }
        if (m_mapActive == true)
        {
            m_mapicon.SetActive(true);

        }
        if (m_magActive == true)
        {
            m_magicon.SetActive(true);

        }
        //talk 함수처리해줘야겠다.
        GetEnter();

        if(m_startTalk == true)
        {
            PanelActive();
            Talk(id, talkIndex);
            m_startTalk = false;

        }


        //오브젝트 엑티브 추후수정
        if (appleActive == true)
        {
            m_apple.SetActive(true);
        }
        if(bananaActive == true)
        {
            m_banana.SetActive(true);
        }


    }

    public void TalkCheck(int m_idnum)
    {
        id = m_idnum;
        m_startTalk = true;

    }
    public void GetEnter()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isAction == true)
            {
                talkIndex++;
                Talk(id, talkIndex);//후에 1000부분을 id로 대체
            }
        }
    }
    void Talk(int id, int talkIndex)
    {
        string talkData =  talkManager.GetTalk(id, talkIndex);

        if(talkData == null)//대화가 다 진행될시
        {
            PanelDisactive();
            GameManager.instance.talkIndex = 0;
            return;
        }
        talkText.text = talkData;
        
    }




    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        Debug.Log("Mouse Click Button : Left");
    //        if(isAction == true)
    //        {
    //            talkIndex++;
    //        }

    //    }
    //}


}
