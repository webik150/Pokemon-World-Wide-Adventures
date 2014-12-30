#pragma strict
var player : Transform;
var x : float;
var y : float;
var z : float;
var load = 0;
function Start () {
 
 if(PlayerPrefs.HasKey("x"+PlayerPrefs.GetInt("saveNumber")) && PlayerPrefs.HasKey("y"+PlayerPrefs.GetInt("saveNumber")) && PlayerPrefs.HasKey("z"+PlayerPrefs.GetInt("saveNumber"))&& PlayerPrefs.GetInt("loaded"+PlayerPrefs.GetInt("saveNumber")) == 1) {
 
 x = PlayerPrefs.GetFloat("x"+PlayerPrefs.GetInt("saveNumber"));
 y = PlayerPrefs.GetFloat("y"+PlayerPrefs.GetInt("saveNumber"));
 z = PlayerPrefs.GetFloat("z"+PlayerPrefs.GetInt("saveNumber"));
 
 player.position.x = x;
 player.position.y = y;
 player.position.z = z;

 PlayerPrefs.SetInt("loaded"+PlayerPrefs.GetInt("saveNumber"), 0);
 
 }
}

function Update () {

}