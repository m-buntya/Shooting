using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 3f;  // 爆発の範囲
    public int damageAmount = 5;        // ダメージ量
    public string enemyTag = "Enemy";   // エネミーのタグ (全てのエネミーにこのタグをつけておく)

    private void Start()
    {
        // 爆発の範囲内にあるコライダーをすべて検出
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            // タグでエネミーかどうかを確認
            if (hitCollider.CompareTag(enemyTag))
            {
                // ここでエネミーにダメージを与える処理を呼び出す
                Debug.Log("エネミーが爆発範囲に入りました！");

                // 各エネミーにダメージを与えるメソッドが存在することを仮定して呼び出す
                hitCollider.SendMessage("TakeDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
                // SendMessageOptions.DontRequireReceiver を使うことで、該当メソッドがない場合でもエラーにならない
            }

            // 敵の弾に当たったか確認して破壊
            if (hitCollider.CompareTag("EnemyBullet"))
            {
                Debug.Log("敵の弾が爆発範囲に入りました！破壊します。");
                Destroy(hitCollider.gameObject);  // 敵の弾を破壊
            }
        }

       
        
            ParticleSystem ps = GetComponent<ParticleSystem>();
            Destroy(gameObject, ps.main.duration); // パーティクルが再生終了後にオブジェクトを破壊
        
    }

    // デバッグ用に、爆発範囲をエディタ上で表示
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}