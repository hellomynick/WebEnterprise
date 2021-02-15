using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Faculty
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public List<Position> Positions { get; set; }
    }
}