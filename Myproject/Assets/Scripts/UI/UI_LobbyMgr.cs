using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public partial class UI_LobbyMgr : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("로비 메뉴 패널 배열")]
    public GameObject[] GOMENU;

    [Tooltip("계정명을 표시할 UI 텍스트")]
    public Text TEXTACCOUNTNAME;

    void Start()
    {
        // SceneMgr에서 계정명을 가져와 UI에 적용
        if (Shared.SceneMgr != null)
        {
            TEXTACCOUNTNAME.text = Shared.SceneMgr.AccountName;
        }
        else
        {
            Debug.LogError("Shared.SceneMgr가 초기화되지 않았습니다. SceneMgr를 확인하세요.");
        }
    }

    // 특정 메뉴 버튼 클릭 시 해당 메뉴를 활성화
    public void OnBtnMenu(int _nIndex)
    {
        if (GOMENU == null || GOMENU.Length == 0)
        {
            Debug.LogError("GOMENU 배열이 설정되지 않았습니다.");
            return;
        }

        if (_nIndex < 0 || _nIndex >= GOMENU.Length)
        {
            Debug.LogError($"잘못된 메뉴 인덱스: {_nIndex}");
            return;
        }

        // 모든 메뉴를 비활성화하고 선택된 메뉴만 활성화
        foreach (GameObject menu in GOMENU)
        {
            menu.SetActive(false);
        }

        GOMENU[_nIndex].SetActive(true);
        Debug.Log($"메뉴 {_nIndex} 활성화됨");
    }

    // 게임 종료 버튼 클릭 시 실행될 함수
    public void OnBtnExit()
    {
        if (Shared.SceneMgr != null)
        {
            Debug.Log("게임 종료 요청됨");
            Shared.SceneMgr.OnExit();
        }
        else
        {
            Debug.LogError("Shared.SceneMgr를 찾을 수 없습니다.");
        }
    }

    // 로비에서 배틀 씬으로 이동하는 버튼
    public void OnBtnLobby()
    {
        if (Shared.SceneMgr != null)
        {
            Debug.Log("배틀 씬으로 전환 중...");
            Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_BATTLE, true);
        }
        else
        {
            Debug.LogError("Shared.SceneMgr를 찾을 수 없습니다.");
        }
    }
}
