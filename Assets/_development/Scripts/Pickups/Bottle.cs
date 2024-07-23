using UnityEngine;

public class Bottle : MonoBehaviour
{
    void Start()
    {
        //Set value from config
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bottle");
        //player balance -= value
    }
}
