using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgo{
    public static HashSet<Vector2Int> simple_random_walk(Vector2Int start_position, int walk_length){
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(start_position);
        var previous_position = start_position;
        for (int i = 0; i < walk_length; i++)
        {
            var new_position = previous_position + Direction2D.get_random_cardinal_direction();
            path.Add(new_position);
            previous_position = new_position;
        }
        return path;
    }

    public static List<Vector2Int> random_walk_corridor(Vector2Int start_position, int corridor_length){
        List<Vector2Int> corridor = new List< Vector2Int>();
        var direction = Direction2D.get_random_cardinal_direction();
        var current_position = start_position;
        corridor.Add(current_position);

        for (int i = 0; i < corridor_length; i++){
            current_position +=direction;
            corridor.Add(current_position);
        }
        return corridor;
    }
}

public static class Direction2D{
    public static List<Vector2Int> cardinal_directions_list = new List<Vector2Int>{
        new Vector2Int(0,1), // up
        new Vector2Int(1,0), //right
        new Vector2Int(0,-1), //down
        new Vector2Int(-1,0) //left
    };
    public static Vector2Int get_random_cardinal_direction(){
        return cardinal_directions_list[Random.Range(0,cardinal_directions_list.Count)];
    }
}
