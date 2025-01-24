using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 가방(UI) 관리 클래스 - Scroll View 적용
/// </summary>
public class UI_Bag : UI_Base
{
    [Header("UI Elements")]
    [Tooltip("아이템이 배치될 부모 오브젝트 (Scroll View Content)")]
    public Transform TRPOS;  // Scroll View의 Content에 해당

    [Tooltip("아이템 프리팹")]
    public GameObject itemPrefab;

    [Header("Inventory Settings")]
    [Tooltip("인벤토리 아이템 개수")]
    public int InvenCount = 10;

    private Dictionary<int, ItemElement> IEMap = new Dictionary<int, ItemElement>();

    /// <summary>
    /// UI 초기화 시 실행 (큐에 추가)
    /// </summary>
    private void Awake()
    {
        base.SetEnQueue();
        Debug.Log("UI_Bag 초기화 완료.");
    }

    /// <summary>
    /// 인벤토리 아이템 불러오기
    /// </summary>
    private void Start()
    {
        LoadInventoryItems();
    }

    /// <summary>
    /// 아이템을 스크롤 뷰에 동적으로 추가
    /// </summary>
    private void LoadInventoryItems()
    {
        if (TRPOS == null)
        {
            Debug.LogError("TRPOS(Content)가 할당되지 않았습니다. Unity 인스펙터에서 설정하세요.");
            return;
        }

        if (itemPrefab == null)
        {
            Debug.LogError("아이템 프리팹이 설정되지 않았습니다.");
            return;
        }

        // 기존 아이템이 있으면 삭제
        foreach (Transform child in TRPOS)
        {
            Destroy(child.gameObject);
        }

        IEMap.Clear(); // 기존 아이템 데이터 초기화

        for (int i = 0; i < InvenCount; ++i)
        {
            GameObject gobj = Instantiate(itemPrefab, TRPOS);
            gobj.transform.localScale = Vector3.one;  // 스케일 초기화

            ItemElement ie = gobj.GetComponent<ItemElement>();
            if (ie == null)
            {
                Debug.LogError("ItemElement 컴포넌트를 찾을 수 없습니다.");
                return;
            }

            // 아이템 레벨 및 수량 무작위 설정
            int randomLevel = Random.Range(1, 100);
            int randomCount = Random.Range(1, 100000);

            ie.SetItemInfo($"아이템 {i}", null, randomLevel, randomCount);

            IEMap.Add(i, ie);
            Debug.Log($"아이템 {i} 추가됨: Level={randomLevel}, Count={randomCount}");
        }

        UpdateScrollViewSize();
    }

    /// <summary>
    /// Scroll View의 Content 크기 업데이트
    /// </summary>
    private void UpdateScrollViewSize()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(TRPOS.GetComponent<RectTransform>());
    }

    /// <summary>
    /// 뒤로가기 버튼 클릭 시 호출 (UI 닫기)
    /// </summary>
    public override void OnBtnBack()
    {
        gameObject.SetActive(false);
        Debug.Log("UI_Bag 비활성화됨.");
    }
}
