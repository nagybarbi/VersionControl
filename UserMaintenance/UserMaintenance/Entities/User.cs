using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMaintenance.Entities
{
    public class User
    {
        public override string ToString()
        {
            return ID + " " + FullName;
        }
        
        public Guid ID { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
    }
}
