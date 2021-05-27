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
                                                                                            //если что не удаляй эти пробелы, я по ним ориентируюсь когда и что я сделал
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
    
    new audience{number = "красная площадь", coord = new Vector3 {x = 60.17098F, y = 22.08333F, z = 85.9823F}},
    new audience{number = "251а", coord = new Vector3 {x = 58.93375F, y = 22.08333F, z = 100.1192F}},
    new audience{number = "фудкорт", coord = new Vector3 {x = 83.33484F, y = 22.08333F, z = 91.09123F}},
    new audience{number = "255", coord = new Vector3 {x = 99.28219F, y = 22.08333F, z = 95.28812F}},
    new audience{number = "кафе пиццерия", coord = new Vector3 {x = 99.31924F, y = 22.08333F, z = 95.78936F}},
    new audience{number = "кафе чайная пара", coord = new Vector3 {x = 151.806F, y = 22.08333F, z = 95.38341F}},
    new audience{number = "260", coord = new Vector3 {x = 151.806F, y = 22.08333F, z = 95.38341F}},
    new audience{number = "вход у ноги", coord = new Vector3 {x = 31.16884F, y = 11.11245F, z = 94.04344F}},
    new audience{number = "у ноги", coord = new Vector3 {x = 6.307674F, y = 11.08333F, z = 122.5756F}},
    new audience{number = "нога", coord = new Vector3 {x = 6.307674F, y = 11.08333F, z = 122.5756F}},
    new audience{number = "у фонтана", coord = new Vector3 {x = -2.060562F, y = 11.1902F, z = 181.2598F}},
    new audience{number = "фонтан", coord = new Vector3 {x = -2.060562F, y = 11.1902F, z = 181.2598F}},
    new audience{number = "1 проходная", coord = new Vector3 {x = 139.402F, y = 12.87013F, z = 186.6078F}},
    new audience{number = "беседка", coord = new Vector3 {x = 167.3907F, y = 13.08333F, z = 139.4467F}},
    new audience{number = "читальный зал 3 курса", coord = new Vector3 {x = -35.45171F, y = 34.099F, z = -87.50979F}},
    new audience{number = "345", coord = new Vector3 {x = -36.04493F, y = 34.08334F, z = -86.69722F}},
    new audience{number = "399", coord = new Vector3 {x = -9.974979F, y = 34.08334F, z = -100.7991F}},
    new audience{number = "398", coord = new Vector3 {x = -14.21384F, y = 34.08334F, z = -94.41477F}},
    new audience{number = "398а", coord = new Vector3 {x = -11.21495F, y = 34.08334F, z = -94.13271F}},
    new audience{number = "397а", coord = new Vector3 {x = -9.938984F, y = 34.08334F, z = -99.86913F}},
    new audience{number = "ректор", coord = new Vector3 {x = -9.938984F, y = 34.08334F, z = -99.86913F}},
    new audience{number = "398б", coord = new Vector3 {x = -7.604954F, y = 34.08334F, z = -94.02251F}},
    new audience{number = "помощники ректора", coord = new Vector3 {x = -7.604954F, y = 34.08334F, z = -94.02251F}},
    new audience{number = "393", coord = new Vector3 {x = 22.49477F, y = 34.08334F, z = -101.5954F}},
    new audience{number = "396а", coord = new Vector3 {x = 24.26852F, y = 34.08334F, z = -93.15118F}},
    new audience{number = "391", coord = new Vector3 {x = 39.0864F, y = 34.08334F, z = -101.3109F}},
    new audience{number = "391а", coord = new Vector3 {x = 23.73324F, y = 34.08334F, z = -101.3328F}},
    new audience{number = "391б", coord = new Vector3 {x = 26.13807F, y = 34.08334F, z = -100.2365F}},
    new audience{number = "394", coord = new Vector3 {x = 69.05781F, y = 34.08334F, z = -105.7069F}},
    new audience{number = "392", coord = new Vector3 {x = 85.01264F, y = 34.08334F, z = -105.545F}},
    new audience{number = "390", coord = new Vector3 {x = 98.72775F, y = 34.08334F, z = -106.5099F}},
    new audience{number = "388", coord = new Vector3 {x = 109.4623F, y = 34.08334F, z = -109.6436F}},
    new audience{number = "386", coord = new Vector3 {x = 120.0763F, y = 34.08334F, z = -116.5118F}},
    new audience{number = "384", coord = new Vector3 {x = 124.9438F, y = 34.08334F, z = -122.4947F}},
    new audience{number = "382", coord = new Vector3 {x = 128.2568F, y = 34.08334F, z = -132.7509F}},
    new audience{number = "380", coord = new Vector3 {x = 124.9808F, y = 34.08334F, z = -160.3228F}},
    new audience{number = "389", coord = new Vector3 {x = 134.9472F, y = 34.08334F, z = -160.0565F}},
    new audience{number = "378", coord = new Vector3 {x = 141.9142F, y = 34.08334F, z = -155.7513F}},
    new audience{number = "389а", coord = new Vector3 {x = 141.8041F, y = 34.08334F, z = -160.2279F}},
    new audience{number = "387", coord = new Vector3 {x = 150.4978F, y = 34.08334F, z = -160.6246F}},
    new audience{number = "376", coord = new Vector3 {x = 147.9748F, y = 34.08334F, z = -155.4896F}},
    new audience{number = "372а", coord = new Vector3 {x = 155.9156F, y = 34.08334F, z = -155.8815F}},
    new audience{number = "372", coord = new Vector3 {x = 164.0235F, y = 34.08334F, z = -156.0993F}},
    new audience{number = "383", coord = new Vector3 {x = 165.0196F, y = 34.08334F, z = -160.5314F}},
    new audience{number = "381а", coord = new Vector3 {x = 171.9809F, y = 34.08334F, z = -160.2213F}},
    new audience{number = "370", coord = new Vector3 {x = 171.8939F, y = 34.08334F, z = -155.7031F}},
    new audience{number = "368", coord = new Vector3 {x = 179.7625F, y = 34.08334F, z = -155.3242F}},
    new audience{number = "379", coord = new Vector3 {x = 179.6475F, y = 34.08334F, z = -160.2492F}},
    new audience{number = "366", coord = new Vector3 {x = 188.5802F, y = 34.08334F, z = -155.9194F}},
    new audience{number = "377", coord = new Vector3 {x = 193.3493F, y = 34.08334F, z = -160.7164F}},
    new audience{number = "375", coord = new Vector3 {x = 200.1292F, y = 34.08334F, z = -160.8442F}},
    new audience{number = "364", coord = new Vector3 {x = 203.5014F, y = 34.08334F, z = -155.3753F}},
    new audience{number = "371", coord = new Vector3 {x = 227.3942F, y = 34.08334F, z = -158.9476F}},
    new audience{number = "364а", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -147.4876F}},
    new audience{number = "369", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -148.7041F}},
    new audience{number = "364б", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -144.8763F}},
    new audience{number = "367", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -140.3049F}},
    new audience{number = "365", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -140.3049F}},
    new audience{number = "363", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -132.4193F}},
    new audience{number = "361", coord = new Vector3 {x = 218.2175F, y = 34.08334F, z = -124.1667F}},
    new audience{number = "359", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -116.3819F}},
    new audience{number = "362", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -111.0992F}},
    new audience{number = "357", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -108.3782F}},
    new audience{number = "360а", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -100.2279F}},
    new audience{number = "360", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -100.2279F}},
    new audience{number = "356", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -81.99257F}},
    new audience{number = "355", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -82.49954F}},
    new audience{number = "354а", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -71.94064F}},
    new audience{number = "354", coord = new Vector3 {x = 215.9768F, y = 34.08334F, z = -63.3186F}},
    new audience{number = "353", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -55.31346F}},
    new audience{number = "353.1", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -55.31346F}},
    new audience{number = "353.2", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -55.31346F}},
    new audience{number = "военно-учетный стол", coord = new Vector3 {x = 218.1626F, y = 34.08334F, z = -56.44324F}},
    new audience{number = "352а", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -53.70281F}},
    new audience{number = "351", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -46.74962F}},
    new audience{number = "352", coord = new Vector3 {x = 215.5902F, y = 34.08334F, z = -45.39789F}},
    new audience{number = "350", coord = new Vector3 {x = 218.4235F, y = 34.08334F, z = -37.98177F}},
    new audience{number = "350а", coord = new Vector3 {x = 212.3306F, y = 34.08334F, z = -34.84794F}},
    new audience{number = "431а", coord = new Vector3 {x = 39.1643F, y = 46.08334F, z = -100.3108F}},
    new audience{number = "431", coord = new Vector3 {x = 30.21379F, y = 46.08334F, z = -101.4007F}},
    new audience{number = "434", coord = new Vector3 {x = 26.4278F, y = 46.08334F, z = -92.61993F}},
    new audience{number = "436", coord = new Vector3 {x = 22.18034F, y = 46.08334F, z = -92.61993F}},
    new audience{number = "433а", coord = new Vector3 {x = 19.69842F, y = 46.08334F, z = -101.4533F}},
    new audience{number = "433", coord = new Vector3 {x = -7.384083F, y = 46.08334F, z = -101.4152F}},
    new audience{number = "438", coord = new Vector3 {x = -8.726048F, y = 46.08334F, z = -93.8428F}},
    new audience{number = "435а", coord = new Vector3 {x = -14.42468F, y = 46.08334F, z = -101.363F}},
    new audience{number = "435", coord = new Vector3 {x = -19.74351F, y = 46.08334F, z = -101.3236F}},
    new audience{number = "437", coord = new Vector3 {x = -26.58757F, y = 46.0862F, z = -101.2358F}},
    new audience{number = "429ю", coord = new Vector3 {x = -57.80292F, y = 46.08334F, z = -104.8928F}},
    new audience{number = "427ю", coord = new Vector3 {x = -70.74661F, y = 46.08334F, z = -105.5668F}},
    new audience{number = "425ю", coord = new Vector3 {x = -84.3438F, y = 46.08334F, z = -105.1958F}},
    new audience{number = "423ю", coord = new Vector3 {x = -94.99538F, y = 46.08334F, z = -108.778F}},
    new audience{number = "421ю", coord = new Vector3 {x = -104.7871F, y = 46.08334F, z = -113.6028F}},
    new audience{number = "419ю", coord = new Vector3 {x = -113.0123F, y = 46.08334F, z = -126.0597F}},
    new audience{number = "417ю", coord = new Vector3 {x = -123.9627F, y = 46.08334F, z = -136.0121F}},
    new audience{number = "417юа", coord = new Vector3 {x = -121.0369F, y = 46.08334F, z = -133.8966F}},
    new audience{number = "426ю", coord = new Vector3 {x = -116.5765F, y = 46.08334F, z = -154.9909F}},
    new audience{number = "424ю", coord = new Vector3 {x = -123.4025F, y = 46.08464F, z = -160.3594F}},
    new audience{number = "415ю", coord = new Vector3 {x = -152.047F, y = 46.08334F, z = -155.6199F}},
    new audience{number = "422ю", coord = new Vector3 {x = -152.0654F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "413ю", coord = new Vector3 {x = -159.8211F, y = 46.08334F, z = -155.6615F}},
    new audience{number = "420ю", coord = new Vector3 {x = -158.9865F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "411ю", coord = new Vector3 {x = -167.8143F, y = 46.08334F, z = -155.6199F}},
    new audience{number = "418ю", coord = new Vector3 {x = -173.0322F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "412юм", coord = new Vector3 {x = -183.8866F, y = 46.08334F, z = -155.6199F}},
    new audience{number = "416ю", coord = new Vector3 {x = -195.3009F, y = 46.08334F, z = -160.249F}},
    new audience{number = "416аю", coord = new Vector3 {x = -202.237F, y = 46.08334F, z = -160.3495F}},
    new audience{number = "414ю", coord = new Vector3 {x = -205.9885F, y = 46.08334F, z = -140.6542F}},
    new audience{number = "409ю", coord = new Vector3 {x = -202.5765F, y = 46.08334F, z = -126.6389F}},
    new audience{number = "407ю", coord = new Vector3 {x = -202.5765F, y = 46.08334F, z = -117.886F}},
    new audience{number = "412ю", coord = new Vector3 {x = -205.4098F, y = 46.08334F, z = -116.1283F}},
    new audience{number = "405ю", coord = new Vector3 {x = -202.5765F, y = 46.08334F, z = -111.1149F}},
    new audience{number = "410ю", coord = new Vector3 {x = -205.4098F, y = 46.08334F, z = -108.2694F}},
    new audience{number = "408ю", coord = new Vector3 {x = -204.7854F, y = 46.13446F, z = -100.7577F}},
    new audience{number = "403ю", coord = new Vector3 {x = -202.6974F, y = 46.74167F, z = -80.46609F}},
    new audience{number = "406ю", coord = new Vector3 {x = -205.4098F, y = 46.08334F, z = -83.8431F}},
    new audience{number = "401аю", coord = new Vector3 {x = -202.7284F, y = 46.08334F, z = -72.19315F}},
    new audience{number = "404ю", coord = new Vector3 {x = -205.4098F, y = 46.08334F, z = -73.46147F}},
    new audience{number = "401ю", coord = new Vector3 {x = -202.6413F, y = 46.08334F, z = -62.79034F}},
    new audience{number = "432", coord = new Vector3 {x = 69.25446F, y = 46.08334F, z = -104.819F}},
    new audience{number = "430", coord = new Vector3 {x = 85.15599F, y = 46.08334F, z = -105.3433F}},
    new audience{number = "428", coord = new Vector3 {x = 98.94466F, y = 46.08334F, z = -106.0655F}},
    new audience{number = "426", coord = new Vector3 {x = 109.9497F, y = 46.08334F, z = -109.2531F}},
    new audience{number = "424", coord = new Vector3 {x = 120.2242F, y = 46.08334F, z = -116.3342F}},
    new audience{number = "422", coord = new Vector3 {x = 124.8465F, y = 46.08334F, z = -123.2866F}},
    new audience{number = "420", coord = new Vector3 {x = 128.214F, y = 46.08334F, z = -133.0969F}},
    new audience{number = "418", coord = new Vector3 {x = 124.9325F, y = 46.08334F, z = -160.0835F}},
    new audience{number = "429", coord = new Vector3 {x = 134.747F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "416", coord = new Vector3 {x = 140.7279F, y = 46.08334F, z = -155.62F}},
    new audience{number = "427", coord = new Vector3 {x = 150.2246F, y = 46.08334F, z = -160.3385F}},
    new audience{number = "416а", coord = new Vector3 {x = 148.4685F, y = 46.08334F, z = -155.6199F}},
    new audience{number = "425", coord = new Vector3 {x = 157.9374F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "414", coord = new Vector3 {x = 156.4182F, y = 46.08334F, z = -155.7209F}},
    new audience{number = "412а", coord = new Vector3 {x = 164.5164F, y = 46.08334F, z = -155.6743F}},
    new audience{number = "412", coord = new Vector3 {x = 172.8859F, y = 46.08334F, z = -155.6199F}},
    new audience{number = "410", coord = new Vector3 {x = 180.5945F, y = 46.08334F, z = -155.6199F}},
    new audience{number = "423", coord = new Vector3 {x = 178.9809F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "423б", coord = new Vector3 {x = 185.9292F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "423а", coord = new Vector3 {x = 193.2663F, y = 46.08334F, z = -160.4533F}},
    new audience{number = "421", coord = new Vector3 {x = 199.7423F, y = 46.08334F, z = -159.7999F}},
    new audience{number = "419", coord = new Vector3 {x = 206.4235F, y = 46.08334F, z = -157.9872F}},
    new audience{number = "417", coord = new Vector3 {x = 214.9107F, y = 46.08334F, z = -149.3788F}},
    new audience{number = "415", coord = new Vector3 {x = 218.4235F, y = 46.08334F, z = -140.4456F}},
    new audience{number = "413", coord = new Vector3 {x = 218.2698F, y = 46.08334F, z = -133.3035F}},
    new audience{number = "411", coord = new Vector3 {x = 218.4815F, y = 46.08334F, z = -124.5764F}},
    new audience{number = "409", coord = new Vector3 {x = 218.8639F, y = 46.08334F, z = -109.0541F}},

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
 //       for (int i = 0; i < audiences.Length; i++)
 //       {
 //           if (starting_kabinet == audiences[i].number)
 //           {
 //               agent.Warp(audiences[i].coord);
 //               Vstart = audiences[i].coord;
 //           }
 //           if (destination_kabinet == audiences[i].number)
 //           {
 //               Vfinish = audiences[i].coord;
    agent.SetDestination(Vfinish);
 //           }
 //       }   это все вроде не нужно, мы это в спавне делаем
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
