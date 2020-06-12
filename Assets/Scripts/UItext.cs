using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItext : MonoBehaviour
{

    public int SCORE = 0;
    private string string_score;
    public Text _text;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string_score = SCORE.ToString();  //数字转字符串
        _text.text = string_score;

    }
}
