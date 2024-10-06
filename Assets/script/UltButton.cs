using UnityEngine;
using UnityEngine.UI;

public class UltButton : MonoBehaviour
{
    public Image fillImage;
    public float maxDamage = 20f;
    private float currentDamage = 0f;
    private bool isReady = false;

    // プレイヤーの参照
    public GameObject player;
    public GameObject ultimatePrefab;
   // public Sprite ultSprite;  // 必殺技用のスプライト
    private Sprite originalSprite;
    private bool isUsingUltimate = false;

    private void Start()
    {
        // 初期状態で必殺技ボタンを消灯
        fillImage.fillAmount = 0f;
        isReady = false;

        // プレイヤーの元のスプライトを保存
        if (player != null)
        {
            originalSprite = player.GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void AddDamage(float damage)
    {
        if (!isReady)
        {
            currentDamage += damage;
            fillImage.fillAmount = currentDamage / maxDamage;

            if (currentDamage >= maxDamage)
            {
                isReady = true;
                fillImage.fillAmount = 1f;
            }
        }
    }

    public void OnUltButtonPressed()
    {
        Debug.Log("ボタンが押されました。");
        if (isReady && player != null && !isUsingUltimate)
        {
            Debug.Log("必殺技が発動しました!");
            ExecuteUltimateAbility();
        }
    }

    private void ExecuteUltimateAbility()
    {

        // プレイヤーの位置を元のプレイヤーに設定し、必殺技用プレハブを生成
        GameObject ultimatePrefabInstance = Instantiate(ultimatePrefab, player.transform.position, Quaternion.identity);
        ultimatePrefabInstance.tag = "Ult"; // タグを設定
        ultimatePrefabInstance.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 10f); // 上方向に移動

        // 当たり判定のためにColliderを有効化
        ultimatePrefabInstance.GetComponent<Collider2D>().enabled = true;
        Debug.Log("必殺技が発動しました。");

        // 元のプレイヤーを非アクティブにする
        player.SetActive(false);
    }

    private void Update()
    {
        // プレイヤーが画面外に出たら元に戻す
        if (isUsingUltimate && player.transform.position.y > Camera.main.orthographicSize + 1f)
        {
            ResetPlayerAfterUltimate();
        }
        // 必殺技プレハブをチェックして破壊する処理
        GameObject[] ultimateObjects = GameObject.FindGameObjectsWithTag("Ult");
        foreach (GameObject ultimate in ultimateObjects)
        {
            // 必殺技プレハブが画面外に出た場合
            if (ultimate.transform.position.y > Camera.main.orthographicSize + 1f)
            {
                Destroy(ultimate); // プレハブを破壊
                ResetPlayerAfterUltimate(); // プレイヤーを元に戻す
            }
        }
    }

    private void ResetPlayerAfterUltimate()
    {
        // 元のプレイヤーをアクティブに戻す
        player.SetActive(true);

        // プレイヤーを元の位置に戻し、速度をリセット
        player.transform.position = new Vector2(0, -Camera.main.orthographicSize + 1f);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        // 状態をリセット
        isUsingUltimate = false;
        currentDamage = 0f;
        fillImage.fillAmount = 0f;
        isReady = false;
    }
}