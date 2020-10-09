using System.Collections.Generic;

namespace ListSplitter.Interfaces
{
    public interface IListSplitterHelper
    {
        List<List<T>> Split<T>(List<T> elementList, long splittingValue);
    }
}