using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


  struct audience {
        public string number;
        public UnityEngine.Vector3 coord;
    };

public class Move : MonoBehaviour
{
    public NavMeshAgent agent;
    public string starting_kabinet;
    public string destination_kabinet;
    public Vector3 Vstart;
    public Vector3 Vfinish;

    LineRenderer lineRenderer;

    audience[] audiences =
    {
    new audience{number = "341г", coord = new Vector3 {x = 42.9382F, y = 33.88272F, z = 88.256F}},
    new audience{number = "главный вход", coord = new Vector3 {x = 10.63F, y = 9.62F, z = -120.13F}},
    new audience{number = "кафедра материаловедение", coord = new Vector3 {x = 42.9382F, y = 33.88272F, z = 88.256F}},
    new audience{number = "341", coord = new Vector3 {x = 48.086F, y = 33.324F, z = 89.746F}},
//    new audience{number = "203???", coord = new Vector3 {x = 38.29F, y = 21.69F, z = 70.06F}}, //хзхз там как будто две 223
    new audience{number = "201а", coord = new Vector3 {x = 44.2F, y = 21.76F, z = 52.77F}},
    new audience{number = "223", coord = new Vector3 {x = 49.239F, y = 22.13398F, z = 32.989F}},
    new audience{number = "299ав", coord = new Vector3 {x = 30.73F, y = 21.49F, z = -100.03F}},
    new audience{number = "294в", coord = new Vector3 {x = 30.73F, y = 21.49F, z = -93.68F}},
    new audience{number = "294б", coord = new Vector3 {x = 28.46F, y = 21.49F, z = -93.68F}},
    new audience{number = "299б", coord = new Vector3 {x = 27.91F, y = 21.49F, z = -100.34F}},
    new audience{number = "297", coord = new Vector3 {x = 24.76F, y = 21.49F, z = -100.34F}}, // проблема
    new audience{number = "297а", coord = new Vector3 {x = -9.8F, y = 21.49F, z = -100.34F}},
    new audience{number = "294г", coord = new Vector3 {x = -14.7F, y = 21.49F, z = -95F}},
    new audience{number = "297б", coord = new Vector3 {x = -12.51F, y = 21.49F, z = -100.34F}},
    new audience{number = "297в", coord = new Vector3 {x = -17.4F, y = 21.49F, z = -100.34F}},
    new audience{number = "298", coord = new Vector3 {x = -17.4F, y = 21.49F, z = -94.63F}},
    new audience{number = "актовый зал", coord = new Vector3 {x = 6.12F, y = 21.56F, z = 70.23F}},
    new audience{number = "227", coord = new Vector3 {x = 6.12F, y = 21.56F, z = 70.23F}},
    new audience{number = "241а", coord = new Vector3 {x = -26.2F, y = 21.68F, z = 69.26F}},
    new audience{number = "241", coord = new Vector3 {x = -32.32F, y = 21.68F, z = 69.26F}},
    new audience{number = "246", coord = new Vector3 {x = -26.2F, y = 21.68F, z = 59.28F}},
    new audience{number = "243", coord = new Vector3 {x = -31.88F, y = 21.68F, z = 61.81F}},
    new audience{number = "247", coord = new Vector3 {x = -31.88F, y = 21.68F, z = 57.47F}},
    new audience{number = "248", coord = new Vector3 {x = -31.88F, y = 21.68F, z = 52.3F}},
    new audience{number = "296а", coord = new Vector3 {x = -36.19F, y = 21.76F, z = -87.5F}},
    new audience{number = "296", coord = new Vector3 {x = -36.19F, y = 21.76F, z = -101.15F}},
    new audience{number = "190", coord = new Vector3 {x = 20.33F, y = 9.58F, z = -95.08F}},
    new audience{number = "187", coord = new Vector3 {x = 33.97F, y = 9.58F, z = -100.2F}},
    new audience{number = "186", coord = new Vector3 {x = 26.57F, y = 9.58F, z = -95.08F}},
    new audience{number = "187а", coord = new Vector3 {x = 38.44F, y = 9.58F, z = -100.2F}},
    new audience{number = "187б", coord = new Vector3 {x = 38.44F, y = 9.58F, z = -95.08F}},
    new audience{number = "185", coord = new Vector3 {x = 45.56F, y = 9.58F, z = -100.2F}},
    new audience{number = "195", coord = new Vector3 {x = 45.56F, y = 9.58F, z = -86.47F}},
    new audience{number = "192", coord = new Vector3 {x = -8.3F, y = 9.58F, z = -95.08F}},
    new audience{number = "192а", coord = new Vector3 {x = -16.34F, y = 9.58F, z = -95.08F}},
    new audience{number = "189", coord = new Vector3 {x = -25.93F, y = 9.58F, z = -108.48F}},
    new audience{number = "189а", coord = new Vector3 {x = -29.62F, y = 9.58F, z = -108.48F}},
    new audience{number = "192б", coord = new Vector3 {x = -19.8F, y = 9.58F, z = -94.87F}},
    new audience{number = "194", coord = new Vector3 {x = -29.62F, y = 9.58F, z = -89.04F}},
    new audience{number = "191", coord = new Vector3 {x = -32.78F, y = 9.58F, z = -108.48F}},
    new audience{number = "гардероб", coord = new Vector3 {x = 6.87F, y = 4F, z = -98.55F}},
    new audience{number = "292", coord = new Vector3 {x = 67.32F, y = 21.86F, z = -104.86F}},
    new audience{number = "290", coord = new Vector3 {x = 87.83F, y = 21.63F, z = -104.42F}},
    new audience{number = "288", coord = new Vector3 {x = 101.88F, y = 21.63F, z = -105.79F}},
    new audience{number = "286", coord = new Vector3 {x = 113.72F, y = 21.63F, z = -111.53F}},
    new audience{number = "284", coord = new Vector3 {x = 124.62F, y = 21.63F, z = -121.769F}},
    new audience{number = "299в", coord = new Vector3 {x = 121.93F, y = 21.63F, z = -143.79F}},
    new audience{number = "299б", coord = new Vector3 {x = 121.93F, y = 21.63F, z = -155.75F}},
    new audience{number = "299а", coord = new Vector3 {x = 124.93F, y = 21.63F, z = -160.25F}},
    new audience{number = "299", coord = new Vector3 {x = 150.32F, y = 21.63F, z = -160.25F}},
    new audience{number = "282", coord = new Vector3 {x = 156.361F, y = 21.63F, z = -156.141F}},
    new audience{number = "280", coord = new Vector3 {x = 163.5F, y = 21.63F, z = -156.141F}},
    new audience{number = "296.1", coord = new Vector3 {x = 164.84F, y = 21.63F, z = -160.25F}},
    new audience{number = "293", coord = new Vector3 {x = 172.29F, y = 21.63F, z = -160.25F}},
    new audience{number = "278", coord = new Vector3 {x = 172.29F, y = 21.63F, z = -156.141F}},
    new audience{number = "291", coord = new Vector3 {x = 179.01F, y = 21.63F, z = -160.25F}},
    new audience{number = "296а", coord = new Vector3 {x = 179.01F, y = 21.63F, z = -156.141F}},
    new audience{number = "289", coord = new Vector3 {x = 185.84F, y = 21.63F, z = -160.25F}},
    new audience{number = "276", coord = new Vector3 {x = 188.99F, y = 21.63F, z = -156.14F}},
    new audience{number = "274а", coord = new Vector3 {x = 196.58F, y = 21.63F, z = -156.14F}},
    new audience{number = "272а", coord = new Vector3 {x = 210.82F, y = 21.63F, z = -156.14F}},
    new audience{number = "287", coord = new Vector3 {x = 193.12F, y = 21.63F, z = -160.25F}},
    new audience{number = "285", coord = new Vector3 {x = 200.22F, y = 21.63F, z = -160.25F}},
    new audience{number = "283", coord = new Vector3 {x = 207.02F, y = 21.63F, z = -160.25F}},
    new audience{number = "281", coord = new Vector3 {x = 218.03F, y = 21.63F, z = -158.51F}},
    new audience{number = "279", coord = new Vector3 {x = 217.96F, y = 21.63F, z = -148.51F}},
    new audience{number = "277", coord = new Vector3 {x = 217.96F, y = 21.63F, z = -139.58F}},
    new audience{number = "275", coord = new Vector3 {x = 216.62F, y = 21.63F, z = -130.08F}},
    new audience{number = "кафедра ИУ-4", coord = new Vector3 {x = 216.62F, y = 21.63F, z = -130.08F}},

/*
    new audience{number = "читальный зал 3 курса", coord = new Vector3 {x = -33.57F, y = 45.7F, z = -92.95F}},
    new audience{number = "345", coord = new Vector3 {x = -33.57F, y = 45.7F, z = -92.95F}},
    new audience{number = "339аю", coord = new Vector3 {x = -31.04F, y = 45.7F, z = -107.6F}},
    new audience{number = "339ю", coord = new Vector3 {x = -57.77F, y = 45.7F, z = -106.31F}},
    new audience{number = "337ю", coord = new Vector3 {x = -70.57F, y = 45.7F, z = -106.31F}},
    new audience{number = "335ю", coord = new Vector3 {x = -84.16F, y = 45.7F, z = -106.31F}},
    new audience{number = "333ю", coord = new Vector3 {x = -94.55F, y = 45.7F, z = -109.09F}},
    new audience{number = "331ю", coord = new Vector3 {x = -104.74F, y = 45.7F, z = -113.875F}},
    new audience{number = "329ю", coord = new Vector3 {x = -113.01F, y = 45.7F, z = -126.11F}},
    new audience{number = "327ю", coord = new Vector3 {x = -113.01F, y = 45.7F, z = -128.88F}},
    new audience{number = "325ю", coord = new Vector3 {x = -123.11F, y = 45.7F, z = -136.3F}},
    new audience{number = "336ю", coord = new Vector3 {x = -117.37F, y = 45.7F, z = -155.25F}},
    new audience{number = "330аю", coord = new Vector3 {x = -123.04F, y = 45.7F, z = -160.21F}},
    new audience{number = "330ю", coord = new Vector3 {x = -144.69F, y = 45.7F, z = -160.21F}},
    new audience{number = "328ю", coord = new Vector3 {x = -159.47F, y = 45.7F, z = -160.21F}},
    new audience{number = "320ю", coord = new Vector3 {x = -167.43F, y = 45.7F, z = -160.21F}},
    new audience{number = "318ю", coord = new Vector3 {x = -179.91F, y = 45.7F, z = -160.21F}},
    new audience{number = "316ю", coord = new Vector3 {x = -186.53F, y = 45.7F, z = -160.21F}},
    new audience{number = "323ю", coord = new Vector3 {x = -151.67F, y = 45.7F, z = -155.93F}},
    new audience{number = "321ю", coord = new Vector3 {x = -159.47F, y = 45.7F, z = -155.93F}},
    new audience{number = "319ю", coord = new Vector3 {x = -167.43F, y = 45.7F, z = -155.93F}},
    new audience{number = "317ю", coord = new Vector3 {x = -175.59F, y = 45.7F, z = -155.93F}},
    new audience{number = "315ю", coord = new Vector3 {x = -183.38F, y = 45.7F, z = -155.93F}},
    new audience{number = "313ю", coord = new Vector3 {x = -184.12F, y = 45.7F, z = -155.93F}},
    new audience{number = "311ю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -126.58F}},
    new audience{number = "309ю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -116.82F}},
    new audience{number = "307ю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -108.74F}},
    new audience{number = "305ю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -100.619F}},
    new audience{number = "303аю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -80.84F}},
    new audience{number = "303ю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -72.23F}},
    new audience{number = "301ю", coord = new Vector3 {x = -202.87F, y = 45.7F, z = -63.41F}},
    new audience{number = "312ю", coord = new Vector3 {x = -205.35F, y = 45.7F, z = -116.82F}},
    new audience{number = "310ю", coord = new Vector3 {x = -205.35F, y = 45.7F, z = -108.74F}},
    new audience{number = "308ю", coord = new Vector3 {x = -205.35F, y = 45.7F, z = -100.619F}},
    new audience{number = "306ю", coord = new Vector3 {x = -205.35F, y = 45.7F, z = -92.256F}},
    new audience{number = "304ю", coord = new Vector3 {x = -205.35F, y = 45.7F, z = -83.45F}},
    new audience{number = "302ю", coord = new Vector3 {x = -205.35F, y = 45.7F, z = -65.43F}},
    new audience{number = "300ю", coord = new Vector3 {x = -204.12F, y = 45.7F, z = -52.15F}},
    new audience{number = "399", coord = new Vector3 {x = -26.72F, y = 45.7F, z = -101.19F}},
    new audience{number = "398", coord = new Vector3 {x = -13.52F, y = 45.7F, z = -94.11F}},
    new audience{number = "398а", coord = new Vector3 {x = -11.61F, y = 45.7F, z = -94.11F}},
    new audience{number = "398б", coord = new Vector3 {x = -10.61F, y = 45.7F, z = -94.11F}},
    new audience{number = "398", coord = new Vector3 {x = -8.61F, y = 45.7F, z = -94.11F}},
    new audience{number = "396а", coord = new Vector3 {x = 19.36F, y = 45.7F, z = -94.11F}},
    new audience{number = "396б", coord = new Vector3 {x = 22.77F, y = 45.7F, z = -94.11F}},
    new audience{number = "394а", coord = new Vector3 {x = 25.41F, y = 45.7F, z = -94.11F}},
    new audience{number = "397а", coord = new Vector3 {x = -17.4F, y = 45.7F, z = -101.25F}},
    new audience{number = "397", coord = new Vector3 {x = -10.45F, y = 45.7F, z = -101.25F}},
    new audience{number = "393", coord = new Vector3 {x = 19.36F, y = 45.7F, z = -101.25F}},
    new audience{number = "391б", coord = new Vector3 {x = 22.77F, y = 45.7F, z = -101.25F}},
    new audience{number = "391а", coord = new Vector3 {x = 25.41F, y = 45.7F, z = -101.25F}},
    new audience{number = "391", coord = new Vector3 {x = 29.04F, y = 45.7F, z = -101.25F}},
    new audience{number = "395", coord = new Vector3 {x = 45.37F, y = 33.63F, z = -87.57F}},
жесский проеб с этажом ходил по четвертому этажу записывал как 3*/

    new audience{number = "читальный зал 3 курса", coord = new Vector3 {x = -33.57F, y = 33.63F, z = -92.95F}}, // я просто понизил y координату 
    new audience{number = "345", coord = new Vector3 {x = -33.57F, y = 33.63F, z = -92.95F}},                   // все что дальше может быть не правдой
    new audience{number = "339аю", coord = new Vector3 {x = -31.04F, y = 33.63F, z = -107.6F}},
    new audience{number = "339ю", coord = new Vector3 {x = -57.77F, y = 33.63F, z = -106.31F}},
    new audience{number = "337ю", coord = new Vector3 {x = -70.57F, y = 33.63F, z = -106.31F}},
    new audience{number = "335ю", coord = new Vector3 {x = -84.16F, y = 33.63F, z = -106.31F}},
    new audience{number = "333ю", coord = new Vector3 {x = -94.55F, y = 33.63F, z = -109.09F}},
    new audience{number = "331ю", coord = new Vector3 {x = -104.74F, y = 33.63F, z = -113.875F}},
    new audience{number = "329ю", coord = new Vector3 {x = -113.01F, y = 33.63F, z = -126.11F}},
    new audience{number = "327ю", coord = new Vector3 {x = -113.01F, y = 33.63F, z = -128.88F}},
    new audience{number = "325ю", coord = new Vector3 {x = -123.11F, y = 33.63F, z = -136.3F}},
    new audience{number = "336ю", coord = new Vector3 {x = -117.37F, y = 33.63F, z = -155.25F}},
    new audience{number = "330аю", coord = new Vector3 {x = -123.04F, y = 33.63F, z = -160.21F}},
    new audience{number = "330ю", coord = new Vector3 {x = -144.69F, y = 33.63F, z = -160.21F}},
    new audience{number = "328ю", coord = new Vector3 {x = -159.47F, y = 33.63F, z = -160.21F}},
    new audience{number = "320ю", coord = new Vector3 {x = -167.43F, y = 33.63F, z = -160.21F}},
    new audience{number = "318ю", coord = new Vector3 {x = -179.91F, y = 33.63F, z = -160.21F}},
    new audience{number = "316ю", coord = new Vector3 {x = -186.53F, y = 33.63F, z = -160.21F}},
    new audience{number = "323ю", coord = new Vector3 {x = -151.67F, y = 33.63F, z = -155.93F}},
    new audience{number = "321ю", coord = new Vector3 {x = -159.47F, y = 33.63F, z = -155.93F}},
    new audience{number = "319ю", coord = new Vector3 {x = -167.43F, y = 33.63F, z = -155.93F}},
    new audience{number = "317ю", coord = new Vector3 {x = -175.59F, y = 33.63F, z = -155.93F}},
    new audience{number = "315ю", coord = new Vector3 {x = -183.38F, y = 33.63F, z = -155.93F}},
    new audience{number = "313ю", coord = new Vector3 {x = -184.12F, y = 33.63F, z = -155.93F}},
    new audience{number = "311ю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -126.58F}},
    new audience{number = "309ю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -116.82F}},
    new audience{number = "307ю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -108.74F}},
    new audience{number = "305ю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -100.619F}},
    new audience{number = "303аю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -80.84F}},
    new audience{number = "303ю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -72.23F}},
    new audience{number = "301ю", coord = new Vector3 {x = -202.87F, y = 33.63F, z = -63.41F}},
    new audience{number = "312ю", coord = new Vector3 {x = -205.35F, y = 33.63F, z = -116.82F}},
    new audience{number = "310ю", coord = new Vector3 {x = -205.35F, y = 33.63F, z = -108.74F}},
    new audience{number = "308ю", coord = new Vector3 {x = -205.35F, y = 33.63F, z = -100.619F}},
    new audience{number = "306ю", coord = new Vector3 {x = -205.35F, y = 33.63F, z = -92.256F}},
    new audience{number = "304ю", coord = new Vector3 {x = -205.35F, y = 33.63F, z = -83.45F}},
    new audience{number = "302ю", coord = new Vector3 {x = -205.35F, y = 33.63F, z = -65.43F}},
    new audience{number = "300ю", coord = new Vector3 {x = -204.12F, y = 33.63F, z = -52.15F}},
    new audience{number = "399", coord = new Vector3 {x = -26.72F, y = 33.63F, z = -101.19F}},
    new audience{number = "398", coord = new Vector3 {x = -13.52F, y = 33.63F, z = -94.11F}},
    new audience{number = "398а", coord = new Vector3 {x = -11.61F, y = 33.63F, z = -94.11F}},
    new audience{number = "398б", coord = new Vector3 {x = -10.61F, y = 33.63F, z = -94.11F}},
    new audience{number = "398", coord = new Vector3 {x = -8.61F, y = 33.63F, z = -94.11F}},
    new audience{number = "396а", coord = new Vector3 {x = 19.36F, y = 33.63F, z = -94.11F}},
    new audience{number = "396б", coord = new Vector3 {x = 22.77F, y = 33.63F, z = -94.11F}},
    new audience{number = "394а", coord = new Vector3 {x = 25.41F, y = 33.63F, z = -94.11F}},
    new audience{number = "397а", coord = new Vector3 {x = -17.4F, y = 33.63F, z = -101.25F}},
    new audience{number = "397", coord = new Vector3 {x = -10.45F, y = 33.63F, z = -101.25F}},
    new audience{number = "393", coord = new Vector3 {x = 19.36F, y = 33.63F, z = -101.25F}},
    new audience{number = "391б", coord = new Vector3 {x = 22.77F, y = 33.63F, z = -101.25F}},
    new audience{number = "391а", coord = new Vector3 {x = 25.41F, y = 33.63F, z = -101.25F}},
    new audience{number = "391", coord = new Vector3 {x = 29.04F, y = 33.63F, z = -101.25F}},
    new audience{number = "327", coord = new Vector3 {x = 207.804F, y = 33.63F, z = 111.2F}},

    new audience{number = "технопарк", coord = new Vector3 {x = 45.37F, y = 33.63F, z = -87.57F}},  // отсюда уже правда
    new audience{number = "394 правое крыло коорд не введены", coord = new Vector3 {x = 46.73F, y = 33.63F, z = -87.57F}},


};

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = agent.path.corners.Length;
        lineRenderer.SetPositions(agent.path.corners);
    }

    public void Spawn()
    {
        for (int i = 0; i < audiences.Length; i++)
        {
            if (starting_kabinet == audiences[i].number)
            {
                agent.Warp(audiences[i].coord);
                Vstart = audiences[i].coord;
            }

            if (destination_kabinet == audiences[i].number)
            {
                Vfinish = audiences[i].coord;
            }
        }
    }




    public void SetDestinationCabinet(string finish)
    {
        destination_kabinet = finish;
    }

    public void SetSpawnCabinet(string start)
    {
        starting_kabinet = start;
    }

    public void MoveToAudience()
    {
        Spawn();
        for (int i = 0; i < audiences.Length; i++)
        {
            if (destination_kabinet == audiences[i].number)
            {
                agent.SetDestination(audiences[i].coord);
                Vfinish = audiences[i].coord;
            }
            if (starting_kabinet == audiences[i].number)
            {
                agent.Warp(audiences[i].coord);
                Vstart = audiences[i].coord;
            }
        }
    }


    public void MoveToFinish()
    {
        agent.SetDestination(Vfinish);
    }

    public void MovePouse()
    {
        agent.isStopped = true;
    }

    public void MoveResume()
    {
        agent.isStopped = false;
    }

    public void MoveToStart()
    {
        agent.SetDestination(Vstart);
    }
}
