﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.Interfaces
{
    public interface ICreateOrderConsumer
    {
        Task HandleKafkaMessage(string topicMessage);
    }
}
