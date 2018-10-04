using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {


    [SerializeField] float velocidad;
    [SerializeField] float tiempoCambio;


    private Vector3 direccion;
    private Vector3 angulo;
    public float timer;
    // Use this for initialization
    void Start () {
        direccion = Vector3.forward;
        generarAngulo();
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        if (timer > tiempoCambio)
        {
            timer = 0;
            generarAngulo();

        }
        
        this.transform.Translate(direccion * Time.deltaTime * velocidad);
        this.transform.Rotate(angulo * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        timer = 0;
        if (collision.gameObject.tag == "Pared"){
            if (direccion == Vector3.forward)
                {
                    direccion = Vector3.back;
                    generarAngulo();
                } else {
                    direccion = Vector3.forward;
                    generarAngulo();
                }
        }
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("Enrique ha encontrado el objetivo en el seg: " + Time.time);
        }

    }

    private void generarAngulo()
    {

        this.angulo= new Vector3(0, Random.Range(-45, 46), 0);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("Enrique ha encontrado el objetivo en el seg: "+Time.time);
        }
    }*/
}
