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
    public bool isAction; // active�� ���¿����� �÷��̾ �������� ���ϰ� �Ѵ�.
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
    




    //�̱��� ����

    //private static GameManager instance;

    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
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
        //����
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
        if(id == 1051)//ó�� ���ϸ� id 0���� �ʱ�ȭ
        {
            OnlyFinalScene.m_treasureInput = false;
        }
    }
    private void Update()//�̴ϰ��� ���̳� �������̸� ã���ʱ�
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
        if(m_player == null)//�÷��̾� ��ġ ����
        {
            m_player = GameObject.FindWithTag("Player");
        }
        if(m_moveGate == true)//���� ����
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
        //talk �Լ�ó������߰ڴ�.
        GetEnter();

        if(m_startTalk == true)
        {
            PanelActive();
            Talk(id, talkIndex);
            m_startTalk = false;

        }


        //������Ʈ ��Ƽ�� ���ļ���
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
                Talk(id, talkIndex);//�Ŀ� 1000�κ��� id�� ��ü
            }
        }
    }
    void Talk(int id, int talkIndex)
    {
        string talkData =  talkManager.GetTalk(id, talkIndex);

        if(talkData == null)//��ȭ�� �� ����ɽ�
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
