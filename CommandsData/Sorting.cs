using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsData {
    /// <summary>
    /// Реализует тестируемые алгоритмы 
    /// сортировки целых чисел
    /// </summary>
    public class Sorting {
        public void ShellSort(int[] array) {
            int j;
            int step = array.Length / 2;
            while (step > 0) {
                for (int i = 0; i < (array.Length - step); i++) {
                    j = i;
                    while ((j >= 0) && (array[j] > array[j + step])) {
                        int tmp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }

        int Partition(int[] array, int start, int end) {
            int temp;//временная переменная для обмена
            int marker = start;//разделяет левый и правый подмассивы
            for (int i = start; i <= end; i++) {
                if (array[i] < array[end]) //array[end] является опорным значением
                {
                    temp = array[marker]; // обмен значениями
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //помещаем опорное значение (array[end]) между левым и правым подмассивами
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public void QuickSort(int[] array, int start, int end) {
            if (start >= end) {
                return;
            }
            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        public void BubbleSort(int[] array) {
            for (int i = 0; i < array.Length; i++) {
                for (int j = 0; j < array.Length - i - 1; j++) {
                    if (array[j] > array[j + 1]) {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
