using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirayOrnek.Data.Entitites
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
