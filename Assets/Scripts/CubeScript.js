#pragma strict

var speed : float = 6.0;
var jumpSpeed : float = 8.0;
var gravity : float = 20.0;

private var moveDirection : Vector3 = Vector3.zero;

function Update () {
    var controller : CharacterController = GetComponent.<CharacterController>();
    if(controller.isGrounded){
        // On ground so calculate move direction from axes
        moveDirection = Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Jump pressed
        if(Input.GetButton("Jump")){
            moveDirection.y = jumpSpeed;
        }
    }
    // Apply gravity
    moveDirection.y -= gravity * Time.deltaTime;
    // Move controller
    controller.Move(moveDirection * Time.deltaTime);
} 

    /* Pushing Component */
var pushPower : float = 2.0;

function OnControllerColliderHit(hit : ControllerColliderHit){
    var body : Rigidbody = hit.collider.attachedRigidbody;
    // When there is no rigidbody
    if(body == null || body.isKinematic){
    	return;
    }
    // Dont push object below the cube
    if(hit.moveDirection.y < -0.3){
    	return;
    }
    // Push objects side to side, not up/down
    var pushDir : Vector3 = Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
    // Apply push
    body.velocity = pushDir * pushPower;
}