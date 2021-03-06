﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class recognizing : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    public int isstart=0;
    public Canvas can;
    public Text text1;
    public Text text2;
    public string[] kstring;
    void Start()
    {
        kstring = new string[22];
        kstring[0] = "hello";
        kstring[1] = "how";
        kstring[2] = "hi";
        kstring[3] = "hell";
        kstring[4] = "he";
        kstring[5] = "hobby";
        kstring[6] = "able";
        kstring[7] = "process";
        kstring[8] = "yes";
        kstring[9] = "signal";
        kstring[10] = "digital";
        kstring[11] = "information";
        kstring[12] = "你好";
        kstring[14] = "儒雅随和";
        kstring[13] = "你妈死了";
        kstring[14] = "抠你妈的逼";
        kstring[15] = "文明直播间";
        kstring[16] = "带带带师兄";
        kstring[17] = "高飞";
        kstring[18] = "汪孟翔";
        kstring[19] = "卫政";
        kstring[20] = "李仕豪";
        kstring[21] = "欧伽李";
        keywordRecognizer = new KeywordRecognizer(kstring);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs arg)
    {
        if (isstart == 1)
        {
            int is_success = 0;
            for(int i = 0; i < 12; ++i)
            {
                if (arg.text == kstring[i])
                {
                    is_success = 1;
                    break;
                }
            }
            if (is_success == 1)
            {
                text1.text = arg.text;
            }
            else
            {
                text1.text = "-------------";
            }
            
            text2.text = "采样已开始!";
            print(arg.text);
        }
        
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isstart == 0) isstart = 1;
            else isstart = 0;
            print("!!!!" + isstart);
        }
        if (isstart == 0)
        {
            text1.text = "采样未开始";
            text2.text = "按空格开始采样（按esc退出程序）";
        }
        else
        {
            text2.text = "采样已经开始";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
