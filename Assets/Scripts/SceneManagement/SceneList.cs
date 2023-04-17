using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// in the Scene List file created by this ScriptableObject, you put the names of the scenes in order
[CreateAssetMenu(fileName = "Scene List", menuName = "Scene List/Create Scene List", order = 0)]
public class SceneList : ScriptableObject
{
    public int CurrentScene;
    public List<string> Scenes;
}