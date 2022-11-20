using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ItemPLacementHelper
{
    Dictionary<PlacementType, HashSet<Vector2Int>>
        tile_by_type = new Dictionary<PlacementType, HashSet<Vector2Int>>();
    HashSet<Vector2Int> room_floor_no_corrider;

    public ItemPLacementHelper(HashSet<Vector2Int> room_floor, HashSet<Vector2Int> room_floor_no_corrider){
        Graph graph = new Graph(room_floor);
        this.room_floor_no_corrider = room_floor_no_corrider;
        foreach (var position in room_floor_no_corrider){
            int neighbours_count_8_directions = graph.get_neighbours_8_directions(position).Count;
            PlacementType type = neighbours_count_8_directions < 8 ? PlacementType.NearWall : PlacementType.OpenSpace;

            if(tile_by_type.ContainsKey(type) == false){
                tile_by_type[type] = new HashSet<Vector2Int>();
            }

            if(type == PlacementType.NearWall && graph.get_neighbours_4_direcitons(position).Count < 4){
                continue;
            }

            tile_by_type[type].Add(position);
        }       
    }

    public Vector2? get_item_placement_position(PlacementType placement_type, int iterations_max, Vector2Int size, bool add_offset){
        int item_area = size.x * size.y;
        if(tile_by_type[placement_type].Count < item_area){
            return null;
        }

        int iteration = 0;
        while(iteration<iterations_max){
            iteration++;
            int index = UnityEngine.Random.Range(0,tile_by_type[placement_type].Count);
            Vector2Int position = tile_by_type[placement_type].ElementAt(index);

            if(item_area>1){
                var (result, placement_positions) = place_big_item(position, size, add_offset);

                if(result == false){
                    continue;
                }

                tile_by_type[placement_type].ExceptWith(placement_positions);
                tile_by_type[PlacementType.NearWall].ExceptWith(placement_positions);
            }
            else{
                tile_by_type[placement_type].Remove(position);
            }

            return position;
        }
        return null;
    }

    private (bool, List<Vector2Int>) place_big_item(Vector2Int original_position, Vector2Int size, bool add_offset){
        List<Vector2Int> positions = new List<Vector2Int>(){
            original_position
        };
        int maxX = add_offset ? size.x + 1 : size.x;
        int maxY = add_offset ? size.y + 1 : size.y;
        int minX = add_offset ? -1 : 0;
        int minY = add_offset ? -1 : 0;

        for (int row = minX; row<= maxX;row++){
            for(int col = minY; col <= maxY;col++){
                if(col==0 && row==0){
                    continue;
                }
                Vector2Int new_post_to_check = new Vector2Int(original_position.x + row, original_position.y + col);
                if(room_floor_no_corrider.Contains(new_post_to_check) == false){
                    return (false, positions);
                }
                positions.Add(new_post_to_check);
            }
        }
        return (true, positions);
    }

}



public enum PlacementType{
    OpenSpace, NearWall
}
