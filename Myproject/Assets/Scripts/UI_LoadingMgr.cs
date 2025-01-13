using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadingMgr : MonoBehaviour
{
    public Text TEXTDEC; // 로딩 문구를 표시하는 UI Text
    public Image IMGBG;  // 배경 이미지를 표시하는 UI Image

    public List<string> TEXTLIST; // 로딩 문구 리스트

    void Start()
    {
        // 코루틴 시작
        StartCoroutine(ILoading());
    }

    void SetLoadingDec()
    {
        // Null 체크: TEXTLIST가 비어 있으면 메시지 출력 후 종료
        if (TEXTLIST == null || TEXTLIST.Count == 0)
        {
            Debug.LogWarning("TEXTLIST is empty or not assigned.");
            return;
        }

        // Null 체크: TEXTDEC 또는 IMGBG가 할당되지 않은 경우
        if (TEXTDEC == null || IMGBG == null)
        {
            Debug.LogError("TEXTDEC or IMGBG is not assigned in the Inspector.");
            return;
        }

        // 랜덤 인덱스 선택
        int lan = Random.Range(0, TEXTLIST.Count);

        // 선택된 문구를 텍스트 UI에 설정
        string str = TEXTLIST[lan];
        TEXTDEC.text = str;

        // Shared.SceneMgr에서 스프라이트 가져오기
        Sprite sprite = Shared.SceneMgr.GetSpriteAtlas("Common", "Bird1 Blue_0");
        if (sprite != null)
        {
            IMGBG.sprite = sprite;
        }
        else
        {
            Debug.LogWarning("Failed to load sprite from Shared.SceneMgr.");
        }
    }

    IEnumerator ILoading()
    {
        // 첫 로딩 문구 설정
        SetLoadingDec();

        // 1초 대기
        yield return new WaitForSeconds(1f);

        // 로딩 문구 다시 설정
        SetLoadingDec();

        // Shared.SceneMgr.CheckLoading 호출
        if (Shared.SceneMgr != null)
        {
            Shared.SceneMgr.CheckLoading();
        }
        else
        {
            Debug.LogError("Shared.SceneMgr is not properly defined.");
        }
    }
}
