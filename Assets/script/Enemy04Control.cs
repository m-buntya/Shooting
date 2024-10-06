using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;      // エネミーの移動速度
    public float stopDistance = 9f;   // 移動する距離
    private float initialY;           // 初期位置のY座標



void Start()
    {
        // エネミーの初期Y座標を記録する
        initialY = transform.position.y;
    }

    void Update()
    {
        // エネミーが停止位置に到達していない場合に移動させる
        if (transform.position.y > initialY - stopDistance)
        {
            MoveDown();
        }
    }

    // エネミーをY軸方向に下に移動させるメソッド
    void MoveDown()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}