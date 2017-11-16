using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7._1
{
    /// <summary>
    /// Класс список
    /// </summary>
    /// <typeparam name="T">Тип элементов списка</typeparam>
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
            /// <param name="Value">Значение элемента списка</param>
            /// <param name="Next">Указатель на следующий элемент списка</param>
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
        /// Добавление элемента на указанную позицию
        /// n >= 0
        /// position не может быть больше length
        /// </summary>
        /// <param name="value">Значение нового элемента</param>
        /// <param name="position">Позиция нового элемента</param>
        public void AddValue(T value, int position)
        {
            if (position < 0 || position > this.length)
            {
                throw new InvalidOperationException("Incorrect position!");
            }

            if (position == 0)
            {
                this.head = new ListElement(value, this.head);
                this.length++;
                return;
            }

            ListElement cursor = this.head;
            for (var i = 0; i < position - 1; i++)
            {
                cursor = cursor.Next;
            }

            var newElement = new ListElement(value, cursor.Next);
            cursor.Next = newElement;
            this.length++;
        }

        /// <summary>
        /// Получение значения указанного элемента
        /// </summary>
        /// <param name="position">Позиция элемента</param>
        public T GetValue(int position)
        {
            if (position < 0 || position >= this.length)
            {
                throw new InvalidOperationException("Incorrect position!");
            }

            var cursor = this.head;
            for (var i = 0; i < position; ++i)
            {
                cursor = cursor.Next;
            }

            return cursor.Value;
        }

        /// <summary>
        /// Удаление элемента с n-ой позиции
        /// </summary>
        /// <param name="position">Позиция элемента, который нужно удалить</param>
        public void DeleteElement(int position)
        {
            if (position < 0 || position >= length)
            {
                throw new InvalidOperationException("Incorrect position!");
            }

            if (position == 0)
            {
                this.head = head.Next;
                this.length--;
                return;
            }

            ListElement cursor = this.head;
            for (int i = 0; i < position - 1; i++)
            {
                cursor = cursor.Next;
            }

            cursor.Next = cursor.Next.Next;
            this.length--;
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
        /// Просмотр перечислителя
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
            /// Возвращает значение текущего элемента
            /// </summary>
            public T Current
            {
                get { return cursor.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose() { } 

            /// <summary>
            /// Переход к следующему элементу
            /// </summary>
            public bool MoveNext()
            {
                if (this.head == null)
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
            /// Сдвиu указатель на начальную позицию
            /// </summary>
            public void Reset() => cursor = null;
        }
    }
}
