using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitData
{
    public string unitName;

    public Sprite sprite;

    public int baseHealth;
    public int baseAttack;
    public int baseSpeed;
    public int baseRange;

    public int currentHealth;
    public int currentAttack;
    public int currentSpeed;
    public int currentRange;

    public List<int> unitTypes; // 0 = Water, 1 = Flame, 2 = Earth, 3 = Wind, 4 = Lightning, 5 = Frost, 6 = Shadow, 7 = Venom, 8 = Jewel
}
public class UnitIndex : MonoBehaviour
{
    private delegate UnitData IndexMethod();
    private readonly List<IndexMethod> indexMethods = new();

    [SerializeField] private List<Sprite> unitSprites = new();

    private void Awake()
    {
        PopulateIndex();
    }

    public UnitData LoadUnitFromIndex(int indexNumber)
    {
        if (indexMethods.Count < indexNumber + 1)
        {
            Debug.LogError("The following move index method was not found: " + indexNumber);
            return default;
        }

        UnitData data = indexMethods[indexNumber]();

        data.sprite = unitSprites[indexNumber];

        data.currentHealth = data.baseHealth;
        data.currentAttack = data.baseAttack;
        data.currentSpeed = data.baseSpeed;
        data.currentRange = data.baseRange;

        return data;
    }



    private UnitData WilloWisp() // 0
    {
        return new UnitData
        {
            unitName = "Will-o'-Wisp",

            baseHealth = 0,
            baseAttack = 0,
            baseSpeed = 0,
            baseRange = 0,

            unitTypes = new() { 0, 1 }
        };
    }



    private void PopulateIndex()
    {
        indexMethods.Add(WilloWisp);
    }
}