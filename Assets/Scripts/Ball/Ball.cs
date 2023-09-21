using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    /*[SerializeField]
    Text textPlaytime;*/

    float h;
    float v;
    float speed = 10;
    
    public float sec;
    public float min;

    public bool isMoving;
    public isGoal mng;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        //Timer();
    }

    void FixedUpdate()
    {
        Moving();
        FalseMove();
    }

    void Moving() //이동
    {
        if (Input.GetButton("Horizontal") && isMoving == false)
        {
            rb.velocity = new Vector2(h, 0) * speed;
            isMoving = true;
        }

        if (Input.GetButton("Vertical") && isMoving == false)
        {
            if (isMoving == false)
            {
                rb.velocity = new Vector2(0, v) * speed;
                isMoving = true;
            }
        }

        if (isMoving == true)
            return;
    }

    void FalseMove() //완전히 멈추면 isMoving을 다시 false로 변경
    {
        if (Mathf.Abs(rb.velocity.x) == 0 && Mathf.Abs(rb.velocity.y) == 0)
            isMoving = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            mng.GameClear();
        }
    }

    /*void Timer()
    {
        sec += Time.deltaTime;
        textPlaytime.text = string.Format("{0:d2}:{1:d2}", min, (int)sec);

        if ((int)sec > 59)
        {
            sec = 0;
            min++;
        }
    }*/
}
