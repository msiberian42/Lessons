using UnityEngine;

public class FPController : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource land;
    [SerializeField] private AudioSource ammoPickUp;
    [SerializeField] private AudioSource medkitPickUp;
    [SerializeField] private AudioSource triggerSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private Transform shotDirection;

    private Rigidbody rb;
    private CapsuleCollider capsule;

    private Quaternion cameraRot;
    private Quaternion characterRot;
    private float minimumX = -90f;
    private float maximumX = 90f;

    private bool cursorIsLocked = true;
    private bool lockCursor = true;

    private float x;
    private float z;

    //Inventory
    [SerializeField] private int ammo;
    private int maxAmmo = 50;
    [SerializeField] private int ammoClip;
    private int ammoClipMax = 10;

    //Health
    private int health = 100;
    private int maxHealth = 100;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();

        cameraRot = cam.transform.localRotation;
        characterRot = this.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoClip > 0)
            {
                anim.SetTrigger("fire");
                ProcessZombieHit();
                ammoClip--;
            }
            else if (anim.GetBool("arm"))
            {
                triggerSound.Play();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R) && ammoClip < ammoClipMax && ammo > 0 && anim.GetBool("arm"))
        {
            anim.SetTrigger("reload");
            reloadSound.Play();
            if (ammo >= ammoClipMax)
            {
                ammo -= ammoClipMax - ammoClip;
                ammoClip = ammoClipMax;
            }
            else
            {
                ammoClip += ammo;
                ammo = 0;
            }
        }

        if (Mathf.Abs(x) >= 0.02f || Mathf.Abs(z) >= 0.02f)
        {
            if (!anim.GetBool("walking"))
            {
                anim.SetBool("walking", true);
                footstep.Play();
            }
        }
        else if (anim.GetBool("walking"))
        {
            anim.SetBool("walking", false);
            footstep.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(0f, 300f, 0f);
            jump.Play();

            if (anim.GetBool("walking"))
            {
                footstep.Stop();
            }
        }
    }
    private void FixedUpdate()
    {
        float yRot = Input.GetAxis("Mouse X");
        float xRot = Input.GetAxis("Mouse Y");

        cameraRot *= Quaternion.Euler(-xRot * sensitivity, 0f, 0f);
        characterRot *= Quaternion.Euler(0f, yRot * sensitivity, 0f);

        cameraRot = ClampRotAroundX(cameraRot);

        this.transform.localRotation = characterRot;
        cam.transform.localRotation = cameraRot;

        x = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        z = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        if (Mathf.Abs(x) >= 0.02f || Mathf.Abs(z) >= 0.02f)
            transform.position += cam.transform.forward * z + cam.transform.right * x; 

        UpdateCursorLock();
    }

    private void ProcessZombieHit()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(shotDirection.position, shotDirection.forward, out hitInfo, 200))
        {
            GameObject hitZombie = hitInfo.collider.gameObject;
            if (hitZombie.CompareTag("Zombie"))
            {
                hitZombie.GetComponent<ZombieController>().KillZombie();
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hitInfo;

        return Physics.SphereCast(transform.position, capsule.radius, Vector3.down, out hitInfo,
                (capsule.height / 2f) - capsule.radius + 0.1f);
    }

    public void TakeHit(float amount)
    {
        health = (int) Mathf.Clamp(health - amount, 0, maxHealth);
        Debug.Log("Health " + health);
    }
    private Quaternion ClampRotAroundX(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = 2f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, minimumX, maximumX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;

        if (!lockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        if (lockCursor)
        {
            InternalLockUpdate();
        }
    }
    public void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            cursorIsLocked = false;
        else if (Input.GetMouseButtonUp(0))
            cursorIsLocked = true;

        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Lava")
        {
            health -= 10;
            deathSound.Play();
            Debug.Log("Health: " + health);
        }

        if (col.gameObject.tag == "Ammo" && ammo < maxAmmo)
        {
            ammo = Mathf.Clamp(ammo + 10, 0, maxAmmo);
            
            Destroy(col.gameObject);
            ammoPickUp.Play();
            Debug.Log("Ammo: " + ammo);
        }
        
        if (col.gameObject.tag == "MedKit" && health < maxHealth)
        {
            health = Mathf.Clamp(health + 25, 0, maxHealth);
            
            Destroy(col.gameObject);
            medkitPickUp.Play();
            Debug.Log("Health: " + health);
        }

        if (IsGrounded())
        {
            land.Play();
            if (anim.GetBool("walking"))
            {
                anim.SetBool("walking", true);
                footstep.Play();
            }
        }
        
    }
}
