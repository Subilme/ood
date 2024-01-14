using Paint.Enums;
using Paint.Events;
using Paint.Factories;
using Paint.Managers;
using Paint.Models;
using Paint.Presenters;
using Paint.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICanvasView
    {
        private readonly ShapeSelectionManager _selectionManager = new ShapeSelectionManager();
        private readonly ShapeDraggingManager _draggingManager = new ShapeDraggingManager();
        private readonly CanvasPresenter _canvasPresenter;

        public event EventHandler<CanvasViewShapeAddedEventArgs>? ShapeAdded;
        public event EventHandler<CanvasViewEventArgs>? CanvasMouseDown;
        public event EventHandler<CanvasViewEventArgs>? CanvasKeyPressed;
        public event EventHandler? DeleteButtonPressed;

        public MainWindow()
        {
            InitializeComponent();

            _canvasPresenter = new CanvasPresenter(
                new ShapeFactory(),
                _selectionManager,
                this,
                new Canvas());
        }

        public void AddShape(Shape shape)
        {
            var shapeView = new ShapeView(
                shape,
                MainCanvas,
                _draggingManager);
            _ = new ShapePresenter(
                shapeView,
                shape,
                _selectionManager);
        }

        public void RemoveShapeByUid(string uid)
        {
            var shape = GetShapeByUid(uid);
            if (shape != null)
            {
                MainCanvas.Children.Remove(shape);
            }
        }

        public System.Windows.Shapes.Shape? GetShapeByUid(string uid)
        {
            foreach (UIElement item in MainCanvas.Children)
            {
                if (item is System.Windows.Shapes.Shape shape && item.Uid == uid)
                {
                    return shape;
                }
            }
            return null;
        }

        private void AddEllipseButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeAdded?.Invoke(this, new CanvasViewShapeAddedEventArgs(MainCanvas, ShapeType.Ellipse));
        }

        private void AddRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeAdded?.Invoke(this, new CanvasViewShapeAddedEventArgs(MainCanvas, ShapeType.Rectangle));
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            ShapeAdded?.Invoke(this, new CanvasViewShapeAddedEventArgs(MainCanvas, ShapeType.Triangle));
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CanvasMouseDown != null)
            {
                object source = e.OriginalSource;

                if (source is System.Windows.Controls.Canvas canvas)
                {
                    CanvasMouseDown(this, new CanvasViewEventArgs(null));
                    canvas.Focus();
                }
            }
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (CanvasKeyPressed != null)
            {
                var args = new CanvasViewEventArgs(e.OriginalSource is System.Windows.Shapes.Shape 
                    ? e.OriginalSource as System.Windows.Shapes.Shape : null)
                {
                    KeyPressed = e.Key
                };
                CanvasKeyPressed(this, args);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
