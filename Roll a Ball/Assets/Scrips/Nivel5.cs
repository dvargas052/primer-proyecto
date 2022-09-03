using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nivel5 : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Text dead;
    public GameObject damage;
    public int life = 100;
     


    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetcountText();
        winTextObject.SetActive(false);
        damage.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetcountText()
    {
        dead.text = life.ToString();
        if (life == 0)
        {
            damage.SetActive(true);
        }
        countText.text = "Count:" + count.ToString();
        if (count >= 10)
        {
            winTextObject.SetActive(true);
            SceneManager.LoadScene(2);
        }
    }




    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
           count++;
            SetcountText();
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            life -= 40;
            SetcountText();
        }

        if (other.gameObject.CompareTag("Heart")) 
        {
            other.gameObject.SetActive(false);
            life += 20;
            SetcountText();
        }
        if (other.gameObject.CompareTag ("Run"))
        {
            other.gameObject.SetActive(false);
            speed += 5;
            SetcountText();
            
            IEnumerator espera()
            {
                yield return new WaitForSeconds(3);
                
            }
            speed -= 5;
        }

    }
    


}
