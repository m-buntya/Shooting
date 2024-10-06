using UnityEngine;
using UnityEngine.SceneManagement;  // シーン管理を行うために追加
using System.Collections;  // コルーチンを使うために必要

public class Enemy04C : MonoBehaviour
{
    public GameObject EnemyBom;
    private float fireRate;
    private float nextFireTime = 0f;
    public GameObject explosionEffect;
    public GameObject DieEffect;
    public UltButton UltButton;

    private EnemyBossHP enemyBossHP;  // EnemyBossHP スクリプトを参照するための変数

    void Start()
    {
        // 同じオブジェクトにある EnemyBossHP コンポーネントを取得
        enemyBossHP = GetComponent<EnemyBossHP>();

        // HP管理スクリプトが見つからない場合のエラーチェック
        if (enemyBossHP == null)
        {
            Debug.LogError("EnemyBossHP スクリプトが見つかりません！");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("衝突したオブジェクト: " + collision.gameObject.name);

        // プレイヤーの弾に当たった場合
        if (collision.CompareTag("Bullet"))
        {
            // ダメージを与える処理
            ApplyDamage(1);  // 1ダメージを与える

            // 弾も破壊する
            Destroy(collision.gameObject);
        }

        // プレイヤーの必殺技に当たった場合
        if (collision.CompareTag("Ult"))
        {
            Debug.Log("必殺技が当たりました！");
            ApplyDamage(20);  // 20ダメージを与える
        }
    }

    // ダメージを与える処理
    private void ApplyDamage(int damageAmount)
    {
        // EnemyBossHP スクリプトを通じてダメージ処理を行う
        if (enemyBossHP != null)
        {
            enemyBossHP.TakeDamage(damageAmount);
        }

        // ダメージをUltButtonに通知
        if (UltButton != null)
        {
            UltButton.AddDamage(damageAmount);  // ダメージを加算
        }
    }

    // ボスのHPが0になったら破壊する処理
    public void OnBossDeath()
    {
        if (explosionEffect != null)
        {
            Instantiate(DieEffect, transform.position, Quaternion.identity);
        }

        // 2秒待ってからシーン遷移するコルーチンを開始
        StartCoroutine(WaitAndLoadScene());
    }

    // 2秒待ってからゲームクリアシーンに遷移するコルーチン
    private IEnumerator WaitAndLoadScene()
    {
        // 2秒間待つ
        yield return new WaitForSeconds(2f);

        // シーン遷移
        SceneManager.LoadScene("GameClear"); 
    }
}