using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour

{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private float fireRate = 1f; // ความถี่ในการยิง
    private float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        // คำนวณทิศทางของกระสุนไปที่ผู้เล่น
        Vector2 targetPosition = player.position;
        // คำนวณความเร็วของลูกศรในแนวแกน x และ y ไปยังผู้เล่น
        Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, targetPosition, 1f);
        // ตั้งค่าความเร็วของกระสุนที่ยิงออกไป
        firedBullet.velocity = projectileVelocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y);
        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }
}
