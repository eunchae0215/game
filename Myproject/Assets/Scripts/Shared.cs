using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 공유되는 전역 클래스 (싱글톤 패턴이 아닌 정적 클래스 활용)
/// 게임의 주요 매니저 및 전역 데이터 관리
/// </summary>
public static class Shared
{
    // 주요 매니저 인스턴스 선언 (씬 매니저, 존, 배틀 매니저)
    public static SceneMgr SceneMgr;   // 씬 전환 및 관리를 위한 매니저
    public static Zone Zone;           // 게임 존(맵) 관리 매니저
    public static BattleMgr BattleMgr; // 전투 시스템 관리 매니저

    // UI 관리 큐 (대기 중인 UI 작업을 관리)
    public static Queue<UI_Base> QueUI = new Queue<UI_Base>();

    // 테이블 매니저 (데이터 초기화 및 접근)
    public static Tabel_Mgr TabelMgr;

    /// <summary>
    /// TableMgr가 존재하지 않으면 초기화
    /// </summary>
    /// <returns>초기화된 Tabel_Mgr 객체</returns>
    public static Tabel_Mgr InitTableMgr()
    {
        if (TabelMgr == null)
        {
            TabelMgr = new Tabel_Mgr();
            TabelMgr.Init();
            Debug.Log("Table Manager Initialized");
        }
        else
        {
            Debug.Log("Table Manager already initialized");
        }

        return TabelMgr;
    }
}
