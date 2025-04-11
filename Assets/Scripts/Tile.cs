using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // STATIC:
    public static Dictionary<Vector2, Tile> tileIndex = new();

    // PREFAB REFERENCE:
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private List<Color> terrainColors = new();

    [SerializeField] private List<Sprite> unitSprites = new();

    // CONSTANT:
    private readonly List<string> terrainNames = new() { "Marsh", "Wildfire", "Cliff", "Plain", "Storm", "Tundra", "Chasm", "Forest", "Mine" };

    // DYNAMIC:
    private GameManager gameManager;

    public int terrainType;

    [NonSerialized] public UnitData unitData;

    private void Awake()
    {
        GameObject miscScripts = GameObject.Find("MiscScripts");
        gameManager = miscScripts.GetComponent<GameManager>();

        tileIndex.Add(transform.position, this);

        terrainType = UnityEngine.Random.Range(0, 9);
        Debug.Log(terrainType);
        sr.color = terrainColors[terrainType];
    }

    public void LoadUnit(UnitData data)
    {
        unitData = data;

        sr.sprite = data.sprite;
        sr.color = Color.white;
    }
    public void UnloadUnit()
    {
        unitData = default;

        sr.sprite = null;
        sr.color = terrainColors[terrainType];
    }

    private void OnMouseDown()
    {
        Debug.Log("Tile" + transform.position);
    }
}