 
// The target we are following
var targeti : Transform;
// The distance in the x-z plane to the target
var distancei : float = 1.6;
// the height we want the camera to be above the target
var heighti : float = 0.6;
// the tilt offset we want the camera to tilt to the target
var tiltOffset : float = 0.0;
// How much we damp the movement
var heightDamping : float = 3.0;
var rotationDamping : float = 3.0;
var tiltDamping : float = 3.0;
 
//---New code---
 
//how close does the camera have to get to a wall before it will bounce
var bounceRange : float = 1.0;
var bounceAmt : float = 2.0;
 
//---End of new code---
 
function LateUpdate () {
   // Early out if we don't have a target
   if (!targeti)
      return;
   
   // Calculate the current rotation angles
   wantedRotationAngle = targeti.eulerAngles.y;
   wantedTiltAngle = targeti.eulerAngles.x + tiltOffset;
   wantedHeight = targeti.position.y + heighti;
       
   currentRotationAngle = transform.eulerAngles.y;
   currentTiltAngle = transform.eulerAngles.x;
   currentHeight = transform.position.y;
 
//---New/altered code---
 
//Cast rays to the left and right of the camera, to detect walls.
   var hit : RaycastHit;
   var layerMask = 1 << 11;
   layerMask = ~layerMask; // ignore the player (just to make sure)  
   
   if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), hit, bounceRange, layerMask)) {      
      currentRotationAngle -= bounceAmt * Time.deltaTime;        
   }
   else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), hit, bounceRange, layerMask)) {         
      currentRotationAngle += bounceAmt * Time.deltaTime;      
   }
   else { //If no walls are detected, execute the normal follow behavior.
      // Damp the rotation around the y-axis
      if (!Physics.CheckSphere(transform.position, 1.0, layerMask)) {
        currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
      }
   }
 
//---End of new code---    
   // damp the tilt
   currentTiltAngle = Mathf.LerpAngle(currentTiltAngle, wantedTiltAngle, tiltDamping * Time.deltaTime);
   
   // Damp the height
   currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
 
   // Convert the angle into a rotation
   // The quaternion interface uses radians not degrees so we need to convert from degrees to radians
   currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
   
   // Set the position of the camera on the x-z plane to:
   // distance meters behind the target
   transform.position = targeti.position;
   transform.position -= currentRotation * Vector3.forward * distancei;
 
   // Set the height of the camera
   transform.position.y = currentHeight;
   
   // Always look at the target
   transform.LookAt (targeti);
   transform.eulerAngles.x = currentTiltAngle;
}
 
function OnDrawGizmosSelected() {
    Gizmos.color = Color.yellow;
    Gizmos.DrawSphere(transform.position, 1.0);
}