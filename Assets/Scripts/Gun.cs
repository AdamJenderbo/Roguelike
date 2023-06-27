using UnityEngine;

public class Gun : MonoBehaviour
{
    enum FireMode
    {
        MANUEL, AUTOMATIC
    }

    [SerializeField] Bullet bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] FireMode fireMode;
    [SerializeField] float fireRate;

    bool triggerIsDown;
    float fireTimer;

    void Start()
    {
        triggerIsDown = false;
        fireTimer = 1;
    }

    void Update()
    {
        if (fireMode == FireMode.AUTOMATIC && triggerIsDown)
            Fire();

        fireTimer += fireRate * Time.deltaTime;
    }

    public void PressTrigger()
    {
        Fire();
        triggerIsDown = true;
    }

    public void ReleaseTrigger()
    {
        triggerIsDown = false;
    }

    private void Fire()
    {
        if (fireTimer < 1)
            return;

        Instantiate(bullet, firePoint.position, transform.rotation);
        fireTimer = 0;
    }
}