using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Provides event additional information
    /// </summary>
    public sealed class ValueChangedEventArgs : EventArgs
    {
        
        public int Row { get; }
        public int Column { get; }
        
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="column">Column index</param>
        public ValueChangedEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }


    }
}
