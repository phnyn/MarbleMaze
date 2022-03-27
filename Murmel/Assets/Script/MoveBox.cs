using UnityEngine;

public class MoveBox : MonoBehaviour
{
    // the boxes in which the marble rolls
    [SerializeField]
    private GameObject _innerBox;
    [SerializeField]
    private GameObject _middleBox;

    // speed of the rotation of the boxes
    [SerializeField]
    private float _speed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frames
    void Update()
    {
        //get the value of the pressed keys 
        //'A' for left and 'W' for right
        float z = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;

        //up and down arrow
        float x = Input.GetAxis("Vertical")* Time.deltaTime * _speed;

        //rotation angles
        float angleZ = _innerBox.transform.localEulerAngles.z;
        float angleX = _middleBox.transform.localEulerAngles.x;
        _innerBox.transform.Rotate(0, 0, z);
        _middleBox.transform.Rotate(x, 0, 0);

/*
       if((angleZ < 10) | (350 < angleZ)){
           _innerBox.transform.Rotate(0, 0, z);
       }

       if(((angleZ == 350) & (checkDirection(z) == true)) | ((angleZ == 10) & (checkDirection(z) == false))){
           _innerBox.transform.Rotate( 0, 0, z);
       }

       if((angleX < 10) | (350 < angleX)){
            _middleBox.transform.Rotate(x, 0, 0);
       }

       if(((angleX == 350) & (checkDirection(x) == true)) | ((angleX == 10) & (checkDirection(x) == false))){
            _middleBox.transform.Rotate(x, 0, 0);
       }


       if(Input.GetKey(KeyCode.Tab)){
           Debug.Log(_middleBox.transform.rotation);
           _middleBox.transform.rotation = Quaternion.identity;
       } */
    }

    /*
    * Returns false if positive, true if negative
    */
    bool checkDirection(float value){
        if(value < 0) return true; 
        else return false;
    }
}
