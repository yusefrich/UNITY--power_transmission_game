using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
[RequireComponent(typeof(PowersController))]

public class Player : MonoBehaviour
{
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;
    PowersController cont;
    bool preso = false;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;
    public SelectedArea fullController;

    public GameObject camera;
    float cameraX;
    private float yVelocity = 0.0F;
    public float smoothTime = 0.3F;





    void Start()
    {
        preso = false;
        controller = GetComponent<Controller2D>();
        cont = GetComponent<PowersController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }
    void Update()
    {
        moveSpeed += 0.5f * Time.deltaTime; // Cap at some max value too

        Vector2 input = new Vector2(1f, Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (!fullController.GetGameState())
        {
            float targetVelocityX = input.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }


        if(camera != null)
        {
            if (controller.facedir < 0)
            {
                cameraX = -12;            }
            else
            {
                cameraX = 12;
            }
            if (controller.collisions.right)
            {
                cameraX = 20;
                if(camera.transform.localPosition.x >= 19)
                {
                    preso = true;
                }
            }

            float newPossition = Mathf.SmoothDamp(camera.transform.localPosition.x, cameraX, ref yVelocity, smoothTime);
            camera.transform.localPosition = new Vector3(newPossition, camera.transform.localPosition.y, camera.transform.localPosition.z);
            

        }
        if (preso)
        {
            cont.SetLife(900);
        }
    }
    public void Jump()
    {
        if (controller.collisions.below)
        {
            velocity.y = jumpVelocity;

        }

    }
}