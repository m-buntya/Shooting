using UnityEngine;

public class Launcher0 : MonoBehaviour
{
    public GameObject homingBulletPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �z�[�~���O�e�𐶐����Ĕ���
            Instantiate(homingBulletPrefab, transform.position, Quaternion.identity);
        }
    }
}