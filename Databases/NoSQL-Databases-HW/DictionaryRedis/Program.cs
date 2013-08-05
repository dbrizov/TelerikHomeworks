namespace _02.Redis_Dictionary_Implementation
{
    using ServiceStack.Redis;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            using (RedisClient client = new RedisClient())
            {
                UI.DrawMenu();

                Console.Write("Please enter a dictionary name: ");
                string dictionaryName = Console.ReadLine();

                RedisDictionary redisDictionary = new RedisDictionary(client, dictionaryName);

                while (true)
                {
                    Console.Write("Please enter a command: ");
                    string command = Console.ReadLine().Trim();

                    if (command == "Exit")
                    {
                        break;
                    }

                    Engine.ParseCommand(command, redisDictionary);
                }

                //redisDictionary.Add("gosho", "ribata");
                //redisDictionary.Add("pesho", "akademiqta");
                //redisDictionary.Add("kiki", "razvrata");

                //Console.WriteLine(redisDictionary["kiki"]);

                //Console.WriteLine(redisDictionary.ContainsKey("pesho"));
                //redisDictionary.Remove("pesho");
                //Console.WriteLine(redisDictionary.ContainsKey("pesho"));

                //foreach (var item in redisDictionary)
                //{
                //    Console.WriteLine("{0} -> {1}", item.Key, item.Value);
                //}

                //redisDictionary["kiki"] = "obshtata";

                //Console.WriteLine(redisDictionary["kiki"]);
            }
        }
    }
}
