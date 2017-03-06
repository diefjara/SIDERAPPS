using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
    }
    private void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3()
        {
            x = movehorizontal,
            y = 0.0f,
            z = movevertical
        };

        rb.AddForce(Movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count+=1;
            setCountText();
        }
    }
    
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >=10)
        {
            winText.text = "You Win!";
        }
    }
}
