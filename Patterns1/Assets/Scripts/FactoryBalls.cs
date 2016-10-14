using UnityEngine;
using System.Collections;

public class FactoryBalls : MonoBehaviour {

    public float spawnWait;
    public GameObject o;
    public Vector3 spawnValues= new Vector3(10,10,10);
    public float startWait;
 

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            Vector3 spawnPosition = new Vector3(-40, (Random.Range(-spawnValues.y, spawnValues.y)), (Random.Range(-spawnValues.z, spawnValues.z)));
            Quaternion spawnRotation = Quaternion.identity;
            GameObject n=(GameObject) Instantiate(o, spawnPosition, spawnRotation);
            MiniBalls ball = n.GetComponent<MiniBalls>();
            float number = Random.Range(0, 3);
            if (number == 0)
            {
                ball.myBehavior = new MoveStraight();
            }
            else if (number == 1)
            {
                ball.myBehavior = new ChangeAngle();
            }
            else
            {
                ball.myBehavior = new JitterMove();
            }

        }
    }
}
