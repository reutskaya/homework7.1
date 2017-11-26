using System;

namespace Homework7_1
{
    /// <summary>
    /// Класс стек
    /// </summary>
    public class Stack<T>
    {
        /// <summary>
        /// Элемент стека
        /// </summary>
        private class StackElement
        {
            public StackElement Next;
            public T Value { get; private set; }


            public StackElement(StackElement next, T value)
            {
                Next = next;
                Value = value;
            }
        }

        /// <summary>
        /// Указатель на первый элемент стека
        /// </summary>
        private StackElement head = null;

        /// <summary>
        /// Метод, добавляющий один элемент в стек
        /// </summary>
        public void Push(T value) => head = new StackElement(head, value);

        /// <summary>
        /// Метод, возвращающий значение с головы стека
        /// </summary>
        public T Pop()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            T element = head.Value;
            head = head.Next;
            return element;
        }

        /// <summary>
        /// Метод возвращает true, если стек пустой
        /// </summary>
        public bool IsStackEmpty() => head == null;
    }
}