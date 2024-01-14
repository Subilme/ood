using Paint.Events;
using System;

namespace Paint.Managers
{
    // TODO: Изменить название класса
    public class ShapeSelectionManager
    {
        private string? _selectedShapeUid;
        public string? SelectedShapeUid
        {
            get => _selectedShapeUid;
            set
            {
                _selectedShapeUid = value;
                SelectionChanged?.Invoke(this, new ShapeSelectionEventArgs(_selectedShapeUid));
            }
        }

        public event EventHandler<ShapeSelectionEventArgs>? SelectionChanged;
    }
}
