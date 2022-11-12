using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator 
{
    public static void create_walls(HashSet<Vector2Int> floor_positions, TilemapVisualizer tilemapVisualizer){
        var basic_wall_positions = find_walls_in_directions(floor_positions,Direction2D.cardinal_directions_list);
        foreach (var position in basic_wall_positions)
        {
            tilemapVisualizer.paint_single_basic_wall(position);
        }
    }

    private static HashSet<Vector2Int> find_walls_in_directions(HashSet<Vector2Int> floor_positions, List<Vector2Int> directions_list)
    {
        HashSet<Vector2Int> wall_positions = new HashSet<Vector2Int>();
        foreach (var position in floor_positions)
        {
            foreach (var direction in directions_list)
            {
                var neighbour_position = position + direction;
                if(floor_positions.Contains(neighbour_position) == false){
                    wall_positions.Add(neighbour_position);
                }
            }
        }
        return wall_positions;
    }
}
