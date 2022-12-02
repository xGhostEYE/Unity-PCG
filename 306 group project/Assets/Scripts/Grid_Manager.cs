using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid_Manager : MonoBehaviour
{
    private int grid_width, grid_height;

    [SerializeField] private Tile background_prefab, wall_prefab, floor_prefab, room_background_prefab;

    [SerializeField] private GameObject enemy_flying, enemy_walking, boss_portal_prefab,
    enemy_wall_crawl, slime_prefab, player_prefab, exit_prefab, platform_prefab, 
    platform_large_prefab, platform_prefab_moving, fence_1_prefab, fence_2_prefab, 
    fence_3_prefab, rock_head_prefab, sign_prefab, tree_trunk_1_prefab, tree_trunk_3_prefab, 
    tree_trunk_4_prefab, stone_1_prefab,stone_2_prefab,stone_3_prefab,stone_4_prefab,stone_6_prefab,stone_7_prefab,
    grass_1_prefab, grass_2_prefab, grass_3_prefab, boss_prefab,
    grass_4_prefab, grass_5_prefab, grass_6_prefab, grass_7_prefab, grass_8_prefab, tree_1_prefab,
    tree_2_prefab,tree_3_prefab,tree_4_prefab,tree_5_prefab,tree_6_prefabtree_7_prefab,tree_8_prefab,tree_9_prefab,
     flower_1_prefab,flower_2_prefab,flower_3_prefab,flower_4_prefab, flower_5_prefab,flower_6_prefab,
     cliff_prefab,cliff_figures_prefab, large_vine_prefab, large_leaf_left, large_leaf_right;

    [SerializeField] private GameObject acidSpawner;

    [SerializeField] private GameObject egg;

    [SerializeField] private GameObject PortalIn, PortalOut;

    List<GameObject> list_of_stones;
    List<GameObject> list_of_fences;
    List<GameObject> list_of_tree_trunks;
    List<GameObject> list_of_grass_plants;
    List<GameObject> list_of_trees;
    List<GameObject> list_of_flowers;
    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        grid_width = UnityEngine.Random.Range(40, 50);
        grid_height = UnityEngine.Random.Range(70, 90);
        int platform_size;
        Dictionary<Vector2, Tile> background_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> floor_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> platform_tiles = new Dictionary<Vector2, Tile>();

        bool alread_spawned_exit = false;
        bool spawned_first_floor = false;
        bool spawned_second_floor = false;
        bool spawned_third_floor = false;
        int chance_to_spawn_exit = UnityEngine.Random.Range(1, 3);
        acidSpawner.transform.position = new Vector3(0, -5);
        acidSpawner.GetComponent<AcidSpawner>().SpawnAcid();

        list_of_stones = new List<GameObject>(){stone_1_prefab,stone_2_prefab,stone_3_prefab,stone_4_prefab,stone_6_prefab,stone_7_prefab};
        list_of_fences = new List<GameObject>(){fence_1_prefab, fence_2_prefab, fence_3_prefab};
        list_of_tree_trunks = new List<GameObject>(){tree_trunk_1_prefab, tree_trunk_3_prefab, tree_trunk_4_prefab};
        list_of_grass_plants = new List<GameObject>(){grass_2_prefab, grass_3_prefab,
        grass_4_prefab, grass_5_prefab, grass_6_prefab, grass_7_prefab, grass_8_prefab};
        list_of_trees = new List<GameObject>(){tree_1_prefab,tree_2_prefab,tree_3_prefab,
        tree_4_prefab,tree_5_prefab,tree_6_prefabtree_7_prefab,tree_8_prefab,tree_9_prefab};
        list_of_flowers = new List<GameObject>(){flower_1_prefab,flower_2_prefab,flower_3_prefab,flower_4_prefab,
        flower_5_prefab,flower_6_prefab};

        // place background and floor
        for (int x = 0; x < grid_width; x++)
        {
            // place floor
            for (int y = 0; y < grid_height; y++)
            {
                if (y == 0)
                {
                    var floor = Instantiate(floor_prefab, new Vector3(x, y), Quaternion.identity);
                    floor.name = $"floor_Tile {x} {y}";
                    floor_tiles[new Vector2(x, y)] = floor;
                    Instantiate(grass_8_prefab, new Vector3(x, y+1), Quaternion.identity);
                    generate_assets(x,y,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones,list_of_tree_trunks,
                    list_of_trees);
                }

                // place background
                var spawnedTile = Instantiate(background_prefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                background_tiles[new Vector2(x, y)] = spawnedTile;
            }
            
        }
        
        // todo: spawning playuer not working because something with camera
        // Instantiate(player_prefab, new Vector3(3, 1), Quaternion.identity);
        // place walls
        for (int y = 0; y < grid_height; y++)
        {
            var left_wall = Instantiate(wall_prefab, new Vector3(0, y), Quaternion.identity);
            left_wall.name = $"left_wall_Tile {0} {y}";
            var right_wall = Instantiate(wall_prefab, new Vector3(grid_width, y), Quaternion.identity);
            right_wall.name = $"right_right_Tile {0} {y}";
            // spawn exit
            if (chance_to_spawn_exit == 1 && alread_spawned_exit == false && y == grid_height - 6)
            {
                Debug.Log("left");
                generate_floor_exit(y,grid_height,grid_width,chance_to_spawn_exit);
            }
            if (chance_to_spawn_exit == 2 && alread_spawned_exit == false && y == grid_height - 6)
            {
                Debug.Log("right");
                generate_floor_exit(y,grid_height,grid_width,chance_to_spawn_exit);
            }
        }
        // place platforms UnityEngine.Random.Range(6, 9)
        for (int y = 7; y < grid_height - 10; y+= 6)
        {

            int random_chance_spawn = UnityEngine.Random.Range(1, 3);
            int platform_length_left = UnityEngine.Random.Range(4, 7);
            platform_size = UnityEngine.Random.Range(1, 4);
            var floor_range = 6;
            if(Enumerable.Range((grid_height/3)-floor_range,(grid_height/3)+floor_range).Contains(y) && spawned_first_floor == false){
                generate_floor((grid_height/3),grid_height,grid_width);
                y+=3;
                spawned_first_floor = true;
            }
            if(Enumerable.Range((grid_height-(grid_height/2))-floor_range,(grid_height-(grid_height/2)+floor_range)).Contains(y) && spawned_second_floor == false){
                generate_floor((grid_height-(grid_height/2)),grid_height,grid_width);
                y+=3;
                spawned_second_floor = true;
            }
            if(Enumerable.Range((grid_height-(grid_height/3))-floor_range,(grid_height-(grid_height/3)+floor_range)).Contains(y) && spawned_third_floor == false){
                generate_floor((grid_height-(grid_height/3)),grid_height,grid_width);
                y+=3;
                spawned_third_floor = true;
            }
            // if(Enumerable.Range((grid_height/3)-platform_range,(grid_height/3)+platform_range).Contains(y) == false || Enumerable.Range((grid_height-(grid_height/2))-platform_range,(grid_height-(grid_height/2)+platform_range)).Contains(y) == false || Enumerable.Range((grid_height-(grid_height/3))-platform_range,(grid_height-(grid_height/3)+platform_range)).Contains(y) == false){
                
            // place platform on left side
            generate_platform(platform_length_left, y, platform_size);
            // spawn enemy
            if (random_chance_spawn == 2)
            {
                generate_enemies(platform_length_left, y);
            }


            // place platforms on right side
            random_chance_spawn = UnityEngine.Random.Range(1, 3);
            int platform_length_right = UnityEngine.Random.Range(4, 7);
            platform_size = UnityEngine.Random.Range(1, 4);
            generate_platform(grid_width - platform_length_right, y, platform_size);


            // spawn enemy
            if (random_chance_spawn == 2)
            {
                generate_enemies(grid_width - platform_length_right,y);
            }


            // place platforms on middle
            random_chance_spawn = UnityEngine.Random.Range(1, 3);
            int platform_length_middle = UnityEngine.Random.Range(4, 7);
            // should make it randomly go left or right in the middle
            platform_size = UnityEngine.Random.Range(1, 4);
            generate_platform(grid_width - (grid_width / 2),y,platform_size);
            // spawn enemy
            if (random_chance_spawn == 2)
            {
                generate_enemies(grid_width - (grid_width / 2),y);
            }


            // place platforms in between middle and sides
            // should make it randomly go left or right in the middle
            var right_middle_platform = Instantiate(platform_prefab, new Vector3(grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4)-4, y + 3), Quaternion.identity);
            right_middle_platform.name = $"right_middle_platform_Tile {grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4)} {y}";
            // should make it randomly go left or right in the middle
            var left_middle_platform = Instantiate(platform_prefab, new Vector3((grid_width / 2) - (grid_width / 4) + UnityEngine.Random.Range(2, 4), y + 3), Quaternion.identity);
            left_middle_platform.name = $"left_middle_platform_Tile {grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4)} {y}";
            // }
        }

        List<Dictionary<Vector2, Tile>> secret_rooms = GenerateRooms();




    }

    private void generate_floor(int y, int grid_height, int grid_width){
        var where_to_spawn = UnityEngine.Random.Range(0,4);
        Debug.Log(where_to_spawn);
        if(where_to_spawn == 1){
            // spawn floor on left side
            int x;
            for (x = 3; x < (grid_width/2); x+=4){
                Instantiate(cliff_prefab, new Vector3(x, y-3), Quaternion.identity);
                generate_assets(x,y-2,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones
                ,list_of_tree_trunks,list_of_trees);
            }
            // spawn portal
            var portal = Instantiate(PortalIn, new Vector3(3, y+2), Quaternion.identity);
            portal.tag = "portal_start_1";
        }
        if(where_to_spawn == 2){
            // spawn floor on right side
            int x;
            for (x = grid_width/2; x < grid_width; x+=4){
                Instantiate(cliff_prefab, new Vector3(x, y-3), Quaternion.identity);
                generate_assets(x,y-2,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones
                ,list_of_tree_trunks,list_of_trees);
            }
            // spawn portal
            var portal = Instantiate(PortalIn, new Vector3(grid_width-3, y+2), Quaternion.identity);
            portal.tag = "portal_start_2";
        }
        if(where_to_spawn == 3){
            // spawn floor on both sides with hole in middle (j is x)
            for (int j = 3; j < (grid_width/2)-3; j+=4){
                Instantiate(cliff_prefab, new Vector3(j, y-3), Quaternion.identity);
                generate_assets(j,y-2,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones
                ,list_of_tree_trunks,list_of_trees);
            }
            int x;
            for (x = (grid_width/2)+3; x < grid_width; x+=4){
                Instantiate(cliff_prefab, new Vector3(x, y-3), Quaternion.identity);
                generate_assets(x,y-2,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones
                ,list_of_tree_trunks,list_of_trees);
            }
            // spawn portal
            var portal = Instantiate(PortalIn, new Vector3(grid_width-3, y+2), Quaternion.identity);
            portal.tag = "portal_boss_start";
        }
    }

    private void generate_floor_exit(int y, int grid_height, int grid_width, int chance_to_spawn_exit){
        if(chance_to_spawn_exit == 1){
            
            for (int x = 0; x < grid_width-12; x+=4){
                generate_assets(x,y-2,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones
                ,list_of_tree_trunks,list_of_trees);
                if(x == 0){
                    int i;
                    for (i = 0; i < grid_height-3; i+=4){
                        Instantiate(large_vine_prefab, new Vector3(grid_width-2, i), Quaternion.identity);
                    }
                    Instantiate(large_leaf_left, new Vector3(grid_width-1, i-7), Quaternion.identity);
                }
                Instantiate(cliff_prefab, new Vector3(x+2, y-3), Quaternion.identity);
            }
            Instantiate(exit_prefab, new Vector3(2, grid_height-3), Quaternion.identity);
            
        }
        if(chance_to_spawn_exit == 2){
            for (int x = 8; x < grid_width-1; x+=3){
                generate_assets(x,y-2,list_of_fences,list_of_flowers,list_of_grass_plants,list_of_stones
                ,list_of_tree_trunks,list_of_trees);
                if(x == 12){
                    int i;
                    for (i = 0; i < grid_height-6; i+=4){
                        Instantiate(large_vine_prefab, new Vector3(3, i), Quaternion.identity);
                    }
                    Instantiate(large_leaf_right, new Vector3(4, i-7), Quaternion.identity);
                }
                Instantiate(cliff_prefab, new Vector3(x+2, y-3), Quaternion.identity);
            }
            Instantiate(exit_prefab, new Vector3(grid_width-2, grid_height-3), Quaternion.identity);
        }
    }

    private void generate_assets(int x, int y, List<GameObject> list_of_fences,List<GameObject>list_of_flowers,List<GameObject>list_of_grass_plants,List<GameObject>list_of_stones,List<GameObject>list_of_tree_trunks,
        List<GameObject>list_of_trees){
        // if(UnityEngine.Random.Range(0,3) == 2){
        var type_of_tree = list_of_trees[UnityEngine.Random.Range(0,list_of_trees.Count)];
        Instantiate(type_of_tree, new Vector3(x, y+5), Quaternion.identity);
        // {
        var random_asset = UnityEngine.Random.Range(0,6);
        if (random_asset == 1){
            Instantiate(list_of_fences[UnityEngine.Random.Range(0,list_of_fences.Count)], new Vector3(x, y+2), Quaternion.identity);
        }
        if (random_asset == 2){
            var type_of_trunk = list_of_tree_trunks[UnityEngine.Random.Range(0,list_of_tree_trunks.Count)];
            if(type_of_trunk == tree_trunk_1_prefab){
                Instantiate(type_of_trunk, new Vector3(x, y+4), Quaternion.identity);
            }
            else{
                Instantiate(type_of_trunk, new Vector3(x, y+2), Quaternion.identity);
            }
            
        }
        if(random_asset == 3){
            var type_of_stone = list_of_stones[UnityEngine.Random.Range(0,list_of_stones.Count)];
            Instantiate(type_of_stone, new Vector3(x, y+1), Quaternion.identity);
        }
        if(random_asset == 4){
            var type_of_flower = list_of_flowers[UnityEngine.Random.Range(0,list_of_flowers.Count)];
            Instantiate(type_of_flower, new Vector3(x, y+2), Quaternion.identity);
        }
        if(random_asset == 5){
            var type_of_grass_plant = list_of_grass_plants[UnityEngine.Random.Range(0,list_of_grass_plants.Count)];
            Instantiate(type_of_grass_plant, new Vector3(x, y+2), Quaternion.identity);
        }
    }

    private void generate_platform(int x, int y, int size){
        if (size == 1)
        {
            Instantiate(platform_large_prefab, new Vector3(x, y), Quaternion.identity);
        }
        if (size == 2)
        {
            Instantiate(platform_prefab_moving, new Vector3(x, y), Quaternion.identity);
        }
        else
        {
            Instantiate(platform_prefab, new Vector3(x, y), Quaternion.identity);
        }
    }

    private void generate_enemies(int x, int y){
        var spawn_type = UnityEngine.Random.Range(1, 4);
        if (spawn_type == 1){
            Instantiate(enemy_flying, new Vector3(x, y + 1), Quaternion.identity);
        }
        if (spawn_type == 2){
            Instantiate(enemy_walking, new Vector3(x, y + 1), Quaternion.identity);
        }
        // else{
        //     Instantiate(enemy_wall_crawl, new Vector3(x, y + 1), Quaternion.identity);
        // }

    }

    List<Dictionary<Vector2, Tile>> GenerateRooms()
    {
        grid_width = UnityEngine.Random.Range(15, 20);
        grid_height = 15;
        Dictionary<Vector2, Tile> secret_room = new Dictionary<Vector2, Tile>();
        List<Dictionary<Vector2, Tile>> rooms_list = new List<Dictionary<Vector2, Tile>>();
        List<int> number_rooms = new List<int>();
        number_rooms.Add(120);
        number_rooms.Add(-120);
        number_rooms.Add(200);
        for (int i = 0; i < 3; i++)
        {
            for (int x = 0; x < grid_width; x++)
            {
                for (int y = 0; y < grid_height; y++)
                {
                    if (y == 0)
                    {
                        var floor = Instantiate(floor_prefab, new Vector3(x + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                        floor.name = $"floor_Tile {x} {y}";
                    }
                    var spawnedTile = Instantiate(room_background_prefab, new Vector3(x + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                    spawnedTile.name = $"room_Tile_{i} {x} {y}";
                    secret_room[new Vector2(x, y)] = spawnedTile;
                    if (x == 0 && y == 0)
                    {
                        Instantiate(PortalOut, new Vector3(x + number_rooms[i] + 4, y + number_rooms[i] + 2), Quaternion.identity);
                        Instantiate(enemy_walking, new Vector3(grid_width + number_rooms[i], y + number_rooms[i] + 2), Quaternion.identity);
                        Instantiate(egg, new Vector3(grid_width + number_rooms[i] - 1, y + number_rooms[i]+1), Quaternion.identity);
                    }

                }

            }
            rooms_list.Add(secret_room);
            secret_room.Clear();
        }
        for (int i = 0; i < 3; i++)
        {
            for (int y = 0; y < grid_height; y++)
            {
                var left_wall = Instantiate(wall_prefab, new Vector3(0 + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                left_wall.name = $"left_wall_Tile {0} {y}";
                var right_wall = Instantiate(wall_prefab, new Vector3(grid_width + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                right_wall.name = $"right_right_Tile {0} {y}";
            }
        }

        return rooms_list;
    }


    // public Tile GetTileAtPosition(Vector2 pos) {
    //     if (_tiles.TryGetValue(pos, out var tile)) return tile;
    //     return null;
    // }
}