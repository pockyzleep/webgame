using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour {
    public Light2D obj1; // point light
    public Light2D obj2; // spot light
    public Transform player; // player object

    void Update() {
        // get
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        // calc
        Vector2 direction = (mouseWorldPosition - player.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // need to adjust to fix the offset error of cursor and flashlight not aligning
        float angle1 = angle - 90f; // 90 degrees counterclockwise for the point light
        float angle2 = angle + 90f; // 90 degrees clockwise for the spot light

        // rotate the two lights
        obj1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle1));
        obj2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));
    }
}
