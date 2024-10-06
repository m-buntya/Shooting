using UnityEngine;
using UnityEngine.UI;

public class EnemyBossHP : MonoBehaviour
{
    public Image hpBarFill;  // HPバーのフィル部分
    public int maxHP = 100;  // ボスの最大HP
    private int currentHP;   // ボスの現在のHP
    private Enemy04C bossEnemy;  // ボスのHPを管理するスクリプト

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();

        // Enemy04C スクリプトを取得
        bossEnemy = GetComponent<Enemy04C>();

        // HP管理スクリプトが見つからない場合のエラーチェック
        if (bossEnemy == null)
        {
            Debug.LogError("Enemy04C スクリプトが見つかりません！");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);  // HPを0からmaxHPの範囲内に収める
        UpdateHPBar();  // HPバーを更新

        if (currentHP <= 0)
        {
            // ボスが死んだ場合、Enemy04CのOnBossDeathメソッドを呼び出す
            if (bossEnemy != null)
            {
                bossEnemy.OnBossDeath();
            }
        }
    }

    void UpdateHPBar()
    {
        hpBarFill.fillAmount = (float)currentHP / maxHP;
    }
}