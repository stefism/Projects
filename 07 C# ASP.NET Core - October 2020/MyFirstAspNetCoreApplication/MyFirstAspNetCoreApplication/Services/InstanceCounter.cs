using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApplication.Services
{
    public class InstanceCounter : IInstanceCounter
    {
        private static int instances; //Когато е статик, новата инстанция не го занулява!

        public InstanceCounter()
        {
            instances++;
        }

        public int Instances => instances;
    }
}
