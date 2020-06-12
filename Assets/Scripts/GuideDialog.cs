using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideDialog : MonoBehaviour
{
    public GameObject guideDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            guideDialog.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            guideDialog.SetActive(false);
        }
    }
}
