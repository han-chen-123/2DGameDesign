using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leve1Select : MonoBehaviour
{
    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {         
            Invoke("SwitchLevel", 3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CancelInvoke();
        }
    }

    void SwitchLevel()
    {
        SceneManager.LoadScene("level1");
    }
}
