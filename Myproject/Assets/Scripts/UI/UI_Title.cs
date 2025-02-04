using UnityEngine;
using UnityEngine.UI;

public class UI_Title : MonoBehaviour
{
    [Header("Character UI")]
    public UI_Character uiCharacter;  // 캐릭터 UI 객체
    public GameObject characterPanel; // 캐릭터 패널 UI
    public Transform characterTransform; // 캐릭터 오브젝트의 위치 조정용

    [Header("UI Panels")]
    public GameObject ItemPanel;  // 아이템 UI 패널
    public GameObject ShopPanel;  // 상점 UI 패널
    public GameObject OptionPanel; // 옵션 UI 패널
    public GameObject BagPanel;    // 가방 UI 패널
    public GameObject CloseButton; // 닫기 버튼

    [Header("Player Info UI")]
    public Text playerNameText;  // 캐릭터 이름
    public Slider HpSlider;       // HP 게이지
    public Slider MpSlider;       // MP 게이지
    public Text HpText;           // HP 값 텍스트
    public Text MpText;           // MP 값 텍스트

    void Start()
    {
        // 초기 HP 및 MP 값 설정
        HpSlider.value = 0.5f;
        MpSlider.value = 0.4f;

        Debug.Log("UI_Title 초기화 완료");
    }

    void Update()
    {
        // 필요시 업데이트 로직 추가
    }

    /// <summary>
    /// 캐릭터 버튼 클릭 시 UI 활성화
    /// </summary>
    public void OnBtnCharacter()
    {
        Debug.Log("OnBtnCharacter 버튼 클릭");

        characterPanel.SetActive(true);

        // 캐릭터 UI 관련 오브젝트 활성화
        characterTransform.gameObject.SetActive(true);
        uiCharacter.gameObject.SetActive(true);
        //closeButton.SetActive(false); !!!!!!!!!!!!!!!!이거 만들어야함!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        Debug.Log($"캐릭터 이름: {playerNameText.text}");
    }

    /// <summary>
    /// 아이템 버튼 클릭 시 UI 활성화
    /// </summary>
    public void OnBtnItem()
    {
        Debug.Log("OnBtnItem 버튼 클릭");
        ItemPanel.SetActive(true);
    }

    /// <summary>
    /// 상점 버튼 클릭 시 UI 활성화
    /// </summary>
    public void OnBtnShop()
    {
        Debug.Log("OnBtnShop 버튼 클릭");
        ShopPanel.SetActive(true);
    }

    /// <summary>
    /// 가방 버튼 클릭 시 UI 활성화
    /// </summary>
    public void OnBtnBag()
    {
        Debug.Log("OnBtnBag 버튼 클릭");
        BagPanel.SetActive(true);
    }

    /// <summary>
    /// 옵션 버튼 클릭 시 UI 활성화
    /// </summary>
    public void OnBtnOption()
    {
        Debug.Log("OnBtnOption 버튼 클릭");
        OptionPanel.SetActive(true);
    }

    
}
