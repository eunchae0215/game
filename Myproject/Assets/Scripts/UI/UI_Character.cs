using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Character : MonoBehaviour
{
    public Text TEXTHP;

    int Hp = 10000;
    // Start is called before the first frame update
    void Start()
    {
        TEXTHP.text = Hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClose()
    {
        gameObject.SetActive(false);
    }
}