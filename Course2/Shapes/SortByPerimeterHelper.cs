using System.Collections.Generic;

namespace Shape
{
    public class SortByPerimeterHelper : IComparer<IShape>
    {
        int IComparer<IShape>.Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}
