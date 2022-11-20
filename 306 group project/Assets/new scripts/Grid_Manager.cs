using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid_Manager : MonoBehaviour {
    private int grid_width, grid_height;

    [SerializeField] private Tile background_prefab, platform_prefab;

    [SerializeField] private Transform _cam;


    void Start() {
        GenerateGrid();
        
    }

    void GenerateGrid(){
        grid_width = UnityEngine.Random.Range(40,60);
        grid_height = UnityEngine.Random.Range(70,100);
        Dictionary<Vector2, Tile> background_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> floor_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> platform_tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < grid_width; x++) {
            for (int y = 0; y < grid_height; y++){
                if(y == 0){
                    var floor = Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
                    floor.name = $"floor_Tile {x} {y}";
                    floor_tiles[new Vector2(x, y)] = floor;
                }

                if((x-3 >= 0 && y-6 >=0)&&(x+3 <= grid_width && y+6 <=grid_height)){
                    var platform = Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
                    platform.name = $"platform_Tile {x} {y}";
                    platform_tiles[new Vector2(x, y)] = platform;
                }
                var spawnedTile = Instantiate(background_prefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                background_tiles[new Vector2(x, y)] = spawnedTile;
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

                    var spawnedTile = Instantiate(background_prefab, new Vector3(x+number_rooms[i], y+number_rooms[i]), Quaternion.identity);
                    spawnedTile.name = $"room_Tile {x} {y}";
                    secret_room[new Vector2(x, y)] = spawnedTile;
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