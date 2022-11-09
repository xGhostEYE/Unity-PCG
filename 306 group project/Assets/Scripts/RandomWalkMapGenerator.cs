using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RandomWalkMapGenerator : MonoBehaviour
{
    [SerializeField] protected Vector2Int start_position = Vector2Int.zero;
    [SerializeField] private int iterations = 10;
    [SerializeField] public int walk_length = 10;
    [SerializeField] public bool start_randomly_each_iteration = true;
    [SerializeField] private TilemapVisualizer tilemapVisualizer;


    void Start(){
        run_procedural_generation();
    }

    public void run_procedural_generation(){
        HashSet<Vector2Int> floor_positions = random_walk();
        tilemapVisualizer.paint_floor_tiles(floor_positions);
    }

    protected HashSet<Vector2Int> random_walk(){
        var current_position = start_position;
        HashSet<Vector2Int> floor_positions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++){
            var path = ProceduralGenerationAlgo.simple_random_walk(current_position,walk_length);
            floor_positions.UnionWith(path);
            if (start_randomly_each_iteration){
                current_position = floor_positions.ElementAt(Random.Range(0,floor_positions.Count));
            }
        }
        return floor_positions;
    }
}
