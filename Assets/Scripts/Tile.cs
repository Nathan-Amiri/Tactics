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

    public int debugStartingUnit = -1;

    [SerializeField] private bool isShopTile;

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
        if (debugStartingUnit != -1)
            LoadUnit(unitIndex.LoadUnitFromIndex(debugStartingUnit));
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