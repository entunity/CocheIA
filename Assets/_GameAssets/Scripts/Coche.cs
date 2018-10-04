using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {


    [SerializeField] float velocidad;
    /*
    [SerializeField] float tiempocambio;
    [SerializeField] Transform coche;
    [SerializeField] float DistanciaDeteccion;
    [SerializeField] GameObject target;*/

    /*[SerializeField] float tiemporeset;

    public float timer;
    public bool chocado;*/


    
    public Vector3 direccion;
    public Vector3 angulo;

    // Use this for initialization
    void Start () {
        direccion = Vector3.forward;
        angulo = generarAngulo();
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(direccion * Time.deltaTime * velocidad);
        this.transform.Rotate(angulo * Time.deltaTime);
        //transform.LookAt(target.transform.position);
        /*
        int layerIndex = LayerMask.GetMask("Target");
        bool enSuelo = false;
        enSuelo = Physics.CheckSphere(
            coche.position,
            DistanciaDeteccion,
            layerIndex);


        if (enSuelo == true)
        {
            this.transform.Translate((target.transform.position.x-this.transform.position.x) * Time.deltaTime * velocidad,0,
                (target.transform.position.z - this.transform.position.z) * Time.deltaTime * velocidad);
                transform.LookAt(target.transform.position);
        }
        else
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
            
            timer += Time.deltaTime;
            if (timer > tiempocambio)
            {
                //direccion = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
                transform.eulerAngles = (new Vector3(0, Random.Range(-30, 31), 0));
                timer = 0;
            }
        }*/
        /*
        if (chocado) {
            timer += Time.deltaTime;
            transform.Rotate (direccion);
        }
        if (timer > tiemporeset) {
            chocado = false;
            direccion = new Vector3(0, 0, 0);
            timer = 0;
        }
*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Muros"){
            if (direccion == Vector3.forward)
                {
                    direccion = Vector3.back;
                    angulo = generarAngulo();
                } else {
                    direccion = Vector3.forward;
                    angulo = generarAngulo();
                }
        }
        /*
        if (collision.gameObject.tag == "Muros"&&direccion==new Vector3(0,0,0)) {
            chocado = true;
            direccion= new Vector3(0, Random.Range(-30, 31), 0);

            //transform.eulerAngles = (new Vector3(0, Random.Range(-30, 31), 0));
        }
        */
        
        

        }

    private Vector3 generarAngulo()
    {

        return new Vector3(0, Random.Range(-45, 46), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("He chocado en el seg: "+Time.time);
        }
    }
}
