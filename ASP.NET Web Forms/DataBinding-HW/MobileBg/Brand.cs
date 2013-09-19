using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileBg
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Model> Models { get; set; }

        public Brand(int id, string name, List<Model> models)
        {
            this.Id = id;
            this.Name = name;
            this.Models = models;
        }
    }
}