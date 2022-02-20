using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float bulletForce = 30f;

    public Rigidbody rb;
    public Transform lufa;

    public GameObject bulletPrefab;


    public float damage = 10f;
    public float range = 10f;
    public float fireRate = 15f;
    public float impactForse = 30f;

    public int maxAmmo = 1;
    private int currentAmmo;
    public float reloadTime = 3f;

    public Animator gunAnim;

    private float nextTimeToFire = 0f;

    public bool isReloading = false;

    //public Camera cam;

    Vector3 movement;

    void Start()
    {
        this.GetComponent<Rigidbody>();
            currentAmmo = maxAmmo;
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        if (isReloading)
            return;


        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void Shoot()
    {
        currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab, lufa.position, lufa.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(lufa.forward * bulletForce, ForceMode.Impulse);

    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        gunAnim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        gunAnim.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void MoveCharacter(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Dostałem");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
