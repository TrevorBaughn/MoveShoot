using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventLeaveScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clampMovementX();
        clampMovementY();
    }

    //modified function from
    //https://stackoverflow.com/questions/42800645/how-to-completely-prevent-the-player-from-going-offscreen-in-unity
    void clampMovementX()
    {
        Vector3 position = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + (this.gameObject.transform.localScale.x / 2);
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - (this.gameObject.transform.localScale.x / 2);

        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        transform.position = position;
    }

    void clampMovementY()
    {
        Vector3 position = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y + (this.gameObject.transform.localScale.y / 2);
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y - (this.gameObject.transform.localScale.y / 2);

        position.y = Mathf.Clamp(position.y, topBorder, bottomBorder);
        transform.position = position;
    }
}
