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
    public class SerializeEmailModel
    {
        public SerializeEmailModel() { }

        public void SerializeEmailList(List<EmailModel> emailList)
        {
            StringBuilder str = new StringBuilder();
            foreach(var email in emailList)
            {
                str.Append(JsonSerializer.Serialize(email) + "\n");
            }
            Serialize(str.ToString());
        }

        public void Serialize(string emailModel,string output = "serializedEmails.json")
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
                }
            }
            File.WriteAllText("serializedEmails.json", emailModel);
        }

        public List<EmailModel> DeserializeEmails(string fileName = "serializedEmails.json")
        {
            List<EmailModel> emailList = new List<EmailModel>();
            EmailModel email;
            string[] lines = File.ReadAllLines(fileName);

            foreach(var json in lines)
            {
                email = Deserialize(json);
                emailList.Add(email);
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
