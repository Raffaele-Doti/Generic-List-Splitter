using System;
using System.Collections.Generic;
using System.Text;

namespace ListSplitter.Models
{
    public class Car
    {
        #region Properties 
        
        /// <summary>
        /// Property to identify car manufacter
        /// </summary>
        public string Manufacter { get; set; }

        /// <summary>
        /// Property to identify car model.
        /// </summary>
        public string Model { get; set; }

        #endregion

        //WARNING  Override equals and hashcode if necessary
    }
}
