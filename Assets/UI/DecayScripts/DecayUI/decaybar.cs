using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This script controls the slider that visually represents a value
// that decreases over time
public class decaybar : MonoBehaviour
{
    // Reference to the UI Slider component
	public Slider slider;
	
	// Gradient used to smoothly change the color of the bar
    // (for example: green → yellow → red)
	public Gradient gradient;

	// Reference to the Image component that fills the slider
	public Image fill;

    // Sets the maximum value of the bar (usually called once at start)
    // Also fills the bar completely
	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

    // Updates the current value of the bar
    // Called whenever the value changes
    public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}