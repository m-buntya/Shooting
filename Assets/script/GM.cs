using UnityEngine;

public class GM : MonoBehaviour
{
    public int enemiesDefeated = 0;  // �|���ꂽ�G�̐�
    public int bossSpawnThreshold = 50;  // �{�X���o������G�̓|���ꂽ����臒l
    public GameObject bossPrefab;    // �{�X�̃v���n�u
    public Transform bossSpawnPoint; // �{�X�𐶐�����ʒu

    private bool bossSpawned = false; // �{�X���o���������ǂ����̃t���O

    // �G���|���ꂽ���ɌĂ΂�郁�\�b�h
    public void EnemyDefeated()
    {
        enemiesDefeated++;

        // �{�X���o�����Ă��炸�A�G�̐���臒l�ɒB������{�X���o��������
        if (enemiesDefeated >= bossSpawnThreshold && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    // �{�X���o�������郁�\�b�h
    private void SpawnBoss()
    {
        bossSpawned = true;
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        Debug.Log("�{�X���o�����܂����I");
    }
}