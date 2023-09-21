using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float m_speed = 3.0f;
    public Rigidbody2D rigidbody2d;
    public Animator m_ani;
    public AudioClip clip;
    //Vector2 lookDirection = new Vector2(1, 0);
    //public GameManager m_gameManager;//상태제한 20분쯤

    void Update()
    {
        move();
        //if(rigidbody2d == null) 씬이동할때 포지션 위치고정
        //{
        //    rigidbody2d = GetComponent<Rigidbody2D>();
        //}
        //if(GameManager.Instance.m_moveGate == true)
        //{
        //    this.rigidbody2d.MovePosition(GameManager.Instance.m_playerMainPosition);
        //    GameManager.Instance.m_moveGate = false;
        //}
    }
    
    void move()//플레이어 이동관리
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + m_speed * horizontal * Time.deltaTime;
        position.y = position.y + m_speed * vertical * Time.deltaTime;


        transform.position = position;
        Vector3 flipMove = Vector3.zero;
        if(Input.GetAxisRaw("Horizontal")<0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (!Mathf.Approximately(vertical, 0.0f) || !Mathf.Approximately(horizontal, 0.0f))
        {
             m_ani.SetBool("isRun", true);
            
        }
        else if (Mathf.Approximately(vertical, 0.0f) && Mathf.Approximately(horizontal, 0.0f))
        {
            m_ani.SetBool("isRun", false);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            GameManager.Instance.appleActive = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Banana"))
        {
            GameManager.Instance.bananaActive = true;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("map"))
        {
            GameManager.Instance.m_mapicon.gameObject.SetActive(true);
            GameManager.Instance.m_mapActive = true;
            GameManager.Instance.TalkCheck(1001);
            SoundManager.instance.SFXPlay("item", clip);
            //Destroy(collision.gameObject); onlymainscene으로 이동
        }
        else if(collision.gameObject.CompareTag("magnifying glass"))
        {
            GameManager.Instance.m_magicon.gameObject.SetActive(true);
            GameManager.Instance.m_magActive = true;
            GameManager.Instance.TalkCheck(1002);
            SoundManager.instance.SFXPlay("item", clip);
        }

    }
}
