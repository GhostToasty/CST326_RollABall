using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gets attached rigidbody 
        rb = GetComponent<Rigidbody>();
        
        //sets initial count text
        count = 0;
        SetCountText();

        //hides win text
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        //makes input into a Vector 2
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        //store x and y inputs
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        //displays count text 
        countText.text = "Count: " + count.ToString();

        //displays win text if all game objects are collected 
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }


    private void FixedUpdate()
    {
        //makes 3D vector with x and y inputs 
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //applies force and speed to rigidbody
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //checks if game object has "PickUp" tag when player collides with it
        if (other.gameObject.CompareTag("PickUp"))
        {
            //deactivates collided game object, increases count by one, and updates count
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
