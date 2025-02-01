using UnityEngine;
using UnityEngine.UI;

public class DailyQuestManager : MonoBehaviour
{
    public Toggle quest1Toggle; // 게임 접속 퀘스트
    public Toggle quest2Toggle; // 전투 퀘스트
    public Button battleButton; // 전투 버튼
    private int battleCount = 0; // 전투 버튼 누른 횟수

    void Start()
    {
        // 처음 실행 시 체크 버튼 비활성화
        quest1Toggle.isOn = false;
        quest2Toggle.isOn = false;

        // 퀘스트 1: 게임 접속 시 자동 완료 + 아이템 지급
        Invoke("CompleteQuest1", 1.0f); // 1초 후 실행 (연출 효과)

        // 전투 버튼 클릭 이벤트 등록
        battleButton.onClick.AddListener(CompleteQuest2);
    }

    void CompleteQuest1()
    {
        quest1Toggle.isOn = true; // 자동 체크
        Debug.Log("게임 접속 완료! 보상 지급됨");
        // 여기에서 보상 지급 로직 추가 가능 (예: 아이템 추가)
    }

    void CompleteQuest2()
    {
        battleCount++;

        if (battleCount >= 2) // 전투 버튼 2번 클릭 시 체크
        {
            quest2Toggle.isOn = true;
            Debug.Log("전투 완료! 퀘스트 2 완료");
        }
    }
}
