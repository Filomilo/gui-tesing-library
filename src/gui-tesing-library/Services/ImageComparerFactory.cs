using gui_tesing_library.Interfaces;
using System;

namespace gui_tesing_library.Services
{

    public static partial class ImageComparerFactory
    {
        public enum IMAGE_COMPARER_TYPE
        {
            HASH_COMPARER,
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
}
