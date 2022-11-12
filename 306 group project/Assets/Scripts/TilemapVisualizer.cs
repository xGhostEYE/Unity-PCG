using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap floor_tilemap, wall_tilemap;
    [SerializeField] private TileBase floor_tile, wall_top;


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

    public void Clear(){
        floor_tilemap.ClearAllTiles();
        wall_tilemap.ClearAllTiles();
    }

    internal void paint_single_basic_wall(Vector2Int position){
        paint_single_tile(wall_tilemap, wall_top, position);
    }
}
