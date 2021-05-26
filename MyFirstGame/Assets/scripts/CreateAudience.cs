using UnityEngine;
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
     Vector3 movement;
     
     if (Input.GetAxis("Horizontal") > 0)
     {
     transform.Rotate(new Vector3(0f, 2f, 0f));
     }
    if(Input.GetAxis("Horizontal") < 0)
     {
     transform.Rotate(new Vector3(0f, -2f, 0f));
     }
     
     if(Input.GetAxis("Vertical") > 0)
     {
     movement = new Vector3(0f, 0f, 0.5f);
     Vector3 moveDestination = transform.position + (transform.forward)/4;
     agent.destination = moveDestination;
     }
    if(Input.GetAxis("Vertical") < 0)
     {
     movement = new Vector3(0f, 0f, -0.5f);
     Vector3 moveDestination = transform.position - (transform.forward)/4;
     agent.destination = moveDestination;
     }  
    }

    public void write() 
    {
        string filePath = "E://new_audiences.txt";
        FileStream fileStream = File.Open(filePath, FileMode.Append);  // открываем файл (не стираем содержимое файла)
        StreamWriter output = new StreamWriter(fileStream);   // получаем поток

        CurrentPosition = agent.transform.position;
        string text = $"new audience{{number = \"{audienceNumber}\", coord = new Vector3 {{x = {CurrentPosition.x}F, y = {CurrentPosition.y}F, z = {CurrentPosition.z}}}}},\n";
        
        output.Write(text);       // записываем текст в поток
        output.Close();           // закрываем поток
    
    }
    public void SetAudienceNumber(string nubmer)
    {
        audienceNumber = nubmer;
    }
}
