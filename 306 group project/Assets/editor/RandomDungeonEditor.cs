using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbstractDungeonGenerator),true)]
public class RandomDungeonEditor : Editor
{
    AbstractDungeonGenerator generator;

    private void awake(){
        generator = (AbstractDungeonGenerator)target;
    }

    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        if(GUILayout.Button("Create Dungeon")){
            generator.generate_dungeon();
        }

    }
}
