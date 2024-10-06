using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBom : MonoBehaviour
{
    [SerializeField] float angle; // 角度
    [SerializeField] float speed; // 速度
    Vector3 velocity; // 移動量
    public int bulletDamage;
    public UltButton ultButton;  // UltButtonスクリプトへの参照

    void Start()
    {
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        //弾の方向を設定する
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        // UltButtonを自動的に取得
        if (ultButton == null)
        {
            ultButton = FindObjectOfType<UltButton>();
        }
        // 5秒後に削除
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        // 毎フレーム、弾を移動させる
        transform.position += velocity * Time.deltaTime;
    }

    public void Init(float input_angle, float input_speed)
    {
        Debug.Log("Init Called: angle = " + input_angle + ", speed = " + input_speed); // デバッグログ
        angle = input_angle;
        speed = input_speed;
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        //弾の方向を設定する
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーに当たった場合、ダメージを与える
        if (other.CompareTag("Player"))
        {
            HPBarController playerHP = other.GetComponent<HPBarController>();
            if (playerHP != null)
            {
                Debug.Log(bulletDamage);
                playerHP.TakeDamage(bulletDamage);  // ダメージを与える
            }

            // エネミーの弾を破壊
            Destroy(gameObject);
        }

        // プレイヤーの弾と衝突した場合、両方の弾を破壊
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // プレイヤーの弾を破壊
            Destroy(gameObject);       // エネミーの弾を破壊

            // Ultゲージを0.5増加させる
            if (ultButton != null)
            {
                ultButton.AddDamage(0.5f);  // 0.5を加算
            }
        }
    }
}