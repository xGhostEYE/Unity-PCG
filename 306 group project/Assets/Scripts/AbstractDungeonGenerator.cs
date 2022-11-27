using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField] protected Vector2Int start_position = Vector2Int.zero;

    public void generate_dungeon(){
        tilemapVisualizer.Clear();
        run_procedural_generation();
    }

    protected abstract void run_procedural_generation();
}
