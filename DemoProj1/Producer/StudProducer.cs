using Confluent.Kafka;
using DemoProj1.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProj1.Producer
{
    public class StudProducer : IHostedService
    {
        private readonly IStudentServices _serv;

        public StudProducer(IStudentServices serv)
        {
            _serv = serv;
        }

        private readonly IProducer<Null, string> producer;

        public StudProducer()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"

            };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        
        public async Task StartAsync(CancellationToken cancellationToken)
        {

            await producer.ProduceAsync("studentTopic", new Message<Null, string>()
            {
                Value = "this is kafka test"
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
