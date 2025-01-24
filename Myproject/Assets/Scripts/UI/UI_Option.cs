using UnityEngine;

/// <summary>
/// 옵션 메뉴 UI 관리 클래스
/// </summary>
public class UI_Option : UI_Base
{
    /// <summary>
    /// 객체가 활성화될 때 호출되는 초기화 메서드
    /// </summary>
    private void Awake()
    {
        base.SetEnQueue();  // UI 큐에 추가
    }

    /// <summary>
    /// 사운드 옵션 선택 버튼 클릭 시 호출
    /// </summary>
    /// <param name="_nIndex">선택된 인덱스 (0: 사운드 ON, 1: 사운드 OFF)</param>
    public void OnBtnSelect(int _nIndex)
    {
        if (Shared.SceneMgr != null)
        {
            Shared.SceneMgr.Sound = (_nIndex == 0);
            Debug.Log($"사운드 설정: {Shared.SceneMgr.Sound}");
        }
        else
        {
            Debug.LogError("Shared.SceneMgr가 할당되지 않았습니다.");
        }
    }

    /// <summary>
    /// 옵션 메뉴 닫기 버튼 클릭 시 호출 (UI 비활성화)
    /// </summary>
    public override void OnBtnBack()
    {
        gameObject.SetActive(false);
        Debug.Log("옵션 UI 비활성화");
    }
}
