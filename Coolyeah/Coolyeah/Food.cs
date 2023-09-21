using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolyeah
{
    class Food
    {
        // Private attributes
        private string _notes;
        private int _value;

        // Public properties
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        // Constructor
        public Food(string notes, int value)
        {
            _notes = notes;
            _value = value;
        }

        // Function to increase the Value
        public void Increase()
        {

        }

        // Function to decrease the Value
        public void Decrease()
        {

        }
    }

}
