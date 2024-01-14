using System;

namespace Paint.Events
{
    public class CanvasModelShapeRemovedEventArgs : EventArgs
    {
        public string Uid { get; }

        public CanvasModelShapeRemovedEventArgs(string uid)
        {
            Uid = uid;
        }
    }
}
