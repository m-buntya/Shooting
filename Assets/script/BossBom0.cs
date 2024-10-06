using UnityEngine;

public class BossBom0 : MonoBehaviour
{
    public float speed = 2f;  // 弾の速度
    private Vector3 moveDirection;  // 移動する方向

    void Start()
    {
        // プレイヤーオブジェクトを探して、その座標をターゲット位置に設定
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Vector3 targetPosition = playerObject.transform.position;  // 発射時に一度だけプレイヤーの座標を取得

            // 弾の向きをターゲットの方向に設定
            moveDirection = (targetPosition - transform.position).normalized;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }

        // 5秒後に弾を削除
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // 設定した方向に進み続ける
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}