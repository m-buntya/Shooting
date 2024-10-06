using UnityEngine;

public class Launcher : MonoBehaviour
{
    float timeCount = 0;
    float shotAngle = 180;       // 180�x����X�^�[�g
    bool isIncreasing = true;    // �p�x�����������ǂ���
    [SerializeField] GameObject shotBullet;

    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 0.1f)
        {
            timeCount = 0f;

            // �p�x�����������ǂ����ɂ���ď����𕪂���
            if (isIncreasing)
            {
                shotAngle += 10;   // �p�x��10�x����
                if (shotAngle >= 360)
                {
                    isIncreasing = false;  // 360�x�𒴂����猸���ɐ؂�ւ���
                }
            }
            else
            {
                shotAngle -= 10;   // �p�x��10�x����
                if (shotAngle <= 180)
                {
                    isIncreasing = true;   // 180�x����������瑝���ɐ؂�ւ���
                }
            }

            // �e�𐶐����āA�p�x��ݒ�
            GameObject createObject = Instantiate(shotBullet, transform.position, Quaternion.identity);
            BossBom bulletScript = createObject.GetComponent<BossBom>();
            bulletScript.Init(shotAngle, 3); // �p�x�Ƒ��x��n��
        }
    }
}