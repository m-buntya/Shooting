using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image fillImage;
    public float cooldownTime = 10f;
    private float currentCooldownTime = 0f;
    private bool isReady = false;
    // スキルオブジェクトのプレハブ
    public GameObject skillPrefab;

    // プレイヤーの位置を参照するための変数
    public GameObject player;
    void Update()
    {
        if (!isReady)
        {
            currentCooldownTime += Time.deltaTime;
            fillImage.fillAmount = currentCooldownTime / cooldownTime;

            if (currentCooldownTime >= cooldownTime)
            {
                isReady = true;
                fillImage.fillAmount = 1f;
            }
        }
    }
    public void OnSkillButtonPressd()
    {
        if (isReady)
        {
            Debug.Log("スキル発動！");
            // スキルを実行
            ExecuteUltimateAbility();

            // カウントリセット
            isReady = false;
            currentCooldownTime = 0f;
            fillImage.fillAmount = 0f;
        }
    }
    private void ExecuteUltimateAbility()
    {
        // プレイヤーの位置を取得
        if (player != null && skillPrefab != null)
        {
            // プレイヤーの位置にスキルを生成
            Vector2 spawnPosition = player.transform.position;
            GameObject skill = Instantiate(skillPrefab, spawnPosition, Quaternion.identity);

            // スキルオブジェクトに移動処理を指示
            skill.GetComponent<Skill>().SetDirection(Vector2.up);  // 上方向に移動
        }
        else
        {
            Debug.LogError("プレイヤーまたはスキルPrefabが設定されていません！");
        }
    }
}