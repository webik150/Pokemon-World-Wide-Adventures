#pragma strict

var level : String = "Level Name";
 
function OnTriggerStay (other : Collider) {
    //Check to see if a player entered the gate, rather than some space debris.
    if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
        Application.LoadLevel(""+level);
    }
}