using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedEnemyLookAt : MonoBehaviour
{
    public int enemyNum;

    Enemy1 enemy1;
    Enemy2 enemy2;
    Enemy3 enemy3;
    Enemy4 enemy4;

    // Start is called before the first frame update
    void Start()
    {
        enemy1 = FindObjectOfType<Enemy1>();
        enemy2 = FindObjectOfType<Enemy2>();
        enemy3 = FindObjectOfType<Enemy3>();
        enemy4 = FindObjectOfType<Enemy4>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyNum)
		{
            case 1:
                transform.LookAt(enemy1.target);
                break;
            case 2:
                transform.LookAt(enemy2.target);
                break;
            case 3:
                transform.LookAt(enemy3.target);
                break;
            case 4:
                transform.LookAt(enemy4.target);
                break;
        }
    }

}
