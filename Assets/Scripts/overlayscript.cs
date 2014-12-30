using UnityEngine;

public class overlayscript : MonoBehaviour
{

	public GameObject overlay;

	void OnClick()
	{
	    transform.parent.BroadcastMessage("Select", false);
	    Select(true);
	}
	
	void Select(bool selected)
	{
	    if (selected)
	    {
	        //turn on overlay
	        NGUITools.SetActive(overlay, true);
	    }
	    else
	    {
  	      //turn off overlay
   	     NGUITools.SetActive(overlay, false);
	   	}
	}
}