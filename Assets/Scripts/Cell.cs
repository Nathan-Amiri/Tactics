using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static Dictionary<Vector2, Cell> cellIndex = new();

    public enum Terrain { Marsh, Lava, Cliff, Plain, Storm, Tundra, Cave, Jungle, Mine };
    public Terrain terrain;

    private void Awake()
    {
        cellIndex.Add(transform.position, this);
    }
}