using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DustSpawner : MonoBehaviour
{
    [Header("Movement Settings")]
    public GameObject dustPrefab;
    public Tilemap groundTilemap;         // Tilemap nền nhà
    public LayerMask collisionLayer;      // Layer chứa vật cản (Obstacle, Wall...)
    public float checkRadius = 0.2f;      // Bán kính kiểm tra va chạm
    public int dustCount = 10;            // Số lượng bụi tối đa

    void Start()
    {
        if (groundTilemap == null)
        {
            Debug.LogError("⚠️ groundTilemap chưa được gán trong Inspector!");
            return;
        }

        if (dustPrefab == null)
        {
            Debug.LogError("⚠️ dustPrefab chưa được gán trong Inspector!");
            return;
        }

        List<Vector3> validPositions = new List<Vector3>();

        // Lặp qua toàn bộ các cell có tile
        foreach (Vector3Int pos in groundTilemap.cellBounds.allPositionsWithin)
        {
            if (!groundTilemap.HasTile(pos)) continue;

            Vector3 worldPos = groundTilemap.GetCellCenterWorld(pos);

            // Kiểm tra xem có vật cản tại vị trí này không (bằng OverlapCircle)
            Collider2D hit = Physics2D.OverlapCircle(worldPos, checkRadius, collisionLayer);
            if (hit == null)
            {
                validPositions.Add(worldPos);
            }
        }

        // Shuffle vị trí hợp lệ
        Shuffle(validPositions);

        int spawnAmount = Mathf.Min(dustCount, validPositions.Count);
        Debug.Log($"✅ Có {validPositions.Count} vị trí hợp lệ. Đang spawn {spawnAmount} bụi...");

        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(dustPrefab, validPositions[i], Quaternion.identity);
        }
    }

    // Thuật toán Fisher-Yates để shuffle
    void Shuffle(List<Vector3> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            Vector3 temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}
