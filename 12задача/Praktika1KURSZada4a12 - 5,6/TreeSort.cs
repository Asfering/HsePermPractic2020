using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Praktika1KURSZada4a12___5_6
{
    public class TreeSort
    {
        /// <summary>
        /// Дефолт свойства дерева
        /// </summary>
        public int Data { get; set; }
        public TreeSort Left { get; set; }
        public TreeSort Right { get; set; }

        /// <summary>
        /// конструктор дерева
        /// </summary>
        /// <param name="data"></param>
        public TreeSort(int data)
        {
            Data = data;
        }

        /// <summary>
        /// рекурсивное добавления элементов 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="compare"></param>
        public void AddRecurs(TreeSort item, ref int compare)
        {
            if (item.Data < Data)   //если дата входящего элемента меньше, чем дефолт дата (0)
            {
                compare++;  //сравнение, т.к. item.Data < Data
                if (Left == null)   //если слева пусто, то
                {
                    Left = item;   //лево - наш элемент
                }
                else   //иначе рекурсивный вызов
                    Left.AddRecurs(item, ref compare);
            }
            else   //иначе
            {
                compare++;  //сравнение, т.к. item.Data < Data
                if (Right == null)   //если справа пусто, то
                {
                    Right = item;   //право - наш элемент
                }
                else   //иначе рекурсивный вызов
                    Right.AddRecurs(item, ref compare);
            }
        }

        /// <summary>
        /// Переработка из дерева в массив
        /// </summary>
        /// <param name="compare"></param>
        /// <param name="listElements"></param>
        /// <returns></returns>
        public int[] ToMas(ref int compare,  int index, ref int[] array, List<int> listElements = null)
        {
            if (listElements == null)   //если лист нул
                listElements = new List<int>();   //создаем лист
            compare++;   //сравнение+ , т.к. listElements == null
            
            if (Left != null)   //если слева пусто, то
            {
                compare++;   //сравнение+, т.к. left != null
                Left.ToMas(ref compare, index+1, ref array, listElements);   //рекурсивный вызов функции
            }


            listElements.Add(Data); //добавляем элемент в лист


            if (Right != null)   //если справа пусто, то
            {
                compare++;   //сравнение+, т.к. rigth != null
                Right.ToMas(ref compare, index + 1, ref array, listElements);   //рекурсивный вызов функции
            }

            return listElements.ToArray();   //возврат массив
        }
    }
}