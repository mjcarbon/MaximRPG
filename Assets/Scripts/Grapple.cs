using UnityEngine;

public class Grapple : MonoBehaviour
{
    public PlayerController playerController; 
    public CharacterController controller;
    public Camera cam; 
    public float maxGrappleDist; 
    public float speed; 

    public LineRenderer lr;
    public Transform gunTip; 

    private Vector3 grappleLocation; 
    private bool doGrapple = false; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GrappleRay(); 
        }
        if (doGrapple == true) // IF GRAPPLE IS ON 
        { 
            MovePlayer();
            
        }
    }

    private void MovePlayer()
    {
        transform.position = Vector3.Lerp(transform.position, grappleLocation,speed * Time.deltaTime * 0.5f);
        float dist = Vector3.Distance(transform.position, grappleLocation);
        if (dist <= 2f)
        {
            doGrapple = false; 
            playerController.enabled = true; 
        }
    }
    private void GrappleRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, maxGrappleDist))
        {
            if(hit.collider.CompareTag("GrappleSpot"))
            {
                grappleLocation = hit.point; 
                doGrapple = true; 
                playerController.enabled = false;
                Debug.Log("New RAY " + grappleLocation);
            }
        }
    }

}
 