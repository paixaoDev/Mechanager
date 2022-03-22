using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    Vector3 velocity;
    Vector3 lastPos;

    // Update is called once per frame
    void Update()
    {
        //Vetor 2D do input, representando o movimento horizontal e vertical do input
        var inputVector = InputMovementToVector();

        Move(inputVector);
        //Rotate(RotationByInput(inputVector));
        GetPlayerVelocity();

        if(inputVector.x > 0){
            spriteRenderer.flipX = false;
        }else if (inputVector.x < 0){
            spriteRenderer.flipX = true;
        }

        //animator.SetBool("equiped spike", hookAinming);
        //animator.SetFloat("velocity", velocity.magnitude);
        animator.SetFloat("directionX", inputVector.x);
        animator.SetFloat("directionY", inputVector.y);
    }

    void GetPlayerVelocity (){
        if(lastPos != transform.position) {
            velocity = transform.position - lastPos;
            velocity /= Time.deltaTime;
            lastPos = transform.position;
        }else{
            velocity = Vector3.zero;
        } 
    }

    Vector2 InputMovementToVector() 
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    Quaternion RotationByInput(Vector2 input)
    {
        if(input != Vector2.zero)
            return Quaternion.LookRotation(input);

        return transform.rotation;
    }

    void Move(Vector3 desiredMoveDirection)
    {
       transform.position += (desiredMoveDirection * movementSpeed * Time.deltaTime);
    }

    void Rotate(Quaternion direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * 8);
    }
}
