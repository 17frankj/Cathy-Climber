using UnityEngine;

public class CheckPoint_Manager_main_level : MonoBehaviour
{
    public static int currentCheckpoint_main_level = 0;
    [SerializeField] private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch(currentCheckpoint_main_level)
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
        currentCheckpoint_main_level++; // proceed to next checkpoint
        source.Play();
    }
}
