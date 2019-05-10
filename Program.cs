using System;

namespace researchwork
{
    class MyClass
    {
        static void Main(string[] args)
        {
            TrafficGenerator TG = new TrafficGenerator();
            Node Network = new Node();

            DateTime isTime = new DateTime(2019, 4, 24, 14, 30, 0);
            DateTime newTime = new DateTime();
            newTime = isTime.AddSeconds(1);

            for (int i = 0; i < 1000; i++)
            {

                newTime = newTime.AddSeconds(1);
                Console.WriteLine("{Node: " + TG.Nodes() + ", Time: " + newTime.ToString() + ",  Temperature : " + TG.Temperature() + ",  Humidity : " + TG.Humidity() + "}");
            }
        }
    }
    class Node
    {
        private int temp;
        private int humidity;
        private int nodes;

        public int setTemp(int temp)
        {
            this.temp = temp;
            return temp;

        }
        public int setHumidity(int humidity)
        {
            this.humidity = humidity;
            return humidity;
        }

        public int setNumberOfNodes(int nodes)
        {
            this.nodes = nodes;
            return nodes;
        }
    }

    class TrafficGenerator
    {
        Node N = new Node();
        public int N_nodes, H_humidity, T_temp;

        Random rnd = new Random();
        public int Nodes()
        {
            int rndnodes = rnd.Next(30, 50);
            N_nodes = N.setNumberOfNodes(rndnodes);
            return N_nodes;
        }
        public int Temperature()
        {
            int rndtemp = rnd.Next(30, 55);
            T_temp = N.setTemp(rndtemp);
            return T_temp;
        }
        public int Humidity()
        {

            int rndhumidity = rnd.Next(110, 150);
            H_humidity = N.setHumidity(rndhumidity);
            return H_humidity;
        }
    }
}
