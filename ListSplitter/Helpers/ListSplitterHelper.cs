using ListSplitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ListSplitter.Helpers
{
    public class ListSplitterHelper : IListSplitterHelper
    {
        #region Methods 


        /// <summary>
        /// Used to split a list into smaller elements lists.
        /// E.g. If you have a list of 8 elements and you want to split it into 4 list of 2 elements you can call this method providing elementList and splitting value = 2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elementList"></param>
        /// <param name="splittingValue"></param>
        /// <returns></returns>
        public List<List<T>> Split<T>(List<T> elementList, long splittingValue)
        {
            //params check 
            if (elementList == null)
            {
                //throw application exception 
                throw new ApplicationException($"{this.GetType().Name}.{MethodBase.GetCurrentMethod().Name} : Error #AKOP23 elementList param cannot be null");
            }
            if (splittingValue <= 0)
            {
                //throw application exception 
                throw new ApplicationException($"{this.GetType().Name}.{MethodBase.GetCurrentMethod().Name} : Error #DVA30 splittingValue canno be <= 0");
            }
            //init result list
            var resultList = new List<List<T>>();
            //for cycle to iterate over input element list 
            for (double currentIndex = 0; currentIndex < Convert.ToDouble(elementList.Count) / Convert.ToDouble(splittingValue); currentIndex++) // while current index is lower than list count / splitting value ( that's why user wants to split input list in chunk of splitting value number . E.g. an input list with 6 element and splitting value = 2 will return 3 list of 2 elements instead an input list with 6 element and splitting value = 4 will return a list of 4 elements and a list of 2 elements )
            {
                //we have to retrieve elements at current index * splitting value cause we have to get for each iteration a number of elements equals to splittingValue value.
                var currentSplittedElementsList = elementList.Skip(Convert.ToInt32(currentIndex * splittingValue)).Take(Convert.ToInt32(splittingValue)).ToList();
                //adding to result list current splitted elements list
                resultList.Add(currentSplittedElementsList);
            }
            //all operations performed return 
            return resultList;
        }

        #endregion
    }
}
