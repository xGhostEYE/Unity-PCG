using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AssetPlacement{
    
    public static void place_assets(HashSet<Vector2Int> floor_positions, TilemapVisualizer tilemapVisualizer)
    {
        var area_around_tile = Direction2D.cardinal_directions_list;
        
        var wall_positions = WallGenerator.find_walls_in_directions(floor_positions, area_around_tile);
        HashSet<Vector2Int> asset_positions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> possible_positions = new HashSet<Vector2Int>();
        foreach (var position in floor_positions){
            foreach (var direction in area_around_tile)
            {
                int random_num = Random.Range(0,3);
                Debug.Log(random_num);
                var neighbour_position = position + direction + direction + direction;
                if(floor_positions.Contains(neighbour_position) == true && random_num == 1){
                    possible_positions.Add(neighbour_position);
                    break;
                }
            }
        }

        tilemapVisualizer.paint_single_gameobject(possible_positions);

    }

}
