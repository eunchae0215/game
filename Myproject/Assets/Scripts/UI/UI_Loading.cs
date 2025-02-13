using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadingMgr : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("로딩 메시지가 표시될 Text UI")]
    public Text TEXTDEC;
    [Tooltip("배경 이미지 UI")]
    public Image IMGBG;

    [Header("Loading Text List")]
    [Tooltip("랜덤으로 표시될 로딩 메시지 목록")]
    public List<string> TEXTLIST;

    [Header("Sprite Settings")]
    [Tooltip("Atlas 이름")]
    public string AtlasName = "Common";
    [Tooltip("랜덤으로 표시될 스프라이트 이름 목록")]
    public List<string> SpriteNames;

    private int _currentIndex = -1; // 중복 메시지 방지용

    void Start()
    {
        // 필수 요소 확인
        if (!ValidateSettings())
        {
            Debug.LogError("UI_LoadingMgr: 필요한 설정이 누락되었습니다.");
            return;
        }

        StartCoroutine(ILoading());
    }

    /// <summary>
    /// 로딩 메시지와 배경 이미지를 설정
    /// </summary>
    private void SetLoadingDec()
    {
        // 로딩 메시지 설정
        string randomMessage = GetRandomLoadingText();
        if (TEXTDEC != null)
        {
            TEXTDEC.text = randomMessage;
        }

        // 배경 이미지 설정
        string randomSpriteName = GetRandomSpriteName();
        if (IMGBG != null && !string.IsNullOrEmpty(randomSpriteName))
        {
            Sprite sprite = Shared.SceneMgr.GetSpriteAtlas(AtlasName, randomSpriteName);
            if (sprite != null)
            {
                IMGBG.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"UI_LoadingMgr: 스프라이트를 찾을 수 없습니다. AtlasName: {AtlasName}, SpriteName: {randomSpriteName}");
            }
        }
    }

    /// <summary>
    /// 로딩 코루틴
    /// </summary>
    IEnumerator ILoading()
    {
        int count = 0;

        while (count < 2) // 2회 반복 후 종료
        {
            SetLoadingDec();
            yield return new WaitForSeconds(1f);
            count++;
        }

        // 로딩 완료 처리
        Shared.SceneMgr.CheckLoading();
    }

    /// <summary>
    /// 랜덤 로딩 텍스트를 반환
    /// </summary>
    private string GetRandomLoadingText()
    {
        if (TEXTLIST == null || TEXTLIST.Count == 0)
        {
            Debug.LogWarning("UI_LoadingMgr: TEXTLIST가 비어 있습니다.");
            return "Loading...";
        }

        int newIndex;
        do
        {
            newIndex = Random.Range(0, TEXTLIST.Count);
        } while (newIndex == _currentIndex); // 중복 메시지 방지

        _currentIndex = newIndex;
        return TEXTLIST[newIndex];
    }

    /// <summary>
    /// 랜덤 스프라이트 이름을 반환
    /// </summary>
    private string GetRandomSpriteName()
    {
        if (SpriteNames == null || SpriteNames.Count == 0)
        {
            Debug.LogWarning("UI_LoadingMgr: SpriteNames가 비어 있습니다.");
            return null;
        }

        int index = Random.Range(0, SpriteNames.Count);
        return SpriteNames[index];
    }

    /// <summary>
    /// 설정 검증
    /// </summary>
    private bool ValidateSettings()
    {
        if (TEXTDEC == null)
        {
            Debug.LogError("UI_LoadingMgr: TEXTDEC가 할당되지 않았습니다.");
            return false;
        }

        if (IMGBG == null)
        {
            Debug.LogError("UI_LoadingMgr: IMGBG가 할당되지 않았습니다.");
            return false;
        }

        if (TEXTLIST == null || TEXTLIST.Count == 0)
        {
            Debug.LogError("UI_LoadingMgr: TEXTLIST가 설정되지 않았습니다.");
            return false;
        }

        return true;
    }
}
