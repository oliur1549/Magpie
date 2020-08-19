using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
