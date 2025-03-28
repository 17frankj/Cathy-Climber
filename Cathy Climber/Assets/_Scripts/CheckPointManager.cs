using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static int currentCheckpoint = 0;

    void OnCollisionEnter(Collision collision)
    {
        switch(currentCheckpoint)
        {

            case 0: 
                ActivateFirstCheckPoint();
                return;
            default:
                return;
        }
    }

    private void ActivateFirstCheckPoint()
    {
        currentCheckpoint++; // proceed to next checkpoint
    }
}
