using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolyeah
{
    class Stats
    {
        // Private attributes
        private string _type;
        private int _value;
        private int _idealValue;

        // Public properties
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int IdealValue
        {
            get { return _idealValue; }
            set { _idealValue = value; }
        }

        // Constructor
        public Stats(string type, int value, int idealValue)
        {
            _type = type;
            _value = value;
            _idealValue = idealValue;
        }

        // Function to set IdealValue based on user class attributes
        public void SetIdealValue(int height, int weight, int age, string gender)
        {
            //empty
        }

        // Function to reset data
        public void ResetData()
        {
            // Reset all attributes to their default values.
        }
    }
}
