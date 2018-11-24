using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace AwsConsoleAppdYNAMOdb
{
    class Program
    {
        private static AmazonDynamoDBClient client;

        public static void Main(string[] args)
        {
            try
            {
                AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();

                config.ServiceURL = "https://dynamodb.eu-west-2.amazonaws.com";

                client = new AmazonDynamoDBClient(config);

                UploadData();

                Console.WriteLine("Data uploaded... To continue, press Enter");
            }
            catch (AmazonDynamoDBExeption e) { Console.WriteLine("DynamoDB Message:" + e.Message); }
            catch (AmazonServiceExeption e) { Console.WriteLine("Service Exeption:" + e.Message); }
            catch (Exception e) { Console.WriteLine("General Exception:" + e.Message); }
            Console.ReadLine();
        }
        private static void UploadData()
        {
            Table sampleTable = Table.LoadTable(client, "SampleData");

            var d1 = new Document();

            d1["id"] = "1";
            d1["Field1"] = "Field";
            d1["Field2"] = "FieldDDD";

            var d2 = new Document();

            d2["id"] = "2";
            d2["Field1"] = "Field2";
            d2["Field2"] = "FieldDDD2";
        }
    }
}
