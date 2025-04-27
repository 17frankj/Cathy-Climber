using UnityEngine;

public class check_1 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        CheckPoint_Manager_main_level.one_active = true;
    }
}
