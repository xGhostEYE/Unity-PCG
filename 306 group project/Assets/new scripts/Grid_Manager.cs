using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid_Manager : MonoBehaviour
{
    private int grid_width, grid_height;

    [SerializeField] private Tile background_prefab, platform_prefab, platform_large_prefab, wall_prefab, floor_prefab, room_background_prefab;

    [SerializeField] private GameObject enemy_flying, enemy_walking, enemy_wall_crawl, portal_prefab, slime_prefab, player, exit_prefab;

    [SerializeField] private GameObject acidSpawner;

    [SerializeField] private GameObject egg;

    [SerializeField] private GameObject PortalIn, PortalOut;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        grid_width = UnityEngine.Random.Range(40, 60);
        grid_height = UnityEngine.Random.Range(70, 100);
        int type_of_enemy;
        int platform_size;
        Dictionary<Vector2, Tile> background_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> floor_tiles = new Dictionary<Vector2, Tile>();
        Dictionary<Vector2, Tile> platform_tiles = new Dictionary<Vector2, Tile>();
        int numer_of_portals = 0;
        bool alread_spawned_left = false;
        bool alread_spawned_right = false;
        bool alread_spawned_middle = false;
        bool alread_spawned_exit = false;
        bool spawnedPortalIn = false;
        bool spawnedPortalOut = false;
        int chance_to_spawn_exit = UnityEngine.Random.Range(1, 3);
        acidSpawner.transform.position = new Vector3(0, -5);
        // place background and floor
        for (int x = 0; x < grid_width; x++)
        {
            // place floor
            for (int y = 0; y < grid_height; y++)
            {
                if (y == 0)
                {
                    if (x == (grid_width / 2) - 10)
                    {
                        //Instantiate(player, new Vector3(x, y+3), Quaternion.identity);
                        player.transform.position = new Vector3(x, y + 3);
                    }
                    var floor = Instantiate(floor_prefab, new Vector3(x, y), Quaternion.identity);
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

        for (int y = 0; y < grid_height; y++)
        {
            var left_wall = Instantiate(wall_prefab, new Vector3(0, y), Quaternion.identity);
            left_wall.name = $"left_wall_Tile {0} {y}";
            var right_wall = Instantiate(wall_prefab, new Vector3(grid_width, y), Quaternion.identity);
            right_wall.name = $"right_right_Tile {0} {y}";
            // spawn exit
            if (chance_to_spawn_exit == 1 && alread_spawned_exit == false && y == grid_height - 6)
            {
                Instantiate(exit_prefab, new Vector3(1, y), Quaternion.identity);
                if (spawnedPortalOut == false) PortalOut.transform.position = new Vector3(1, y);
                alread_spawned_exit = true;
            }
            if (chance_to_spawn_exit == 2 && alread_spawned_exit == false && y == grid_height - 6)
            {
                Instantiate(exit_prefab, new Vector3(grid_width - 1, y), Quaternion.identity);
                if (spawnedPortalOut == false) PortalOut.transform.position = new Vector3(1, y);
                alread_spawned_exit = true;
            }
        }
        // place platforms
        for (int y = 6; y < grid_height; y++)
        {
            Debug.Log(y);
            if (y >= grid_height - 5)
            {
                break;
            }

            // place platforms on left side
            int random_chance_spawn = UnityEngine.Random.Range(1, 3);
            int platform_length_left = UnityEngine.Random.Range(4, 7);
            platform_size = UnityEngine.Random.Range(1, 3);

            if (platform_size == 1)
            {
                var left_platform = Instantiate(platform_large_prefab, new Vector3(platform_length_left, y), Quaternion.identity);
                left_platform.name = $"left_platform_Tile {platform_length_left} {y}";
                platform_tiles[new Vector2(platform_length_left, y)] = left_platform;
            }
            else
            {
                var left_platform_alt = Instantiate(platform_prefab, new Vector3(platform_length_left, y), Quaternion.identity);
                left_platform_alt.name = $"left_platform_Tile {platform_length_left} {y}";
                platform_tiles[new Vector2(platform_length_left, y)] = left_platform_alt;
            }

            if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.2)
            {
                Instantiate(egg, new Vector3(platform_length_left, y+3), Quaternion.identity);
            }

            // spawn enemy
            if (random_chance_spawn == 2)
            {
                type_of_enemy = UnityEngine.Random.Range(1, 4);
                if (type_of_enemy == 1)
                {
                    Instantiate(enemy_flying, new Vector3(platform_length_left, y + 1), Quaternion.identity);
                }
                if (type_of_enemy == 2)
                {
                    Instantiate(enemy_walking, new Vector3(platform_length_left, y + 1), Quaternion.identity);
                }
            }
            // spawn portal
            if (random_chance_spawn == 1 && numer_of_portals < 3 && alread_spawned_left == false)
            {
                if (y >= grid_height / 2)
                {
                    Instantiate(portal_prefab, new Vector3(platform_length_left, y + 1), Quaternion.identity);
                    
                    alread_spawned_left = true;
                }
            }

            // place enemy if platform is big enough

            // place platforms on right side
            random_chance_spawn = UnityEngine.Random.Range(1, 3);
            int platform_length_right = UnityEngine.Random.Range(4, 7);
            platform_size = UnityEngine.Random.Range(1, 3);
            if (platform_size == 1)
            {
                var right_platform = Instantiate(platform_large_prefab, new Vector3(grid_width - platform_length_right, y), Quaternion.identity);
                right_platform.name = $"right_platform_Tile {grid_width - platform_length_right} {y}";
                platform_tiles[new Vector2(grid_width - platform_length_right, y)] = right_platform;
            }
            else
            {
                var right_platofrm_alt = Instantiate(platform_prefab, new Vector3(grid_width - platform_length_right, y), Quaternion.identity);
                right_platofrm_alt.name = $"right_platform_Tile {grid_width - platform_length_right} {y}";
                platform_tiles[new Vector2(grid_width - platform_length_right, y)] = right_platofrm_alt;
            }

            if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.2)
            {
                Instantiate(egg, new Vector3(grid_width - platform_length_right, y), Quaternion.identity);
            }

            // spawn enemy
            if (random_chance_spawn == 2)
            {
                type_of_enemy = UnityEngine.Random.Range(1, 4);
                if (type_of_enemy == 1)
                {
                    Instantiate(enemy_flying, new Vector3(grid_width - platform_length_right, y + 1), Quaternion.identity);
                }
                if (type_of_enemy == 2)
                {
                    Instantiate(enemy_walking, new Vector3(grid_width - platform_length_right, y + 1), Quaternion.identity);
                }
            }
            // spawn portal
            if (random_chance_spawn == 1 && numer_of_portals < 3 && alread_spawned_right == false)
            {
                if (y >= grid_height / 3)
                {
                    Instantiate(portal_prefab, new Vector3(grid_width - platform_length_right, y + 1), Quaternion.identity);
                    alread_spawned_right = true;
                }
            }

            // place platforms on middle
            random_chance_spawn = UnityEngine.Random.Range(1, 3);
            int platform_length_middle = UnityEngine.Random.Range(4, 7);
            // should make it randomly go left or right in the middle
            platform_size = UnityEngine.Random.Range(1, 3);
            if (platform_size == 1)
            {
                var middle_platform = Instantiate(platform_large_prefab, new Vector3(grid_width - (grid_width / 2), y), Quaternion.identity);
                middle_platform.name = $"middle_platform_Tile {grid_width - (grid_width / 2)} {y}";
                platform_tiles[new Vector2(grid_width - (grid_width / 2), y)] = middle_platform;
            }
            else
            {
                var middle_platform_alt = Instantiate(platform_prefab, new Vector3(grid_width - (grid_width / 2), y), Quaternion.identity);
                middle_platform_alt.name = $"middle_platform_Tile {grid_width - (grid_width / 2)} {y}";
                platform_tiles[new Vector2(grid_width - (grid_width / 2), y)] = middle_platform_alt;
            }

            if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.2)
            {
                Instantiate(egg, new Vector3(grid_width - (grid_width / 2), y), Quaternion.identity);
            }
            // spawn enemy
            if (random_chance_spawn == 2)
            {
                type_of_enemy = UnityEngine.Random.Range(1, 4);
                if (type_of_enemy == 1)
                {
                    Instantiate(enemy_flying, new Vector3(grid_width - (grid_width / 2), y + 1), Quaternion.identity);
                }
                if (type_of_enemy == 2)
                {
                    Instantiate(enemy_walking, new Vector3(grid_width - (grid_width / 2), y + 1), Quaternion.identity);
                }
            }
            // spawn portal
            if (random_chance_spawn == 1 && numer_of_portals < 3 && alread_spawned_middle == false)
            {
                if (y >= grid_height / 4)
                {
                    Instantiate(portal_prefab, new Vector3(grid_width - (grid_width / 2), y + 1), Quaternion.identity);
                    alread_spawned_middle = true;
                }
            }

            if (random_chance_spawn == 1 && spawnedPortalIn == false && alread_spawned_middle)
            {
                PortalIn.transform.position = new Vector3(grid_width - (grid_width / 2), y + 1);
            }

            if (random_chance_spawn == 1 && spawnedPortalIn == true && spawnedPortalOut == false)
            {
                PortalOut.transform.position = new Vector3(grid_width - (grid_width / 2), y + 1);
            }
            y = y + UnityEngine.Random.Range(4, 8);
            // place platforms in between middle and sides
            // should make it randomly go left or right in the middle
            var right_middle_platform = Instantiate(platform_prefab, new Vector3(grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4), y - 3), Quaternion.identity);
            right_middle_platform.name = $"right_middle_platform_Tile {grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4)} {y}";
            platform_tiles[new Vector2(grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4), y)] = right_middle_platform;
            // should make it randomly go left or right in the middle
            var left_middle_platform = Instantiate(platform_prefab, new Vector3((grid_width / 2) - (grid_width / 4) - 3 + UnityEngine.Random.Range(2, 4), y - 3), Quaternion.identity);
            left_middle_platform.name = $"left_middle_platform_Tile {grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4)} {y}";
            platform_tiles[new Vector2(grid_width - (grid_width / 4) + UnityEngine.Random.Range(2, 4), y)] = left_middle_platform;

        }

        List<Dictionary<Vector2, Tile>> secret_rooms = GenerateRooms();




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
                        if (x == (grid_width / 2) - 10)
                        {
                            Instantiate(player, new Vector3(x, y), Quaternion.identity);
                        }
                        var floor = Instantiate(platform_prefab, new Vector3(x + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                        floor.name = $"floor_Tile {x} {y}";
                    }
                    var spawnedTile = Instantiate(room_background_prefab, new Vector3(x + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                    spawnedTile.name = $"room_Tile_{i} {x} {y}";
                    secret_room[new Vector2(x, y)] = spawnedTile;
                    if (x == 0 && y == 0)
                    {
                        Instantiate(portal_prefab, new Vector3(x + number_rooms[i] + 4, y + number_rooms[i] + 4), Quaternion.identity);
                        Instantiate(enemy_walking, new Vector3(grid_width + number_rooms[i], y + number_rooms[i] + 2), Quaternion.identity);
                        Instantiate(slime_prefab, new Vector3(grid_width + number_rooms[i] - 1, y + number_rooms[i]), Quaternion.identity);
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
                var left_wall = Instantiate(platform_prefab, new Vector3(0 + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
                left_wall.name = $"left_wall_Tile {0} {y}";
                var right_wall = Instantiate(platform_prefab, new Vector3(grid_width + number_rooms[i], y + number_rooms[i]), Quaternion.identity);
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