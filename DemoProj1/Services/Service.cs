using Confluent.Kafka;
using DemoProj1.Models;
using DemoProj1.Repositry;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoProj1.Services
{
    public class Service : IStudentServices //IHostedService
    {
        private readonly IStudent _stud;
        // private readonly IProducer<Null, string> _studproducer;
        //private ProducerConfig _config;

      /*  public Service(ProducerConfig config,)
        {
            _config = config;
        }
      */
        public Service(IStudent stud)
        {
            _stud = stud;
        }

       


        public  IEnumerable<studentDetails1> AddStudentAsync(studentDetails1 student)
        {
           var response = _stud.Add(student);
            //  var response = await _httpClient.SendAsync(Request);
            //IEnumerable<studentDetails1> res

            // = JsonSerializer.Deserialize<IEnumerable<studentDetails1>>(response);
            // res = JsonConvert.DeserializeObject<IEnumerable<studentDetails1>>(result);
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"




            };


            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    producer.ProduceAsync("studentTopic", new Message<Null, string>
                    {
                        Value="Producer sending message"

                    });
                }

                catch(Exception e)
                {

                }


            }




            //  var userDataString = JsonConvert.SerializeObject(response);
            // var result = JsonConvert.DeserializeObject<studentDetails1>(userDataString);
            // Console.WriteLine(userDataString);
            //  string jsonString = System.Text.Json.JsonSerializer.Serialize(response);
            // var result = JsonConvert.DeserializeObject<StringConversion>(userDataString);

           /* string mess = "producer";

            _studproducer.ProduceAsync("studentTopic", new Message<Null, string>
              {
                  Value = mess
            });*/

            return response;
        }

        public int DeleteStudent(int key)
        {
           return _stud.Delete(key);
        }

        public int EditStudent(studentDetails1 student)
        {
            return _stud.Edit(student);
        }

        public IEnumerable<studentDetails1> GetStudent()
        {
             return _stud.Read();
        }

        public IEnumerable<studentDetails1> GetStudentByKey(int key)
        {
            return _stud.Readkey(key);
        }

        /*public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _studproducer.ProduceAsync("studentTopic", new Message<Null, string>()
            {
                Value = "This code is the StudentDetail producer. It calls the api and hits kafka"
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _studproducer?.Dispose();
            return Task.CompletedTask;
        }*/
    }

}
