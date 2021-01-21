using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SaintSender.Core.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaintSender.Core.Services
{
    public class SerializeEmailModelService
    {
        public SerializeEmailModelService() { }

        public string SerializeEmailList(List<EmailModel> emailList)
        {
            StringBuilder str = new StringBuilder();
            foreach(var email in emailList)
            {
                str.Append(JsonSerializer.Serialize(email) + "\n");
            }
            return Serialize(str.ToString());
        }


        public void DeleteSearchFile(string output = "serializedEmails.json")
        {
            File.Delete(output);
        }

        public string Serialize(string emailModel,string output = "serializedEmails.json")
        { 
        FileStream fs;
            if (!File.Exists(output))
            {
                try
                {
                    File.Delete(output);
                    fs = new FileStream(output, FileMode.Create);
                    fs.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("can't create");
                    return "Can't Save backup";
                }
            }
            File.WriteAllText("serializedEmails.json", emailModel);
            return "Success saved backup!";
        }

        public List<EmailModel> DeserializeEmails(string fileName = "serializedEmails.json")
        {
                List<EmailModel> emailList = new List<EmailModel>();
            EmailModel email;
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (var json in lines)
                {
                    email = Deserialize(json);
                    emailList.Add(email);
                }
            }
            return emailList;
        }
        public EmailModel Deserialize(string json)
        {
            EmailModel email;
            email = JsonSerializer.Deserialize<EmailModel>(json);
            return email;
        }

    }
}
