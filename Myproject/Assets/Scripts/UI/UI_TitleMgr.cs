using UnityEngine;
using UnityEngine.UI;

public class UI_TitleMgr : MonoBehaviour
{


    void Start()
    {
     
    }

    void Update()
    {
        // 필요할 경우 업데이트 로직 추가
    }

    /// <summary>
    /// 타이틀 화면에서 로그인 화면으로 전환
    /// </summary>
    public void OnBtnTitle()
    {
        if (Shared.SceneMgr != null)
        {
            Debug.Log("로그인 씬으로 전환 중...");
            Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOGIN);
        }
        else
        {
            Debug.LogError("SceneMgr 인스턴스가 존재하지 않습니다.");
        }
    }
}
