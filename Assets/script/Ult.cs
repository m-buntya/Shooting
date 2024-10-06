using UnityEngine;

public class Ult : MonoBehaviour
{
    public float speed = 10f;  // 弾の移動速度
    public GameObject explosionPrefab;

    private void Start()
    {
        // 弾を上方向に移動させる
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, speed); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // エネミーに当たった場合の処理
        if (collision.CompareTag("Enemy")) // "Enemy"タグを持つ場合
        {
            Debug.Log("必殺技がエネミーに当たりました！");
            // ここでエネミーのHPを減少させる処理などを実行
            // 衝突したオブジェクトがSkillタグを持つか確認
            if (collision.gameObject.CompareTag("Skill"))
            {
                // 衝突した位置に爆発を生成
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                // 弾を破壊
                Destroy(gameObject);
            }
        }

        // EnemyBulletタグを持つ弾と衝突した場合
        if (collision.CompareTag("EnemyBullet"))
        {
            Debug.Log("EnemyBulletと衝突しました。");
            Destroy(collision.gameObject); // EnemyBulletを破壊
        }
    }
}