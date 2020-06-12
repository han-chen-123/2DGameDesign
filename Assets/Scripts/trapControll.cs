using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trapControll : MonoBehaviour
{
    int trapsLayer;
    private void Start()
    {
        trapsLayer = LayerMask.NameToLayer("traps");
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == trapsLayer)
        {
            gameObject.SetActive(false);
            Invoke("loadGame",2f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void loadGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
