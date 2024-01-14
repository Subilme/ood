using Paint.Enums;
using Paint.Events;
using System;

namespace Paint.Models
{
    // TODO: Пересмотреть, нужно ли наследование
    // TODO: Различные цвета фигур или рамку
    public abstract class Shape
    {
        public readonly ShapeType ShapeType;
        public readonly string Uid;

        public string Color { get; set; } = "DarkBlue";

        private Frame _frame;
        public Frame Frame
        {
            get
            {
                return _frame;
            }
            set
            {
                _frame = value;
                ShapeChanged?.Invoke(this, new ShapeModelChangedEventArgs(this));
            }
        }

        public event EventHandler<ShapeModelChangedEventArgs>? ShapeChanged;

        public Shape(ShapeType shapeType, Frame frame)
        {
            ShapeType = shapeType;
            Frame = frame;
            Uid = Guid.NewGuid().ToString();
        }
    }
}
