using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 aimDir;
    public GameObject projectilePrefab;

    Transform aimTransform;

    void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        HandleShooting();
    }
    private void HandleAiming()
    {
        Vector3 mousePos = GetMouseWorldPosition();

        aimDir = (mousePos - transform.position).normalized; // Getting Direction of aim and normalizing it
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg; // angle of the wand or whateever tf that was
        aimTransform.eulerAngles = new Vector3(0, 0, angle); // rotation of le wand
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 0f;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(aimDir.normalized, 600);
    }
}
