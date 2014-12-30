#pragma strict

	var telRate = 2.0;
	private var nextTel = 0.0;
	var player : Transform;
	var destination: Transform; // drag the destination object here
	var teleportSound: AudioClip; // set this to the teleport sound, if any
	function OnTriggerEnter(coll : Collider){
	nextTel = Time.time + telRate;
    player.transform.position = destination.position; // teleports object
    player.transform.rotation = destination.rotation; // makes it face the correct side
    if (teleportSound){ // plays the sound effect at the destination
        AudioSource.PlayClipAtPoint(teleportSound, destination.position);
        }
}