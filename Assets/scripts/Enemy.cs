using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyController))]

public class Enemy : MonoBehaviour
{
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    EnemyController controller;
    public SelectedArea fullController;

    float cameraX;
    private float yVelocity = 0.0F;
    public float smoothTime = 0.3F;





    void Start()
    {
        controller = GetComponent<EnemyController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }
    void Update()
    {
        Vector2 input = new Vector2(0, 0);



            float targetVelocityX = input.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }


    }
}