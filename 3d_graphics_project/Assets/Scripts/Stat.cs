using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat{
    [SerializeField]
    private float  baseValue = 0;

	// List of modifiers that change the baseValue
	private List<float> modifiers = new List<float>();

	// Get the final value after applying modifiers
	public float GetValue ()
	{
		float finalValue = baseValue;
		modifiers.ForEach(x => finalValue += x);
		return finalValue;
	}

	// Add new modifier
	public void AddModifier (float modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	// Remove a modifier
	public void RemoveModifier (float modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}
}
