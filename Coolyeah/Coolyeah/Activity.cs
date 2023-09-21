using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolyeah
{
    class Activity
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
        public Activity(string notes, int value)
        {
            _notes = notes;
            _value = value;
        }

        // Function to set Value based on timestamps
        public void SetValue(DateTime start, DateTime end)
        {
            
        }
    }
}
