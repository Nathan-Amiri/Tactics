using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // SCENE REFERENCE:
    [SerializeField] UnitIndex unitIndex;

    [SerializeField] private GameObject mainInfo;
    [SerializeField] private TMP_Text mainInfoName;

    public void LoadMainInfo(UnitData data)
    {
        mainInfo.SetActive(true);
        mainInfoName.text = data.unitName;
    }

    private void LoadUnit(int unitNumber)
    {
        UnitData newUnit = unitIndex.LoadUnitFromIndex(unitNumber);
    }
}