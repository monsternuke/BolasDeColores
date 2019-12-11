using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolitas : MonoBehaviour
{
    private GameObject Sphere;
    public bool checkbox; //booleano 
    int num;




    void Start()
    {
        StartCoroutine(SphereColors());
    }

    public IEnumerator SphereColors() { 
        Color[] color = new Color[6]; //Cambio aleatorio entre 6 colores
        num = Random.Range(3, 12);      //rango de filas y columnas aleatorias
        Color colorObject1 = Color.blue;
        Color colorObject2 = Color.red;

        color[0] = Color.yellow;
        color[1] = Color.blue;
        color[2] = Color.red;
        color[3] = Color.green;         //todos los colores con los que las bolas pueden salir 
        color[4] = Color.cyan;
        color[5] = Color.grey;
        

        if (checkbox == true)
        {

            for (int x = 0; x < num; x++)
            {
                GameObject objeto1 = null;
                for (int y = 0; y < num; y++)
                {
                    GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Sphere.GetComponent<Renderer>().material.color = color[Random.Range(0,color.Length)];// color aleatorio dado anteriormente
                    Sphere.transform.position =new Vector3(y, x, 0);//generacion 
                    Comparator comparar = new Comparator();
                    if (objeto1 != null)
                    {
                        colorObject2 = Sphere.GetComponent<Renderer>().material.color;
                        colorObject1 = objeto1.GetComponent<Renderer>().material.color;
                        Sphere.GetComponent<Renderer>().material.color= comparar.actualColor(colorObject1,colorObject2); //compara el color de la bola generada
                        objeto1.GetComponent<Renderer>().material.color = comparar.lastColor(colorObject1, colorObject2);//compara el color de la bola anterior
                    }

                    yield return new WaitForSeconds(0.5f);
                    objeto1 = Sphere;
                }
            }
        }
    }
   
    void Update()
    {

    }
}
public class Comparator //Instancia aparte del creador de bolas que compara las esferas y ve si son del mismo color para cambiarlas a negro como corresponde

{

    public Color colorV = Color.black;
    
    public Color lastColor(Color ant, Color prev)
    {
        if (ant == prev)
        {
            ant = colorV;
        }
        return ant;
  
    }
   public Color actualColor(Color ant, Color prev)
    {
        if (ant == prev)
        {
            prev= colorV;
        }
        return prev;
    }
       
        void Update()
    {

    }
}