using Paint.Adorners.Thumbs;
using Paint.Builders;
using Paint.Extensions;
using Paint.Managers;
using System.Windows.Input;
using System;
using System.Windows.Controls;
using System.Windows.Shapes;
using Paint.Events;

namespace Paint.Views
{
    public class ShapeView : IShapeView
    {
        private readonly Canvas _canvas;
        private readonly ShapeDraggingManager _draggingManager;
        private readonly Shape _widget;
        private readonly ResizeThumb _resizeThumb;

        private bool _isFocused = false;

        public event EventHandler<ShapeViewEventArgs>? ShapeMouseDown;
        public event EventHandler<ShapeViewEventArgs>? ShapeMouseUp;

        public string Uid { get; }

        private Frame _frame;
        public Frame Frame
        {
            get
            {
                return _frame;
            }
            set
            {
                _frame.X = value.X;
                _frame.Y = value.Y;
                _frame.Width = value.Width;
                _frame.Height = value.Height;
                UpdateLayout();
            }
        }

        public ShapeView(
            Models.Shape shape,
            Canvas canvas,
            ShapeDraggingManager draggingManager)
        {
            _canvas = canvas;
            _draggingManager = draggingManager;

            Uid = shape.Uid;

            _widget = ShapeViewBuilder.BuildView(shape);
            _widget.Focusable = true;
            _widget.MouseDown += ShapeView_MouseDown;
            _widget.MouseUp += ShapeView_MouseUp;
            _draggingManager.EnableDrag(_widget);
            Frame = shape.Frame;

            _resizeThumb = new ResizeThumb(_widget);
            _resizeThumb.IsEnabled = false;

            Display();
        }

        private void ShapeView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ShapeMouseDown != null && e.OriginalSource is Shape shape)
            {
                ShapeMouseDown(this, new ShapeViewEventArgs(shape));
            }
        }

        private void ShapeView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _frame = new Frame(
                Canvas.GetLeft(_widget),
                Canvas.GetTop(_widget),
                _widget.ActualWidth,
                _widget.ActualHeight
                );

            if (ShapeMouseUp != null && e.OriginalSource is Shape shape)
            {
                ShapeMouseUp(this, new ShapeViewEventArgs(shape));
            }
        }

        public void SetFocus()
        {
            if (!_isFocused)
            {
                _isFocused = true;
                _widget.EnableSelectionAdorner();
                _widget.Focus();
                _resizeThumb.Enable();
            }
        }

        public void UnsetFocus()
        {
            if (_isFocused)
            {
                _isFocused = false;
                _widget.DisableSelectionAdorner();
                _resizeThumb.Disable();
            }
        }

        private void UpdateLayout()
        {
            Canvas.SetLeft(_widget, Frame.X);
            Canvas.SetTop(_widget, Frame.Y);
            _widget.Width = Frame.Width;
            _widget.Height = Frame.Height;
        }

        private void Display()
        {
            _canvas.Children.Add(_widget);
            _canvas.Children.Add(_resizeThumb);
        }
    }
}
