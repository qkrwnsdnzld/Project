using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTilePainter : MonoBehaviour
{
    public Tilemap tilemap;            // 랜덤 타일을 그릴 타일맵
    public TileBase[] randomTiles;     // 섞을 타일들
    public int width = 10;
    public int height = 10;

    void Start()
    {
        PaintRandomTiles();
    }

    void PaintRandomTiles()
    {
        for (int x = -width / 2; x < width / 2; x++)
        {
            for (int y = -height / 2; y < height / 2; y++)
            {
                TileBase tile = randomTiles[Random.Range(0, randomTiles.Length)];
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}
