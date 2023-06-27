using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] Gun gun;

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        AimAt(mouse);

        if (Input.GetMouseButtonDown(0))
            gun.PressTrigger();
        if (Input.GetMouseButtonUp(0))
            gun.ReleaseTrigger();
    }

    private void AimAt(Vector2 target)
    {
        Vector3 targetDir = new Vector2(target.x - transform.position.x, target.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        if (angle > 90 || angle < -90)
        {
            aim.localScale = new Vector3(-1f, -1f, 1f);
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else
        {
            aim.localScale = new Vector3(1f, 1f, 1f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        aim.rotation = Quaternion.Euler(0, 0, angle);
    }
}