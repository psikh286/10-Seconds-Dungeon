using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //public vars    
    public float smoothSpeed;
    public Vector3 offset;

    public Transform target;	

	private void FixedUpdate()
    {
        if (playerAtributes.playerAlive)
		{
            if (target != null)
            {
                Camera();
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            
        }            
    }
    
    private void Camera()
    {
        //vars
        Vector3 desired_position = target.position;
        Vector3 smoothed_position = Vector3.Lerp(transform.position, desired_position + offset, smoothSpeed * Time.deltaTime);

        //sets the position
        transform.position = smoothed_position;        
    }
}
