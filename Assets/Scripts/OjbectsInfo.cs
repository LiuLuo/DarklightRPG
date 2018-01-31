using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class OjbectsInfo : MonoBehaviour
{

    // Use this for initialization
    public static OjbectsInfo _instance;
    public static OjbectsInfo GetInstance()
    {
        if (_instance == null)
        {
            _instance = new OjbectsInfo();
        }
        return _instance;
    }
    private void Start()
    {
        string filePath = Application.streamingAssetsPath + "/OjbectsInfo.CSV";


   
        Dictionary<int, OjbectInfo> csvDataDic1 =LoadCsv<OjbectInfo>(filePath);
       
        OjbectInfo obj1 = csvDataDic1[1];
        print(obj1.Name);
    }

    public enum ObjectType
    {
        Drug,
        EQuip,
        Mat
    }

    public class OjbectInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }
        public int Type { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hpmax { get; set; }
        public int Mpmax { get; set; }
        public int Price { get; set; }
        public int Sell { get; set; }

    }


    /// <summary>
    /// 读取CSV文件数据（利用反射）
    /// </summary>
    /// <typeparam name="CsvData">CSV数据对象的类型</typeparam>
    /// <param name="csvFilePath">CSV文件路径</param>
    /// <param name="csvDatas">用于缓存数据的字典</param>
    /// <returns>CSV文件所有行内容的数据对象</returns>
    public Dictionary<int, T_CsvData> LoadCsv<T_CsvData>(string csvFilePath)
    {
        #region
        /* CSV文件路径 */
        // string filePath = Application.streamingAssetsPath + "/T_CsvData.csv";

        ///* 读取CSV文件，一行行读取 */
        //string[] fileData = File.ReadAllLines(filePath);

        ///* 把CSV文件按行存放，每一行的ID作为key值，内容作为value值 */
        //Dictionary<int, T_CsvData> csvDataDic = new Dictionary<int, T_CsvData>();

        ///* CSV文件的第一行为Key字段，先读取key字段 */
        //string[] keys = fileData[0].Split(',');

        ///* 第二行开始是数据 */
        //for (int i = 1; i < fileData.Length; i++)
        //{
        //    /* 每一行的内容都是逗号分隔，读取每一列的值 */
        //    string[] lineData = fileData[i].Split(',');
        //    /* T_CsvData类与T_CsvData.csv文件的key字段一一对应，用于保存每一行的数据内容 */
        //    T_CsvData T_CsvData = new T_CsvData();
        //    for (int j = 0; j < lineData.Length; j++)
        //    {
        //        if (keys[j] == "Id")
        //        {
        //            print(lineData[j]);
        //            T_CsvData.Id = int.Parse(lineData[j]);
        //            print(T_CsvData.Id);
        //        }
        //        else if (keys[j] == "Name")
        //        {
        //            print(lineData[j]);
        //            T_CsvData.Name = lineData[j];
        //        }
        //    }

        //    /* 保存每一行ID和数据对象的关系 */
        //    csvDataDic[i] = T_CsvData;
        //}

        ///* 测试读取ID为1的数据 */
        //Debug.Log("11");
        //T_CsvData T_CsvData1 = csvDataDic[1];
        //Debug.Log("Id=" + T_CsvData1.Id + "，Name=" + T_CsvData1.Name);
        //Debug.Log("11");
        #endregion


        /* 把CSV文件按行存放，每一行的ID作为key值，内容作为value值 */
        Dictionary<int, T_CsvData> csvDataDic = new Dictionary<int, T_CsvData>();

        /* 从CSV文件读取数据 */
        Dictionary<string, Dictionary<string, string>> datasDic = LoadCsvFile(csvFilePath);

        /* 遍历每一行数据 */
        foreach (string ID in datasDic.Keys)
        {
            /* CSV的一行数据 */
            Dictionary<string, string> datas = datasDic[ID];

            /* 读取Csv数据对象的属性 */
            PropertyInfo[] props = typeof(T_CsvData).GetProperties();

            /* 使用反射，将CSV文件的数据赋值给CSV数据对象的相应字段，要求CSV文件的字段名和CSV数据对象的字段名完全相同 */
            T_CsvData obj = Activator.CreateInstance<T_CsvData>();
            foreach (PropertyInfo pi in props)
            {
                pi.SetValue(obj, Convert.ChangeType(datas[pi.Name], pi.PropertyType), null);
            }

            /* 按ID-数据的形式存储 */
            csvDataDic[int.Parse(ID) - 10000] = obj;
        }
        return csvDataDic;

    }


    /// <summary>
    /// 读取CSV文件
    /// 结果保存到字典集合，以ID作为Key值，对应每一行的数据，每一行的数据也用字典集合保存。
    /// </summary>
    /// <param name="filePath">CSV文件地址</param>
    /// <returns>返回Dictionary</returns>
    public static Dictionary<string, Dictionary<string, string>> LoadCsvFile(string filePath)

    {
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
        string[] fileData = File.ReadAllLines(filePath);

        /* CSV文件的第一行为Key字段，第二行开始是数据。第一个字段一定是ID。 */
        string[] keys = fileData[0].Split(',');

        for (int i = 1; i < fileData.Length; i++)
        {
            string[] line = fileData[i].Split(',');

            /* 以ID为key值，创建一个新的集合，用于保存当前行的数据 */
            string ID = line[0];
            result[ID] = new Dictionary<string, string>();

            for (int j = 0; j < line.Length; j++)
            {
                /* 每一行的数据存储规则：Key字段-Value值 */
                result[ID][keys[j]] = line[j];
            }
        }
        return result;
    }


}
