using Paint.Events;
using Paint.Factories;
using Paint.Managers;
using Paint.Models;
using Paint.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Paint.Presenters
{
    public class CanvasPresenter
    {
        private const double InitialShapeWidth = 50;
        private const double InitialShapeHeight = 50;
        private const string InitialShapeColor = "DarkBlue";

        private readonly IShapeFactory _shapeFactory;
        private readonly ShapeSelectionManager _selectionManager;
        private readonly ICanvasView _canvasView;
        private readonly Canvas _canvasModel;

        public Canvas GetDomainCanvas() => _canvasModel;

        public CanvasPresenter(
            IShapeFactory shapeFactory,
            ShapeSelectionManager selectionManager,
            ICanvasView canvasView,
            Canvas canvasModel)
        {
            _shapeFactory = shapeFactory;
            _selectionManager = selectionManager;
            _canvasView = canvasView;
            _canvasModel = canvasModel;

            _canvasView.ShapeAdded += CanvasView_ShapeAdded;
            _canvasView.CanvasMouseDown += CanvasView_MouseDown;
            _canvasView.CanvasKeyPressed += CanvasView_KeyPressed;
            _canvasView.DeleteButtonPressed += CanvasView_DeleteButtonPressed;

            _canvasModel.ShapeAdded += CanvasModel_ShapeAdded;
            _canvasModel.ShapeRemoved += CanvasModel_ShapeRemoved;

            LoadShapes();
        }

        // TODO: Переименовать метод
        private void LoadShapes()
        {
            foreach (Shape shape in _canvasModel.Shapes)
            {
                _canvasView.AddShape(shape);
            }
        }

        private void CanvasView_KeyPressed(object? sender, CanvasViewEventArgs e)
        {
            switch (e.KeyPressed)
            {
                case Key.Delete:
                    RemoveShapeByUid(_selectionManager.SelectedShapeUid!);
                    break;
                default:
                    break;
            }
        }

        private void CanvasView_DeleteButtonPressed(object? sender, EventArgs e)
        {
            RemoveShapeByUid(_selectionManager.SelectedShapeUid!);
        }

        private void CanvasView_ShapeAdded(object? sender, CanvasViewShapeAddedEventArgs e)
        {
            Frame frame = new Frame(
                e.Canvas.ActualWidth / 2 - InitialShapeWidth / 2,
                e.Canvas.ActualHeight / 2 - InitialShapeHeight / 2,
                InitialShapeWidth,
                InitialShapeHeight
                );
            Shape shape = _shapeFactory.CreateShape(e.ShapeType, frame);
            shape.Color = InitialShapeColor;
            _canvasModel.AddShape(shape);
        }

        private void CanvasView_MouseDown(object? sender, CanvasViewEventArgs e)
        {
            _selectionManager.SelectedShapeUid = null;
        }

        private void CanvasModel_ShapeAdded(object? sender, CanvasModelShapeAddedEventArgs e)
        {
            _canvasView.AddShape(e.Shape);
        }

        private void CanvasModel_ShapeRemoved(object? sender, CanvasModelShapeRemovedEventArgs e)
        {
            var shape = _canvasView.GetShapeByUid(e.Uid);
            if (shape != null)
            {
                _canvasView.RemoveShapeByUid(shape.Uid);
            }
        }

        private void RemoveShapeByUid(string uid)
        {
            if (uid != null)
            {
                if (_selectionManager.SelectedShapeUid == uid)
                {
                    _selectionManager.SelectedShapeUid = null;
                }

                Shape? shape = _canvasModel.GetShapeByUid(uid);
                if (shape != null)
                {
                    _canvasModel.RemoveShape(shape);
                }
            }
        }
    }
}
