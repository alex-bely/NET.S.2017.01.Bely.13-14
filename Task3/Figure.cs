using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Common figure class
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Accepts visitor instance
        /// </summary>
        /// <param name="visitor">Visitor instance for accepting</param>
        public void Accept(IFigureVisitor visitor)
        {
            visitor.Visit((dynamic)this);
        }
    }
}
