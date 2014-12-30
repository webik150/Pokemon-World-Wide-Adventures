using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphicsQuality : MonoBehaviour {
    
    public List<string> qualities;
    public int graphicsInt;
    
    // Use this for initialization
    void Start () {
        foreach(string item in QualitySettings.names){
            qualities.Add(item);
        }
    }
    
    // Update is called once per frame
    void Update () {
    
    }
    
    public void OnSelectionChange(string mSelectedItem) {
        if(qualities.Contains(mSelectedItem)) {
            Debug.Log("Changing Quality");
            graphicsInt = qualities.IndexOf(mSelectedItem);
            QualitySettings.SetQualityLevel(graphicsInt, true);
        }
    }
}