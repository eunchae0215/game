using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class UI_Lobby : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject[] MenuPanels;  // 로비 내 메뉴 패널 배열
    public Text AccountNameText;     // 계정명을 표시할 텍스트

    [Header("Scene Manager")]
    public SceneMgr sceneMgr;        // 씬 매니저 인스턴스 (Unity 인스펙터에서 할당)

    void Start()
    {
        if (sceneMgr != null)
        {
            // SceneMgr에서 계정명을 가져와 UI에 적용
            AccountNameText.text = sceneMgr.AccountName;
        }
        else
        {
            Debug.LogError("SceneMgr가 연결되지 않았습니다. Unity에서 할당하세요.");
        }
    }

    // 특정 메뉴 버튼 클릭 시 해당 메뉴를 활성화
    public void OnBtnMenu(int index)
    {
        if (MenuPanels == null || MenuPanels.Length == 0)
        {
            Debug.LogError("MenuPanels가 설정되지 않았습니다.");
            return;
        }

        // 모든 메뉴를 비활성화 후 선택한 메뉴만 활성화
        foreach (GameObject menu in MenuPanels)
        {
            menu.SetActive(false);
        }

        if (index >= 0 && index < MenuPanels.Length)
        {
            MenuPanels[index].SetActive(true);
            Debug.Log($"메뉴 {index} 활성화");
        }
        else
        {
            Debug.LogError($"잘못된 메뉴 인덱스: {index}");
        }
    }

    // 게임 종료 버튼 클릭 시 실행될 함수
    public void OnBtnExit()
    {
        if (sceneMgr != null)
        {
            Debug.Log("게임을 종료합니다.");
            sceneMgr.OnExit();
        }
        else
        {
            Debug.LogError("SceneMgr가 연결되지 않았습니다.");
        }
    }

    // 로비에서 배틀 씬으로 이동하는 버튼
    public void OnBtnLobby()
    {
        if (sceneMgr != null)
        {
            Debug.Log("배틀 씬으로 전환 중...");
            sceneMgr.ChangeScene(eSCENE.eSCENE_BATTLE, true); // 로딩 화면을 거쳐 배틀 씬으로 이동
        }
        else
        {
            Debug.LogError("SceneMgr가 연결되지 않았습니다.");
        }
    }
}
