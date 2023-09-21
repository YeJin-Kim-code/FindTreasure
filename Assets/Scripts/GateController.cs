using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GateController : MonoBehaviour
{
    public SceneController m_sceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&this.gameObject.CompareTag("Mini1"))
        {
           // GameManager.Instance.m_playerMainPosition =   new Vector3 (collision.gameObject.transform.position.x+3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            SceneManager.LoadScene("MiniGame1Scene");
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Mini2"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            SceneManager.LoadScene("MiniGame2Scene");
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Mini3"))
        {
           // GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            SceneManager.LoadScene("MiniGame3Scene");
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Mini4"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            SceneManager.LoadScene("MiniGame4Scene");
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Final"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);

            SceneManager.LoadScene("FinalScene");
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("MiniGame1"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);

            m_sceneController.OnClickRotate();
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("MiniGame2"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            m_sceneController.OnClickIce();

        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("MiniGame3"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);

            m_sceneController.OnClickJigsaw();
        }
        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("MiniGame4"))
        {
            //GameManager.Instance.m_playerMainPosition = new Vector3(collision.gameObject.transform.position.x + 3, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);

            m_sceneController.OnClickSlide();
        }

        else if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Main"))
        {
            SceneManager.LoadScene("MainScene");
            GameManager.Instance.m_moveGate = true;
            
        }
    }
}
