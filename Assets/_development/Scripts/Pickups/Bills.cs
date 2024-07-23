using UnityEngine;

public class Bills : MonoBehaviour
{
    void Start()
    {
        //Set value from config
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bills");
        //player balance += value
    }
}
