using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField, Tooltip("Add the objecy that you want this object will follow")] GameObject objectToFollow;
    
    void Update()
    {
        if (objectToFollow != null)
        {
            transform.position = new Vector3(objectToFollow.transform.position.x,objectToFollow.transform.position.y,transform.position.z);
        }
    }
}