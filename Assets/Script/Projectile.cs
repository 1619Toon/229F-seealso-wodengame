using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D bulletPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.blue, 10f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector3(hit.point.x, hit.point.y);

                Vector2 projectile = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                // สร้างกระสุน
                Rigidbody2D bulletInstance = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                bulletInstance.velocity = projectile;
            }
        }
    }

    private Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y);

        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // ตรวจสอบว่าชนกับศัตรูหรือไม่
        {
        Destroy(other.gameObject); // ลบศัตรู 
        }
    }

}

