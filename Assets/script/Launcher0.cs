using UnityEngine;

public class Launcher0 : MonoBehaviour
{
    public GameObject homingBulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ホーミング弾を生成して発射
            Instantiate(homingBulletPrefab, transform.position, Quaternion.identity);
        }
    }
}