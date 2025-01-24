using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 가방(UI) 관리 클래스
/// </summary>
public class UI_Bag : UI_Base
{
    [Header("UI Elements")]
    [Tooltip("아이템이 배치될 부모 오브젝트")]
    public Transform TRPOS;

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
        Debug.Log("UI_Bag이(가) 초기화되었습니다.");
    }

    /// <summary>
    /// 인벤토리 아이템 생성 및 배치
    /// </summary>
    private void Start()
    {
        LoadInventoryItems();
    }

    /// <summary>
    /// 아이템을 로드하여 인벤토리에 추가
    /// </summary>
    private void LoadInventoryItems()
    {
        if (TRPOS == null)
        {
            Debug.LogError("TRPOS가 할당되지 않았습니다. Unity 인스펙터에서 설정하세요.");
            return;
        }

        for (int i = 0; i < InvenCount; ++i)
        {
            // 프리팹 로드
            UnityEngine.Object obj = Resources.Load("Prefabs/Element/ItemElement");

            if (obj == null)
            {
                Debug.LogError("ItemElement 프리팹을 찾을 수 없습니다. 경로를 확인하세요.");
                return;
            }

            // 프리팹 인스턴스 생성
            GameObject gobj = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;

            if (gobj == null)
            {
                Debug.LogError("아이템 프리팹 인스턴스를 생성할 수 없습니다.");
                return;
            }

            gobj.transform.SetParent(TRPOS, false);  // 부모 설정 및 로컬 위치 유지

            // 아이템 요소 할당
            ItemElement ie = gobj.GetComponent<ItemElement>();

            if (ie == null)
            {
                Debug.LogError("ItemElement 컴포넌트를 찾을 수 없습니다.");
                return;
            }

            // 아이템 레벨 및 수량 무작위 설정
            ie.TEXTLEVEL.text = Random.Range(1, 100).ToString();
            ie.TEXTCOUNT.text = Random.Range(1, 100000).ToString();

            // 아이템을 Dictionary에 추가
            IEMap.Add(i, ie);
            Debug.Log($"아이템 {i} 추가됨: Level={ie.TEXTLEVEL.text}, Count={ie.TEXTCOUNT.text}");
        }
    }

    /// <summary>
    /// 뒤로가기 버튼 클릭 시 호출 (UI 닫기)
    /// </summary>
    public override void OnBtnBack()
    {
        gameObject.SetActive(false);
        Debug.Log("UI_Bag이(가) 비활성화되었습니다.");
    }
}
