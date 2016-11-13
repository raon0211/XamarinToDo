using Now.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Now.Core.Abstract
{
    public interface IDataService
    {
        IEnumerable<TodoItem> List();
        void Remove(TodoItem item);
        void Add(TodoItem item);
        void Update(TodoItem item);
    }
}
