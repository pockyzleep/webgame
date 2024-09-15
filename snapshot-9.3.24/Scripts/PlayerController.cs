using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {
    public float speed = 5f; // set public to view adjustments on unity editor

    private Vector2 moveInput; // the use in conjuction btwn fixed update and update
    private Rigidbody2D rb; // connect player obj as a rb2d property to utilize 2d physics engine
    private Animator anim; // player anim via rotation

    public bool firingMode = false; // this is for the firing animation in another script to disable other movement anims

    private bool isKnockedBack;//for checking is the player is being knocked back or not
    private float knockbackDuration = 0.2f; // Duration of knockback effect
    private float knockbackTimer;

    // dash
    private TrailRenderer trail;
    private float activeSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashInterval, dashCooldownCounter;

    public AudioSource dashSound;

    public AudioSource walkSound;

    private void Awake() {
        // I omitted Start() as Awake() runs before Start() 
        // and ensures this area is called first before any other script
        // refer: https://docs.unity3d.com/Manual/ExecutionOrder.html
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();

        // to fix the stupid player obj stutter for the camera controller script
        // the Update() below is now set to FixedUpdate()
        // this is b/c we need fixed time intervals to update rb pos
        // if the physics updates are less/more than the render updates --> issue
        // interpolate does the calc during the fixed intervals to make it look smooth
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    private void Start() {
        activeSpeed = speed;
        trail.emitting = false;
    }
    private void Update() {
        if (isKnockedBack) {
            return; // skip movement but main function is applied on fixed update because we want unity's fixed interval
        }

        // input x and y axis
        // GetAxisRaw is not smoothed by adding 'Raw"
        // so there's no acceleration
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // vector representing the movement direction
        // used .normalized to prevent diagonal movement to be faster
        // this is b/c pythag thm thus a diag vec size is large
        // we set this to ensure vector length is always magnitude of size 1
        moveInput = new Vector2(moveX, moveY).normalized;

        // walking audio
        if (moveX != 0 || moveY != 0) {
            if (!walkSound.isPlaying) {
                walkSound.Play();
            }
        }
        else {
            walkSound.Stop();
        }

        // dash feature
        // check spacebar key when clicked
        // assess dash cooldown and dash interval
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (dashCooldownCounter <= 0 && dashInterval <= 0) {
                activeSpeed = dashSpeed;
                dashInterval = dashLength;
                trail.emitting = true;
                dashSound.Play();
            }
        }
        if (dashInterval > 0) {
            dashInterval -= Time.deltaTime;
            if (dashInterval <= 0) {
                activeSpeed = speed;
                dashCooldownCounter = dashCooldown;
                trail.emitting = false;
            }
        }
        if (dashCooldownCounter > 0) {
            dashCooldownCounter -= Time.deltaTime;
        }
    }
    private void FixedUpdate() {
        // if knockback is true, then the knockback timer will be set to the time duration.
        if (isKnockedBack) {
            knockbackTimer -= Time.fixedDeltaTime;
            if (knockbackTimer <= 0) {
                isKnockedBack = false;
            }
            return; // skip movement during knockback to ensure that the player's movement controlled by key is not cancelling the knockback
        }

        // rb2d obj movement
        //rb.velocity = moveInput * speed;
        // dash test changed var speed 
        rb.velocity = moveInput * activeSpeed;

        // function call to update movement animation
        movementAnimation(firingMode);

        // call rotate player obj via cursor function
        RotateToMouse();
    }

    private void movementAnimation(bool firingMode) {
        if (!firingMode) {
            // idle <--> walk animation
            // set up float moveX and moveY parameters in anim
            anim.SetFloat("moveX", rb.velocity.x);
            anim.SetFloat("moveY", rb.velocity.y);
        }
    }

    private void RotateToMouse() {
        // mouse pos on screen space and convert it to world space
        // 3d vector is needed b/c z-coord is important to convert to world space 
        // despite this being a 2d game this is necessity as unity is an underlying 3d engine
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        // calculate the direction from the player to the mouse
        // subtract mouse world pos w/ transform.position (this is the player obj's position)
        // normalize the vector for accurate angle calculation
        Vector2 direction = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotate
        rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void ApplyKnockback(Vector2 knockbackForce) {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
        rb.velocity = knockbackForce; // apply knockback force
    }
}