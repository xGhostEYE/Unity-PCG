using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RandomWalkMapGenerator : AbstractDungeonGenerator
{
    [SerializeField] private int iterations = 10;
    [SerializeField] private SimpleRandomWalkDATA random_walk_parameters;

    void Start(){
        generate_dungeon();
    }

    protected override void run_procedural_generation(){
        HashSet<Vector2Int> floor_positions = random_walk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.paint_floor_tiles(floor_positions);
        WallGenerator.create_walls(floor_positions,tilemapVisualizer);
    }

    protected HashSet<Vector2Int> random_walk(){
        var current_position = start_position;
        HashSet<Vector2Int> floor_positions = new HashSet<Vector2Int>();
        for (int i = 0; i < random_walk_parameters.iterations; i++){
            var path = ProceduralGenerationAlgo.simple_random_walk(current_position,random_walk_parameters.walk_length);
            floor_positions.UnionWith(path);
            if (random_walk_parameters.start_randomly_each_iteration){
                current_position = floor_positions.ElementAt(Random.Range(0,floor_positions.Count));
            }
        }
        return floor_positions;
    }


}
