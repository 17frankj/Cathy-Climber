using UnityEngine;

public class check_2 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        CheckPoint_Manager_main_level.two_active = true;
    }
}
