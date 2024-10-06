using UnityEngine;

public class GM : MonoBehaviour
{
    public int enemiesDefeated = 0;  // 倒された敵の数
    public int bossSpawnThreshold = 50;  // ボスが出現する敵の倒された数の閾値
    public GameObject bossPrefab;    // ボスのプレハブ
    public Transform bossSpawnPoint; // ボスを生成する位置

    private bool bossSpawned = false; // ボスが出現したかどうかのフラグ

    // 敵が倒された時に呼ばれるメソッド
    public void EnemyDefeated()
    {
        enemiesDefeated++;

        // ボスが出現しておらず、敵の数が閾値に達したらボスを出現させる
        if (enemiesDefeated >= bossSpawnThreshold && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    // ボスを出現させるメソッド
    private void SpawnBoss()
    {
        bossSpawned = true;
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        Debug.Log("ボスが出現しました！");
    }
}