using UnityEngine;

public class Skill : MonoBehaviour
{
    public float speed = 5f;              // 移動速度
    private Vector2 moveDirection;        // 移動方向
    private Vector2 initialPosition;      // 初期位置
    public float maxDistance = 6f;        // 最大移動距離 
    public GameObject explosionPrefab;    // 爆発プレハブ
    private bool hasStopped = false;      // スキルが停止しているかを示すフラグ

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
        initialPosition = transform.position;  // スキルが生成された位置を記録
    }

    void Update()
    {
        if (!hasStopped)
        {
            float traveledDistance = Vector2.Distance(initialPosition, transform.position);
            if (traveledDistance < maxDistance)
            {
                // スキルを移動させる
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
            else
            {
                // 移動が最大距離に達したら停止
                StopSkill();
            }
        }
    }

    // スキルの移動を停止する
    void StopSkill()
    {
        speed = 0f;
        hasStopped = true;
    }

    // スキルが停止した後にだけBulletに当たるようにする
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasStopped && other.CompareTag("Bullet"))  // 停止後にBulletと衝突を確認
        {
            // 爆発プレハブを生成
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("エフェクトの確認");
            // スキル自体を破壊
            Destroy(gameObject);
        }
        if (hasStopped && other.CompareTag("Ult"))  // 停止後にUlttと衝突を確認
        {
            // 爆発プレハブを生成
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("エフェクトの確認");
            // スキル自体を破壊
            Destroy(gameObject);
        }
    }
}