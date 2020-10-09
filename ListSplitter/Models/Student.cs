using System;
using System.Collections.Generic;
using System.Text;

namespace ListSplitter.Models
{
    public class Student
    {
        #region Properties

        /// <summary>
        /// Property to identify student name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property to identify student surname
        /// </summary>
        public string Surname { get; set; }

        #endregion

        //WARNING : Override equals and hashcode methods if necessary
    }
}
