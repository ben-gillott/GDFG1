using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float startX;
    public float startY;

    //TODO: Switch to bounding box or cinemachine track for the sine math
    public float trackMinX; 
    public float trackMaxX;
    public float moveSpeed;
    private bool headingRight;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(startX, startY, this.transform.position.z);
    }

    void Update()
    {
        // //Move on a linear track
        // float curX = this.transform.position.x;

        // if (headingRight){
        //     curX += moveSpeed * Time.deltaTime;
        //     if (curX > trackMaxX){headingRight = false;}
        // }else{
        //     curX -= moveSpeed;
        //     if (curX < trackMinX){headingRight = true;}
        // }

        // this.transform.position = new Vector3(curX, this.transform.position.y, this.transform.position.z);
    }
}
