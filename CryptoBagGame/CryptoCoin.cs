using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBagGame
{
    public class CryptoCoin
    {
        public string Name { get; set; }
        public string IconPath { get; set; }  // Path to an icon or image file for display in WPF
        public double Value { get; set; }

        public CryptoCoin(string name, string iconPath, double value)
        {
            Name = name;
            IconPath = iconPath;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name} - ${Value}";
        }
    }

}
