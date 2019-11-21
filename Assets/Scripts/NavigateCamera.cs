using UnityEngine;


public class NavigateCamera : MonoBehaviour
{

    public float Speed = 2.0f;
    private float timeLeft;
    private Camera cam;
    public Transform HouseTransform;
    protected Vector3 _cameraOffset;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;
    protected bool RotateAroundPlayer = false;
    protected float RotationsSpeed = 5.0f;
    public float damping = 5f;
    private float boundsCenterY = 50f;
    private float downTime = 0.5f;
    private Vector3 firstpoint = new Vector3(0f, 1f, -10f);
    private Vector3 secondpoint = new Vector3(0f, 1f, -10f);


    void Start()
    {
        cam = Camera.main;
        timeLeft = 4 / Speed;

        if (HouseTransform != null)
        {
            _cameraOffset = cam.transform.position - HouseTransform.position;
        }
    }


    void LateUpdate()
    {
        /*if (Input.GetMouseButtonDown(0)) RotateAroundPlayer = true;
        if (Input.GetMouseButtonUp(0)) RotateAroundPlayer = false;

        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

            float posY = cam.transform.position.y - Input.GetAxis("Mouse Y") * RotationsSpeed;
            _cameraOffset = camTurnAngle * _cameraOffset;

            Vector3 newPos = HouseTransform.GetComponent<Renderer>().bounds.center + _cameraOffset;
            newPos.y = Mathf.Clamp(posY, boundsCenterY + 10, boundsCenterY + 90f);
            cam.transform.position = Vector3.Lerp(cam.transform.position, newPos, SmoothFactor);

            if (LookAtPlayer || RotateAroundPlayer)
            {
                cam.transform.LookAt(HouseTransform.GetComponent<Renderer>().bounds.center);
            }
        }*/
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;

                Quaternion camTurnAngle = Quaternion.AngleAxis((secondpoint.x - firstpoint.x) * RotationsSpeed / 200f, Vector3.up);

                float posY = cam.transform.position.y - (secondpoint.y - firstpoint.y) * RotationsSpeed / 200f;
                _cameraOffset = camTurnAngle * _cameraOffset;

                Vector3 newPos = HouseTransform.GetComponent<Renderer>().bounds.center + _cameraOffset;
                newPos.y = Mathf.Clamp(posY, boundsCenterY + 10, boundsCenterY + 90f);

                cam.transform.position = newPos;// Vector3.Lerp(cam.transform.position, newPos, SmoothFactor);

                //if (LookAtPlayer || RotateAroundPlayer)
                {
                    cam.transform.LookAt(HouseTransform.GetComponent<Renderer>().bounds.center);
                }
            }
        }
    }

}