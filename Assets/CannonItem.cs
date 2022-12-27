using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Cannon Item")]
public class CannonItem : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject cannonPrefab;
}
