using UnityEngine;
using System.Collections;

public class BulletC : MonoBehaviour
{
    public float bulletSpeed = 5f; // 弾の速度
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // エネミーの弾と衝突した場合、両方の弾を消す
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject); // エネミーの弾を消す
            Destroy(gameObject); // プレイヤーの弾も消す
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがSkillタグを持つか確認
        if (collision.gameObject.CompareTag("Skill"))
        {
            // 衝突した位置に爆発を生成
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 弾を破壊
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Translate(0, 0.05f, 0);
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
