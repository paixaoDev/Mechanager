using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] List<AudioClip> walkAudio;

    [SerializeField] AudioSource source;

    Vector3 velocity;
    Vector3 lastPos;

    float walkTimer = .4f;
    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        var inputVector = InputMovementToVector();

        Move(inputVector);
        GetPlayerVelocity();

        if(inputVector.x > 0){
            spriteRenderer.flipX = false;
        }else if (inputVector.x < 0){
            spriteRenderer.flipX = true;
        }

        animator.SetFloat("directionX", inputVector.x);
        animator.SetFloat("directionY", inputVector.y);

        if(velocity != Vector3.zero){
            if(timer > walkTimer){
                WalkAudio();
                timer = 0;
            }else{
                timer += Time.deltaTime;
            }
        }
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

    void WalkAudio (){
        source.clip = walkAudio[Random.Range(0, walkAudio.Count)];
        source.Play();
    }
}
