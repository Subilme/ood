using System;

namespace Paint.Events
{
    public class ShapeSelectionEventArgs : EventArgs
    {
        public string? SelectedShapeUid { get; }

        public ShapeSelectionEventArgs(string? selectedShapeUid)
        {
            SelectedShapeUid = selectedShapeUid;
        }
    }
}
