using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private static List<Vector2Int> neighbours_4_directions = new List<Vector2Int>{
        new Vector2Int(0,1), // up
        new Vector2Int(1,0), //right
        new Vector2Int(0,-1), //down
        new Vector2Int(-1,0) //left
    };

    private static List<Vector2Int> neighbours_8_directions = new List<Vector2Int>{
        new Vector2Int(0,1), // up
        new Vector2Int(1,0), //right
        new Vector2Int(0,-1), //down
        new Vector2Int(-1,0), //left
        new Vector2Int(1,1), //diagonal
        new Vector2Int(1,-1), //diagonal
        new Vector2Int(-1,1), //diagonal
        new Vector2Int(-1,-1) //diagonal
    };

    List<Vector2Int> graph;

    public Graph(IEnumerable<Vector2Int> vertices){
        graph = new List<Vector2Int>(vertices);
    }

    public List<Vector2Int> get_neighbours_4_direcitons(Vector2Int start_position){
        return get_neighbours(start_position, neighbours_4_directions);
    }

    public List<Vector2Int> get_neighbours_8_directions(Vector2Int start_position){
        return get_neighbours(start_position, neighbours_8_directions);
    }

    private List<Vector2Int> get_neighbours(Vector2Int start_position, List<Vector2Int> neighbours_offset_list){
        List<Vector2Int> neighbours = new List<Vector2Int>();
        foreach (var neighbour_direction in neighbours_offset_list){
            Vector2Int potential_neighbour = start_position + neighbour_direction;
            if(graph.Contains(potential_neighbour)){
                neighbours.Add(potential_neighbour);
            }
        }
        return neighbours;
    }
}
