using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
#pragma warning disable CS0649
    private float lengthX, lengthY, startPosX, startPosY;
    private new GameObject camera;
    [SerializeField]
    private float parallaxEffectX;
    [SerializeField]
    private float parallaxEffectY;

    void Start() {
        camera = GameObject.Find("CM vcam1");
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate() {
        float tempX = (camera.transform.position.x * (1 - parallaxEffectX));
        float distX = (camera.transform.position.x * parallaxEffectX);

        float tempY = (camera.transform.position.y * (1 - parallaxEffectY));
        float distY = (camera.transform.position.y * parallaxEffectY);

        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);

        if (tempX > startPosX + lengthX) startPosX += lengthX;
        else if (tempX < startPosX - lengthX) startPosX -= lengthX;

        if (tempY > startPosY + lengthY) startPosY += lengthY;
        else if (tempY < startPosY - lengthY) startPosY -= lengthY;
    }
}
