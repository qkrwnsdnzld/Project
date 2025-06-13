using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTilePainter : MonoBehaviour
{
    public Tilemap tilemap;            // ���� Ÿ���� �׸� Ÿ�ϸ�
    public TileBase[] randomTiles;     // ���� Ÿ�ϵ�
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
