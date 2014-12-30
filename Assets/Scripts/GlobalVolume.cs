using UnityEngine;
using System.Collections;

public class GlobalVolume : MonoBehaviour {

	// Use this for initialization
	UISlider mSlider;
	
	void Awake ()
	{
		mSlider = GetComponent<UISlider>();
		mSlider.value = AudioListener.volume;
		EventDelegate.Add(mSlider.onChange, OnChange);
	}
	
	void OnChange ()
	{
		AudioListener.volume = UISlider.current.value;
	}
}
