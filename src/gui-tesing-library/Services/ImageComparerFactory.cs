using System;
using gui_tesing_library.Interfaces;

namespace gui_tesing_library_CS.Services;

public static class ImageComparerFactory
{
    public enum IMAGE_COMPARER_TYPE
    {
        HASH_COMPARER
    }

    public static IImageComparer GetComparer()
    {
        throw new NotImplementedException();
        //switch (Configuration.ImageComparerType)
        //{
        //    case IMAGE_COMPARER_TYPE.HASH_COMPARER:
        //        return new HashImageComparer();
        //    default:
        //        throw new ArgumentOutOfRangeException();
        //}
    }
}