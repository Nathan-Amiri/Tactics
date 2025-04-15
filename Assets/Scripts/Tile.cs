using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // STATIC:
    public static Dictionary<Vector2, Tile> tileIndex = new();

    // PREFAB REFERENCE:
    [SerializeField] private SpriteRenderer colorSR;
    [SerializeField] private SpriteRenderer spriteSR;

    [SerializeField] private List<Color> terrainColors = new();

    // SCENE REFERENCE:
    public int terrainType;

    [SerializeField] private bool isShopTile;

    // CONSTANT:
    [NonSerialized] public readonly List<string> terrainNames = new() { "Marsh", "Wildfire", "Cliff", "Plain", "Storm", "Tundra", "Chasm", "Forest", "Mine" };

    // DYNAMIC:
    private GameManager gameManager;
    private UnitIndex unitIndex;

    [NonSerialized] public UnitData unitData;

    private void Awake()
    {
        GameObject miscScripts = GameObject.Find("MiscScripts");
        gameManager = miscScripts.GetComponent<GameManager>();
        unitIndex = miscScripts.GetComponent<UnitIndex>();

        tileIndex.Add(transform.position, this);

        colorSR.color = terrainColors[terrainType];
    }

    private void Start()
    {
        LoadUnit(unitIndex.LoadUnitFromIndex(0));
    }

    public void LoadUnit(UnitData data)
    {
        unitData = data;

        spriteSR.sprite = data.sprite;
        spriteSR.enabled = true;
    }
    public void UnloadUnit()
    {
        unitData = default;

        spriteSR.enabled = false;
        spriteSR.sprite = null;
    }

    private void OnMouseDown()
    {
        if (isShopTile)
        {
            OnShopDown();
            return;
        }

        gameManager.LoadMainInfo(this);
    }

    private void OnShopDown()
    {

    }
}