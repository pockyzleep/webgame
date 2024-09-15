using UnityEngine;

public class PlayerFiring : MonoBehaviour {
    public GameObject fpAnim; // anim prefab obj not the actual .anim file
    public GameObject fhAnim;
    public Transform firingPoint; // the child obj angle of the player
    private Animator anim;
    private float nextTimeToFire;
    private float destructorTime1 = 0.5f; // 0.5 sec ignition
    private float destructorTime2 = 0.75f; // 0.75 sec impact
    public AudioSource fireSound;
    public int fireDamage = 15;
    private bool gunEquip = false;
    PlayerController controller; // to modify firing mode to disable movement animation
    
    private void Awake() {
        anim = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
    }
    private void Update() {
        // equip gun using "fire" parameter in animator
        if (Input.GetKeyDown(KeyCode.Q)) {
            anim.SetTrigger("fire"); 
            gunEquip = true;
            controller.firingMode = true;
        }

        // shoot and destroy 
        if (Input.GetMouseButtonDown(0) && gunEquip) {
            Fire();
            fireSound.Play();
        }

        // withdraw shoot by releasing fire equip anim
        if (Input.GetKeyDown(KeyCode.E)) {
            controller.firingMode = false;
            anim.SetTrigger("withdraw");
            gunEquip = false;
        }
    }

    private void Fire() {
        // create the firing point animation at the barrel of the player's weapon
        GameObject firePoint = Instantiate(fpAnim, firingPoint.position, firingPoint.rotation);
        
        // creating a non-collision object to show the impact effect
        Vector3 cursorScreenPos = Input.mousePosition;
        Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(cursorScreenPos.x, cursorScreenPos.y, Camera.main.nearClipPlane));
        GameObject fireHitscan = Instantiate(fhAnim, cursorWorldPos, Quaternion.identity);
        float vertOffset = 0.5f; // there is a vertical offset that needs to be fixed
        fireHitscan.transform.position += new Vector3(0, vertOffset, 0);

        // damage enemy object health using raycast (firing line)
        RaycastHit2D beam = Physics2D.Raycast(firingPoint.position, cursorWorldPos - firingPoint.position);
        EnemyHealth enemy = beam.transform.GetComponent<EnemyHealth>();
        if (enemy != null) {
            // if enemy obj was found s.t. it has an enemy health script then reduce the enemy's health
            // function call
            enemy.TakeDamage(fireDamage);
        }
        
        // self-destruct
        Destroy(firePoint, destructorTime1);
        Destroy(fireHitscan, destructorTime2);
    }
}
