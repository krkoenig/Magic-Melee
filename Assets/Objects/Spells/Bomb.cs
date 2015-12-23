using System;
using UnityEngine;

public class Bomb : Spell
{
    public override GameObject fire(Vector3 transform, Vector3 euler)
    {
        return (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Bomb"), transform, Quaternion.Euler(euler));
    }
}
