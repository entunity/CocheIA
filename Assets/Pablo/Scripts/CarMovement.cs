using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour {

    [SerializeField] int MoveSpeed = 4;
    [SerializeField] int RotationSpeed = 4;
    int rotation = 0;
    int contador;
    int randomNumber;
    int counter;
    int marcha = 1;
    bool girando = false;
    void Start()
    {

        randomNumber = Random.Range(1, 3);


    }

    void Update()
    {

      transform.position += transform.forward * MoveSpeed * Time.deltaTime*marcha;
      
        counter = 0;
        if (randomNumber == 1)
        {
            
            transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        } if(randomNumber==2)
        {
            
            transform.Rotate(Vector3.down * Time.deltaTime * RotationSpeed );
        }
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Pared")
        {
            randomNumber = Random.Range(1, 3);
            Debug.Log("r" + randomNumber);
            Debug.Log("He chocado");
            RotationSpeed = Random.Range(20, 31);
            marcha = marcha * -1;
            Debug.Log("Velocidad=" + RotationSpeed);
        }

        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("He llegado");
            MoveSpeed = 0;
            RotationSpeed = 0;
        }

    }
    



}

