using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public string pieceSatus = "Idle";
    public string checkPlacement = "";

    public KeyCode clickPiece;


    void Start()
    {
    }

    void Update()
    {
        if(pieceSatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        if ((Input.GetKeyDown(clickPiece)) && (pieceSatus == "pickedup"))
        {
            checkPlacement = "y"; //yes
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if((other.gameObject.name == gameObject.name) && (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 5;

            transform.position = other.gameObject.transform.position;
            pieceSatus = "locked";
            checkPlacement = "n"; //no

            JigsawPuzzle.remainingPieces--;
        }

        if ((other.gameObject.name != gameObject.name) && (checkPlacement == "y"))
        {
            checkPlacement = "n";
        }
    }

    void OnMouseDown()
    {
        pieceSatus = "pickedup";
        checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10; //클릭하면 가장 위로 가도록
    }

    public void IsGameOver()
    {
        if (JigsawPuzzle.remainingPieces == 0)
        {
            Debug.Log("GameClear");
        }
    }
}