using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomlevel : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public float fireRate = 0.1f;   // 発射間隔
    public int numberOfBullets = 10; // 一度に発射する弾の数
    public float spreadAngle = 30f; // 弾の広がり角度
    public float bulletSpeed = 5f;  // 弾のスピード
    private float nextFireTime = 0f;

    void Update()
    {
        // 次に弾を発射する時間を超えているか確認
        if (Time.time >= nextFireTime)
        {
            FireBullet();  // 弾を発射
            nextFireTime = Time.time + fireRate;  // 次に発射する時間を設定
        }
    }

    void FireBullet()
    {
        float startAngle = -spreadAngle / 2; // 左端から始める角度
        float angleStep = spreadAngle / (numberOfBullets - 1); // 各弾の角度の間隔

        for (int i = 0; i < numberOfBullets; i++)
        {
            float currentAngle = startAngle + i * angleStep; // 各弾の角度を計算
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // 弾を生成
            BossBom bulletScript = bullet.GetComponent<BossBom>(); // 弾のスクリプトを取得

            if (bulletScript != null)
            {
                bulletScript.Init(currentAngle + 90f, -bulletSpeed); // 角度を下方向に調整（90度追加）
            }
        }
    }
}