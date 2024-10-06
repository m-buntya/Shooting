using UnityEngine;

public class Launcher : MonoBehaviour
{
    float timeCount = 0;
    float shotAngle = 180;       // 180度からスタート
    bool isIncreasing = true;    // 角度が増加中かどうか
    [SerializeField] GameObject shotBullet;

    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 0.1f)
        {
            timeCount = 0f;

            // 角度が増加中かどうかによって処理を分ける
            if (isIncreasing)
            {
                shotAngle += 10;   // 角度を10度増加
                if (shotAngle >= 360)
                {
                    isIncreasing = false;  // 360度を超えたら減少に切り替える
                }
            }
            else
            {
                shotAngle -= 10;   // 角度を10度減少
                if (shotAngle <= 180)
                {
                    isIncreasing = true;   // 180度を下回ったら増加に切り替える
                }
            }

            // 弾を生成して、角度を設定
            GameObject createObject = Instantiate(shotBullet, transform.position, Quaternion.identity);
            BossBom bulletScript = createObject.GetComponent<BossBom>();
            bulletScript.Init(shotAngle, 3); // 角度と速度を渡す
        }
    }
}