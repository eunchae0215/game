using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadingMgr : MonoBehaviour
{
    public Text TEXTDEC;
    public Image IMGBG;

    public List<string> TEXTLIST;

    void Start()
    {
        StartCoroutine(ILoading());
    }

    void SetLoadingDec()
    {
        int lan = Random.RandomRange(0, 3);

        string str = TEXTLIST[lan];

        TEXTDEC.text = str;

        IMGBG.sprite = Shared.SceneMgr.GetSpriteAtlas("Common", "Bird1 Blue_0");
    }

    IEnumerator ILoading()
    {
        SetLoadingDec();

        int Count = 0;

        while(true)
        {
            yield return new WaitForSeconds(1f);

            SetLoadingDec();

            Count++;

            if (1 == Count)
                break;
        }

        Shared.SceneMgr.CheckLoading();
    }
}
