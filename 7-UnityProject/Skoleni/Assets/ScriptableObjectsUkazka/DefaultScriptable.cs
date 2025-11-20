using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "CustomScriptables/Stats")]
public class DefaultScriptable : ScriptableObject {
    public int HP;
    public string Name;
    public float MovementSpeed;

}

public class CharacterStats {
    public int HP;
    public string Name;
    public float MovementSpeed;
}