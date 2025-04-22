using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // SCENE REFERENCE:
    [SerializeField] private GameObject mainInfo;
    [SerializeField] private TMP_Text mainInfoTerrainName;
    [SerializeField] private TMP_Text mainInfoTerrainDescription;

    [SerializeField] private TMP_Text mainInfoUnitName;


    // CONSTANT:
    [NonSerialized] public readonly List<string> terrainNames = new() { "Marsh", "Wildfire", "Cliff", "Plain", "Storm", "Tundra", "Chasm", "Forest", "Mine" };
    [NonSerialized] public readonly List<string> terrainDescriptions = new() { 
        "Units here heal 1 at the end of their turn",
        "WildfireDesc",
        "CliffDesc",
        "PlainDesc",
        "StormDesc",
        "TundraDesc",
        "ChasmDesc",
        "ForestDesc",
        "MineDesc"
    };


    public void LoadMainInfo(Tile tile)
    {
        mainInfo.SetActive(true);
        mainInfoTerrainName.text = terrainNames[tile.terrainType];
        mainInfoTerrainDescription.text = terrainDescriptions[tile.terrainType];

        mainInfoUnitName.text = tile.unitData.unitName;
    }
}