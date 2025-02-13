using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public partial class SceneMgr : MonoBehaviour
{
    // SpriteAtlas 캐싱 딕셔너리
    [NonReorderable]
    Dictionary<string, SpriteAtlas> DicSpriteAtlas = new Dictionary<string, SpriteAtlas>();

    /// <summary>
    /// SpriteAtlas에서 특정 이름의 Sprite를 가져옵니다.
    /// </summary>
    /// <param name="Atlas">SpriteAtlas 이름</param>
    /// <param name="Name">Sprite 이름</param>
    /// <returns>Sprite 객체 또는 null</returns>
    public Sprite GetSpriteAtlas(string Atlas, string Name)
    {
        // 유효성 검사
        if (string.IsNullOrEmpty(Atlas))
        {
            Debug.LogWarning("SceneMgr: Atlas 이름이 null이거나 비어 있습니다.");
            return null;
        }

        if (string.IsNullOrEmpty(Name))
        {
            Debug.LogWarning("SceneMgr: Sprite 이름이 null이거나 비어 있습니다.");
            return null;
        }

        // 1. 캐시 확인
        if (DicSpriteAtlas.TryGetValue(Atlas, out SpriteAtlas cachedAtlas))
        {
            Sprite cachedSprite = cachedAtlas.GetSprite(Name);
            if (cachedSprite == null)
            {
                Debug.LogWarning($"SceneMgr: Sprite '{Name}'가 Atlas '{Atlas}'에서 발견되지 않았습니다.");
            }
            return cachedSprite;
        }

        // 2. Resources에서 SpriteAtlas 로드
        SpriteAtlas loadedAtlas = LoadSpriteAtlasFromResources(Atlas);

        if (loadedAtlas != null)
        {
            // 캐시에 추가
            DicSpriteAtlas[Atlas] = loadedAtlas;

            // Sprite 반환
            Sprite sprite = loadedAtlas.GetSprite(Name);
            if (sprite == null)
            {
                Debug.LogWarning($"SceneMgr: Sprite '{Name}'가 로드된 Atlas '{Atlas}'에서 발견되지 않았습니다.");
            }
            return sprite;
        }

        // 3. 로드 실패
        Debug.LogError($"SceneMgr: Atlas '{Atlas}'를 로드할 수 없습니다.");
        return null;
    }

    /// <summary>
    /// Resources 폴더에서 SpriteAtlas를 로드합니다.
    /// </summary>
    /// <param name="Atlas">로드할 SpriteAtlas의 이름</param>
    /// <returns>SpriteAtlas 객체 또는 null</returns>
    public SpriteAtlas LoadSpriteAtlasFromResources(string Atlas)
    {
        string path = $"Atlas/{Atlas}";
        UnityEngine.Object obj = Resources.Load(path);

        if (obj == null)
        {
            Debug.LogError($"SceneMgr: Resources에서 '{path}'를 로드할 수 없습니다.");
            return null;
        }

        if (obj is SpriteAtlas spriteAtlas)
        {
            return spriteAtlas;
        }
        else
        {
            Debug.LogError($"SceneMgr: '{path}'는 SpriteAtlas 형식이 아닙니다.");
            return null;
        }
    }
}
