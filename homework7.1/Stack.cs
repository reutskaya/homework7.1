using System;

namespace homework7_1
{
    /// <summary>
    /// Класс cтек
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
        /// Первый элемент стека
        /// </summary>
        private StackElement head = null;

        /// <summary>
        /// Добавление элемента в стек
        /// </summary>
        public void Push(T value) => head = new StackElement(head, value);

        /// <summary>
        /// Возврат значения с головы стека
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
