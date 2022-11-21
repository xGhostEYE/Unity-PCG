using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid_Manager : MonoBehaviour {
    private int grid_width, grid_height;

    [SerializeField] private Tile background_prefab, platform_prefab, room_background_prefab;

    [SerializeField] private GameObject enemy, portal, slime, player, exit;


    void Start() {
        GenerateGrid(); 
    }

    void GenerateGrid(){
        grid_width = UnityEngine.Random.Range(40,60);
        grid_height = UnityEngine.Random.Range(70,100);
        Debug.Log(grid_width);
        Dictionary<Vector2, Tile> background_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> floor_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> platform_tiles = new Dictionary<Vector2, Tile>();
        int numer_of_portals = 0;
        bool alread_spawned_left = false;
        bool alread_spawned_right = false;
        bool alread_spawned_middle = false;
        bool alread_spawned_exit = false;
        int chance_to_spawn_exit = UnityEngine.Random.Range(1,3);
        // place background and floor
        for (int x = 0; x < grid_width; x++) {
            // place floor
            for (int y = 0; y < grid_height; y++){
                if(y == 0){
                    if(x==(grid_width/2)-10){
                        Instantiate(player, new Vector3(x, y), Quaternion.identity);
                    }
                    var floor = Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
                    floor.name = $"floor_Tile {x} {y}";
                    floor_tiles[new Vector2(x, y)] = floor;
                }

                // place backgroun
                var spawnedTile = Instantiate(background_prefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                background_tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        // place walls
        
        for (int y = 0; y < grid_height; y++){
            var left_wall = Instantiate(platform_prefab, new Vector3(0, y), Quaternion.identity);
            left_wall.name = $"left_wall_Tile {0} {y}";
            var right_wall = Instantiate(platform_prefab, new Vector3(grid_width, y), Quaternion.identity);
            right_wall.name = $"right_right_Tile {0} {y}";
            // spawn exit
            if(chance_to_spawn_exit == 1 && alread_spawned_exit == false && y == grid_height-6){
                Instantiate(exit, new Vector3(1, y), Quaternion.identity);
                alread_spawned_exit = true;
            }
            if(chance_to_spawn_exit == 2 && alread_spawned_exit == false && y == grid_height-6){
                Instantiate(exit, new Vector3(grid_width-1, y), Quaternion.identity);
                alread_spawned_exit = true;
            }
        }
        // place platforms
        for (int y = 6; y < grid_height; y++){
            if(y >= grid_height-6){
                break;
            }

            // place platforms on left side
            int random_chance_spawn = UnityEngine.Random.Range(1,3);
            int platform_length_left = UnityEngine.Random.Range(4,7);
            for (int x = 0; x < platform_length_left; x++) {
                var platform = Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
                platform.name = $"left_platform_Tile {x} {y}";
                platform_tiles[new Vector2(x, y)] = platform;
                // spawn enemy
                if(random_chance_spawn == 2){
                    if(x == platform_length_left-2){
                        Instantiate(enemy, new Vector3(x, y+1), Quaternion.identity);
                    }
                }
                // spawn portal
                if(random_chance_spawn == 1 && numer_of_portals<3 && alread_spawned_left == false){
                    if(x == platform_length_left-2 && y>=grid_height/2){
                        Instantiate(portal, new Vector3(x, y+1), Quaternion.identity);
                        alread_spawned_left = true;
                    }
                }

            }
            // place enemy if platform is big enough

            // place platforms on right side
            random_chance_spawn = UnityEngine.Random.Range(1,3);
            int platform_length_right = UnityEngine.Random.Range(4,7);
            for (int x = grid_width-platform_length_right; x < grid_width; x++) {
                var platform = Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
                platform.name = $"right_platform_Tile {x} {y}";
                platform_tiles[new Vector2(x, y)] = platform;
                // spawn enemy
                if(random_chance_spawn == 2){
                    if(x == grid_width-2){
                        Instantiate(enemy, new Vector3(x, y+1), Quaternion.identity);
                    }
                }
                // spawn portal
                if(random_chance_spawn == 1 && numer_of_portals<3 && alread_spawned_right == false){
                    if(x == grid_width-2 && y>=grid_height/3){
                        Instantiate(portal, new Vector3(x, y+1), Quaternion.identity);
                        alread_spawned_right = true;
                    }
                }    
            }
            // place platforms on middle
            random_chance_spawn = UnityEngine.Random.Range(1,3);
            int platform_length_middle = UnityEngine.Random.Range(4,7);
            for (int x = grid_width-(grid_width/2); x < (grid_width/2)+platform_length_middle; x++) {
                // should make it randomly go left or right in the middle
                var platform = Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
                platform.name = $"middle_platform_Tile {x} {y}";
                platform_tiles[new Vector2(x, y)] = platform;
                // spawn enemy
                if(random_chance_spawn == 2){
                    if(x == (grid_width/2)+platform_length_middle-2){
                        Instantiate(enemy, new Vector3(x, y+1), Quaternion.identity);
                    }
                }
                // spawn portal
                if(random_chance_spawn == 1 && numer_of_portals<3 && alread_spawned_middle == false){
                    if(x == (grid_width/2)+platform_length_middle-2 && y>=grid_height/4){
                        Instantiate(portal, new Vector3(x, y+1), Quaternion.identity);
                        alread_spawned_middle = true;
                    }
                }
            }
            y = y+6;
            // place platforms in between middle and sides
            for (int x = grid_width-(grid_width/4)-3; x < grid_width-(grid_width/4)+UnityEngine.Random.Range(2,4); x++) {
                // should make it randomly go left or right in the middle
                var platform = Instantiate(platform_prefab, new Vector3(x, y-3), Quaternion.identity);
                platform.name = $"right_middle_platform_Tile {x} {y}";
                platform_tiles[new Vector2(x, y)] = platform;          
            }
            for (int x = (grid_width/2)-(grid_width/4)-3; x < (grid_width/2)-(grid_width/4)-3+UnityEngine.Random.Range(2,4); x++) {
                // should make it randomly go left or right in the middle
                var platform = Instantiate(platform_prefab, new Vector3(x, y-3), Quaternion.identity);
                platform.name = $"left_middle_platform_Tile {x} {y}";
                platform_tiles[new Vector2(x, y)] = platform;          
            }
            
        }
        
       List<Dictionary<Vector2, Tile>> secret_rooms = GenerateRooms();




    }

    List<Dictionary<Vector2, Tile>> GenerateRooms(){
        grid_width = UnityEngine.Random.Range(15,20);
        grid_height = 15;
        Dictionary<Vector2, Tile> secret_room = new Dictionary<Vector2, Tile>();
        List<Dictionary<Vector2, Tile>> rooms_list = new List<Dictionary<Vector2, Tile>>();
        
        for (int i = 0; i < 3; i++){
            List<int> number_rooms = new List<int>();
            number_rooms.Add(120);
            number_rooms.Add(-120);
            number_rooms.Add(200);
            for (int x = 0; x < grid_width; x++) {
                for (int y = 0; y < grid_height; y++) {

                    var spawnedTile = Instantiate(room_background_prefab, new Vector3(x+number_rooms[i], y+number_rooms[i]), Quaternion.identity);
                    spawnedTile.name = $"room_Tile_{i} {x} {y}";
                    secret_room[new Vector2(x, y)] = spawnedTile;
                    if(x==0 && y==0){
                        Instantiate(portal, new Vector3(x+number_rooms[i]+4, y+number_rooms[i]+4), Quaternion.identity);
                        Instantiate(enemy, new Vector3(grid_width+number_rooms[i]-5, y+number_rooms[i]), Quaternion.identity);
                        Instantiate(slime, new Vector3(grid_width+number_rooms[i]-1, y+number_rooms[i]), Quaternion.identity);
                    }
                }

            }
            rooms_list.Add(secret_room);
            secret_room.Clear();
        }


        return rooms_list;
    }


    // public Tile GetTileAtPosition(Vector2 pos) {
    //     if (_tiles.TryGetValue(pos, out var tile)) return tile;
    //     return null;
    // }
}