using UnityEngine;

public class EnemyC01 : MonoBehaviour
{
    public Entity_Enemy1 enemyData;  // ScriptableObjectの参照
    public GameObject EnemyBom;
    private int enemyHP;
    private float fireRate;
    private float nextFireTime = 0f;
    public GameObject explosionEffect;
    public GameObject DieEffect;
    public UltButton UltButton;
    private GM gm;
   

    private void Start()
    {
  
        // ScriptableObjectからデータを設定する
        if (enemyData != null && enemyData.sheets.Count > 0)
        {
            var sheet = enemyData.sheets[0];  // 1つのシートを取得
            if (sheet.list.Count > 0)
            {
                var enemyParams = sheet.list[0];  // 1つのパラメータを取得
                enemyHP = (int)enemyParams.HP;
                fireRate = (float)enemyParams.fireRate; ;
            }
            else
            {
                // デフォルト値を設定する場合
                enemyHP = 3;
                fireRate = 1.5f;
            }
        }
        else
        {
            // デフォルト値を設定する場合
            enemyHP = 3;
            fireRate = 1.5f;
        }
        gm = FindObjectOfType<GM>();
        if (gm == null)
        {
            Debug.LogError("GameManager が見つかりません。");
        }

        if (UltButton == null)
        {
            UltButton = FindObjectOfType<UltButton>();

            if (UltButton == null)
            {
                Debug.LogError("UltButton が見つかりません。");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突したオブジェクト: " + collision.gameObject.name);
        // プレイヤーの弾に当たった場合
        if (collision.CompareTag("Bullet"))
        {
            // enemyHPを減少させる処理
            enemyHP--;
            // ダメージをUltButtonに通知
            if (UltButton != null)
            {
               UltButton.AddDamage(1); // ダメージを加算
            }

            // エネミーのHPが0になったら破壊する
            if (enemyHP <= 0)
            {
                if (explosionEffect != null)
                {
                    Instantiate(DieEffect, transform.position, Quaternion.identity);
                }
                NotifyGameManager();  // 敵が倒されたことを通知
                Destroy(gameObject); // エネミーを破壊
            }

            // 弾も破壊する
            Destroy(collision.gameObject);
        }
        // プレイヤーの必殺技に当たった場合
        if (collision.CompareTag("Ult"))
        {
            Debug.Log("必殺技が当たりました！");
            // enemyHPを減少させる処理
            enemyHP = enemyHP-20;

            // エネミーのHPが0になったら破壊する
            if (enemyHP <= 0)
            {
                if (explosionEffect != null)
                {
                    Instantiate(DieEffect, transform.position, Quaternion.identity);
                }
                NotifyGameManager();  // 敵が倒されたことを通知
                Destroy(gameObject); // エネミーを破壊
            }
        }
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        Debug.Log(gameObject.name + " が " + damageAmount + " ダメージを受けました。 残りHP: " + enemyHP);
        if (enemyHP <= 0)
        {
            if (explosionEffect != null)
            {
                Instantiate(DieEffect, transform.position, Quaternion.identity);
               
            }
            NotifyGameManager();  // 敵が倒されたことを通知
            Destroy(gameObject); // エネミーを破壊
        }
    }

    private void NotifyGameManager()
    {
        // GameManagerに敵が倒されたことを通知する
        if (gm != null)
        {
            gm.EnemyDefeated();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間ごとに弾を発射
        if (Time.time >= nextFireTime)
        {
            Instantiate(EnemyBom, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }
}