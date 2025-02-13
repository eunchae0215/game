using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 배틀 UI 관리 클래스
/// </summary>
public class UI_Battle : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("UI_Battle 초기화 완료.");
    }

    /// <summary>
    /// 배틀에서 로비로 이동하는 버튼
    /// </summary>
    public void OnBtnBattle()
    {
        if (Shared.SceneMgr != null)
        {
            Debug.Log("로비 씬으로 이동 중...");
            Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOBBY, true); // 로딩 화면을 거쳐 로비 이동
        }
        else
        {
            Debug.LogError("SceneMgr가 초기화되지 않았습니다. SceneMgr를 확인하세요.");
        }
    }
}
