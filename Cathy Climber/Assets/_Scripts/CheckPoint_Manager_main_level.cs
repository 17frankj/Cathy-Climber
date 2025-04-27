using UnityEngine;

public class CheckPoint_Manager_main_level : MonoBehaviour
{
    public static int currentCheckpoint_main_level = 0;
    [SerializeField] private AudioSource source;
    public static bool one_active = false;
    public static bool two_active = false;
    public static bool three_active = false;

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
            case 1:
                ActivateSecondCheckPoint();
                return;
            default:
                return;
        }
    }

    private void ActivateFirstCheckPoint()
    {
        if(one_active == true)
        {
            currentCheckpoint_main_level++; // proceed to next checkpoint
            source.Play();
        }
    }
    private void ActivateSecondCheckPoint()
    {
        if(two_active == true)
        {
            currentCheckpoint_main_level++; // proceed to next checkpoint
            source.Play();
        }
    }
}
