using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParamters_",menuName = "PCG/SimpleWalkData")]

public class SimpleRandomWalkDATA : ScriptableObject
{
    public int iterations = 10, walk_length = 10;
    public bool start_randomly_each_iteration = true;
}
