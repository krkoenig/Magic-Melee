using System;
using UnityEngine;

public class Fireball : Spell
{
	public override GameObject fire (Vector3 transform, Vector3 euler)
	{
		return (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Prefabs/Fireball"), transform, Quaternion.Euler(euler));
	}
}