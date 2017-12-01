using System;
using System.Collections;
using System.Collections.Generic;

namespace homework7_1
{
    /// <summary>
    /// Класс список
    /// </summary>
    public class List<T>
    {
        /// <summary>
        /// Элемент списка
        /// </summary>
        private class ListElement
        {
            /// <summary>
            /// Значение элемента списка
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Указатель на следующий элемент списка
            /// </summary>
            public ListElement Next { get; set; }

            /// <summary>
            /// Конструктор для класса ListElement
            /// </summary>
            /// <param name="Value">Значение элемента</param>
            /// <param name="Next">указатель на следующий элемент</param>
            public ListElement(T value, ListElement next)
            {
                Value = value;
                Next = next;
            }
        }

        /// <summary>
        /// Указатель на первый элемент списка
        /// </summary>
        private ListElement head;

        /// <summary>
        /// Длина списка
        /// </summary>
        private int length;

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="Value">Значение нового элемента</param>
        /// <param name="position">Позиция нового элемента</param>
        public void AddValue(T Value, int position)
        {
            if (position < 0 || position > length)
            {
                throw new InvalidOperationException("Incorrect position!");
            }
            if (position == 0)
            {
                head = new ListElement(Value, head);
                length++;
                return;
            }
            ListElement cursor = head;
            for (var i = 0; i < position - 1; i++)
            {
                cursor = cursor.Next;
            }
            var newElement = new ListElement(Value, cursor.Next);
            cursor.Next = newElement;
            length++;
        }

        /// <summary>
        /// Получение значения элемента 
        /// </summary>
        /// <param name="position">Позиция искомого элемента</param>
        public T GetValue(int position)
        {
            if (position < 0 || position >= length)
            {
                throw new InvalidOperationException("Incorrect position!");
            }

            var cursor = head;
            for (var i = 0; i < position; ++i)
            {
                cursor = cursor.Next;
            }

            return cursor.Value;
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="position">Позиция удаляяемого элемента</param>
        public void DeleteElement(int position)
        {
            if (position < 0 || position >= length)
            {
                throw new InvalidOperationException("Incorrect position!");
            }
            if (position == 0)
            {
                head = head.Next;
                length--;
                return;
            }
            ListElement cursor = head;
            for (int i = 0; i < position - 1; i++)
            {
                cursor = cursor.Next;
            }
            cursor.Next = cursor.Next.Next;
            length--;
        }

        /// <summary>
        /// Вовзращает длину списка
        /// </summary>
        /// <returns></returns>
        public int GetLength() => length;

        /// <summary>
        /// Перечислитель
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => new ListEnumerator(this);

        /// <summary>
        /// Класс для перебора коллекции
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Указатель на первый элемент
            /// </summary>
            private ListElement head;

            /// <summary>
            /// Указатель на текущий элемент
            /// </summary>
            private ListElement cursor;

            /// <summary>
            /// Конструктор перечислителя
            /// </summary>
            public ListEnumerator(List<T> list)
            {
                head = list.head;
            }

            /// <summary>
            /// Значение текущего элемента
            /// </summary>
            public T Current
            {
                get
                {
                    return cursor.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {

            }

            /// <summary>
            /// Переход к следующему элементу
            /// </summary>
            public bool MoveNext()
            {
                if (head == null)
                {
                    return false;
                }
                if (cursor == null)
                {
                    cursor = head;

                    return true;
                }

                if (cursor.Next == null)
                {
                    return false;
                }

                cursor = cursor.Next;
                return true;
            }

            /// <summary>
            /// Сдвинуть указатель на начальную позицию
            /// </summary>
            public void Reset() => cursor = null;
        }
    }
}