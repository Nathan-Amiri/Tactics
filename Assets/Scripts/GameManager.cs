using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // SCENE REFERENCE:
    [SerializeField] private GameObject mainInfo;
    [SerializeField] private TMP_Text mainInfoName;

    public void LoadMainInfo(Tile tile)
    {
        mainInfo.SetActive(true);
        mainInfoName.text = tile.terrainNames[tile.terrainType];
    }
}