using System;

namespace Paint.Events
{
    public class CanvasViewShapeRemovedEventArgs : EventArgs
    {
        public string Uid { get; }

        public CanvasViewShapeRemovedEventArgs(string uid)
        {
            Uid = uid;
        }
    }
}
