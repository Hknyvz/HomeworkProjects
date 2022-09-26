using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityChangeLog.Domain.Entities
{
    public interface IEntityChangeLog
    {
        public int Id { get; set; }
    }
}
