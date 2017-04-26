using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Visitor interface
    /// </summary>
    public interface IFigureVisitor
    {
        void Visit(Circle circle);
        void Visit(Square square);
        void Visit(Recktangle recktangle);
        void Visit(Triangle triangle);
    }
}
