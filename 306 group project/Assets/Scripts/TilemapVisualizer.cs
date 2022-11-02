using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floor_tilemap;
    [SerializeField] private TileBase floor_tile;

    public void paint_floor_tiles(IEnumerable<Vector2Int> floor_positions){
        paint_tiles(floor_positions,floor_tilemap,floor_tile);
    }

    private void paint_tiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile){
        foreach (var position in positions){
            paint_single_tile(tilemap,tile,position);
        }
    }

    private void paint_single_tile(Tilemap tilemap, TileBase tile, Vector2Int position){
        var tile_position = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tile_position,tile);
    }
}
