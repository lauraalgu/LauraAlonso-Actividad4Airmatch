using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraft : MonoBehaviour {

    public float speed; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.forward * speed);

        //Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right);
        }

        //Motion Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left);
        }

        //Up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.up);
        }

        //Down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.down);
        }

        //Space key for shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Creamos un nuevo gameobject Missile a partir de un prefab (planos de Construccion)
            GameObject newMissil = GameObject.Instantiate(Resources.Load("Bullets/Missil") as GameObject);

            //Buscamos el Pivote del disparo
            GameObject ShootPivot = GameObject.Find("aircraft/ShootPivot");

            //Hacemos que el misil sea hijo de Shoot pivot
            newMissil.transform.SetParent(ShootPivot.transform);

            //Movemos el misil hacia donde esta el shoot pvot, es decir, debajo del ala
            newMissil.transform.localPosition = Vector3.zero;

            //Hacemos que los misiles ya no sean hijos del avion
            newMissil.transform.SetParent(null);

            newMissil.transform.Translate(Vector3.forward * speed);
        }

    } //end update
}
