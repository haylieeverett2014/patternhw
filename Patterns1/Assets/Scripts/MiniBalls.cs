using UnityEngine;
using System.Collections;
using System;
//passing in a transform
[System.Serializable]
public abstract class BehaviorSphere
{
    public abstract void move(Transform t);
    
};
[System.Serializable]
public class MoveStraight : BehaviorSphere 
{
    public override void move(Transform t)
    {
       t.position = t.position+t.right * 0.1f;
    }
};
[System.Serializable]
public class ChangeAngle : BehaviorSphere
{
    public override void move(Transform t)
    {
        //current angle add euler and then stick in quaternion, add two vectors, current plus changed one
        Vector3 changer = new Vector3(0.0f,0.0f,0.0f);
        changer.y = UnityEngine.Random.Range(-3f, 3f);
        changer.z = UnityEngine.Random.Range(-3f, 3f);
        changer.x = UnityEngine.Random.Range(-3f, 3f);
        Vector3 ourAngle = t.rotation.eulerAngles;
        t.rotation = Quaternion.Euler(ourAngle.x+changer.x, ourAngle.y+changer.y, ourAngle.z+changer.z);
        t.position = t.position + t.right * 0.1f;
    }
};
[System.Serializable]
public class JitterMove : BehaviorSphere
{
     public override void move(Transform t)
     {
        //current position and then moving up or down
        t.position = t.position + t.right * 0.1f;
        Vector3 num= t.rotation.eulerAngles;
        num.y = UnityEngine.Random.Range(-0.3f,0.3f);
        num.x = UnityEngine.Random.Range(-0.3f,0.3f);
        num.z = UnityEngine.Random.Range(-0.3f, 0.3f);
        Vector3 change = new Vector3(num.x, num.y, num.z) ;
        t.position = t.position + change;
    }
};


//using UnityEngine;
//using System.Collections;
//Behavior not inheriting, other behaviors inheriting from behavior
public class MiniBalls : MonoBehaviour
{
    public BehaviorSphere myBehavior;

    // Update is called once per frame
    void FixedUpdate()
    {
        myBehavior.move(transform);
    }
};

