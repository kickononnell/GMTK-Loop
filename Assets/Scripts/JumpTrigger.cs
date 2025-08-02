using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] FPS_Mouse_Rotation fps_conch;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint c in collision.contacts)
        {
            if (Vector3.Dot(Vector3.up, c.normal) > .7f)
            {
                fps_conch.canJump = true;
            }
        }
    }
}
