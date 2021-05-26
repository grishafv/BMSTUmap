using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.AI;

public class CreateAudience : MonoBehaviour
{
public NavMeshAgent agent;
string audienceNumber;
Vector3 CurrentPosition;



    // Start is called before the first frame update
    void Start()
    {
        agent.GetComponent<NavMeshAgent>();

        

    }
    // Update is called once per frame
    void Update()
    {
    float horInput = Input.GetAxis("Horizontal");
     float verInput = Input.GetAxis("Vertical");
     Vector3 movement;
     if(Input.GetAxis("Horizontal") > 0)
     {
     movement = new Vector3(0.5f, 0f, 0f);
     Vector3 moveDestination = transform.position + movement;
     agent.destination = moveDestination;
     }
    if(Input.GetAxis("Horizontal") < 0)
     {
     movement = new Vector3(-0.5f, 0f, 0f);
     Vector3 moveDestination = transform.position + movement;
     agent.destination = moveDestination;
     }
     
     if(Input.GetAxis("Vertical") > 0)
     {
     movement = new Vector3(0f, 0f, 0.5f);
     Vector3 moveDestination = transform.position + movement;
     agent.destination = moveDestination;
     }
    if(Input.GetAxis("Vertical") < 0)
     {
     movement = new Vector3(0f, 0f, -0.5f);
     Vector3 moveDestination = transform.position + movement;
     agent.destination = moveDestination;
     }  
    }

    public void write() 
    {
        string filePath = "E://1.txt";
           //    new audience{number = "341г", coord = new Vector3 {x = 42.9382F, y = 33.88272F, z = 88.256F}},
               // текст для записи в файл
        CurrentPosition = agent.transform.position;
        string text = $"new audience{{number = \"{audienceNumber}\", coord = new Vector3 {{x = {CurrentPosition.x}F, y = {CurrentPosition.y}F, z = {CurrentPosition.z}}}}},\n";
//        string text = "hello";

               // открываем файл (стираем содержимое файла)
               FileStream fileStream = File.Open(filePath, FileMode.Append);

               // получаем поток
               StreamWriter output = new StreamWriter(fileStream);

               // записываем текст в поток
               output.Write(text);

               // закрываем поток
               output.Close();
    
    }
    public void SetAudienceNumber(string nubmer)
    {
        audienceNumber = nubmer;
    }
}
