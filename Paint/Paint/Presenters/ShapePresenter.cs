using Paint.Events;
using Paint.Managers;
using Paint.Models;
using Paint.Views;

namespace Paint.Presenters
{
    public class ShapePresenter
    {
        private readonly IShapeView _view;
        private readonly Shape _model;
        private readonly ShapeSelectionManager _selectionManager;
        private bool _isViewSelected;

        public ShapePresenter(
            IShapeView view,
            Shape model,
            ShapeSelectionManager selectionManager)
        {
            _view = view;
            _model = model;
            _selectionManager = selectionManager;
            _isViewSelected = false;

            _view.ShapeMouseUp += View_ShapeMouseUp;
            _view.ShapeMouseDown += View_ShapeMouseDown;
            _model.ShapeChanged += Model_ShapeChanged;

            _selectionManager.SelectionChanged += SelectionManager_SelectionChanged;
        }

        private void Model_ShapeChanged(object? sender, ShapeModelChangedEventArgs e)
        {
            _view.Frame = e.Shape.Frame;
        }

        private void SelectionManager_SelectionChanged(object? sender, ShapeSelectionEventArgs e)
        {
            if (e.SelectedShapeUid == _view.Uid && !_isViewSelected)
            {
                _isViewSelected = true;
                _view.SetFocus();
            }
            else if (e.SelectedShapeUid != _view.Uid && _isViewSelected)
            {
                _isViewSelected = false;
                _view.UnsetFocus();
            }
        }

        private void View_ShapeMouseDown(object? sender, ShapeViewEventArgs e)
        {
            _selectionManager.SelectedShapeUid = _view.Uid;
        }

        private void View_ShapeMouseUp(object? sender, ShapeViewEventArgs e)
        {
            _model.Frame = _view.Frame;
        }
    }
}
