using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserDataStructure
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"ID: {UserId}, Name: {UserName}, Email: {Email}, Company: {Company}, Location: {Location}";
        }
    }
}
