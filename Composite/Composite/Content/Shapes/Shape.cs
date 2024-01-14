using Composite.App;
using Composite.Common;
using Composite.Content.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Content.Shapes
{
    public abstract class Shape : IShape
    {
        public virtual Frame Frame { get; set; }

        public IBorderStyle BorderStyle { get; }

        public IStyle FillStyle { get; set; }

        public IGroup Group { get; }

        public abstract void Draw(ICanvas canvas);
    }
}
