using System;
using System.Collections.Generic;
namespace SVLibrary
{
    public class SVrandom : System.Random
    {
        int _min, _max;
        Stack<int> list;

        public SVrandom(int minValue, int maxValue)
        {
            _max = maxValue;
            _min = minValue;
            genList();
        }

        protected void genList()
        {
            System.Random rand = new System.Random();
            List<int> temp = new List<int>();
            for (int i = 0; i < _max - _min; i++)
            {
                temp.Add(i);
            }
            list = new Stack<int>();
            while (temp.Count > 0)
            {
                int addInt = temp[rand.Next(0, temp.Count)];
                list.Push(addInt);
                temp.Remove(addInt);
            }
        }

        public override int Next()
        {
            if (list.Count > 0)
            {
                return list.Pop();
            }
            else
            {
                genList();
            }
            return list.Pop();
        }

        public int[] NextIntArr(int minValue, int maxValue, int Value)
        {
            SVrandom rand = new SVrandom(minValue, maxValue);
            int[] temp = new int[Value];
            for (int i = 0; i < Value; i++)
                temp[i] = rand.Next();
            return temp;
        }

        public enum TypeString
        {
            ru_ru = 0,
            ru_RU = 0,
            en_en = 0,
            en_EN = 0,
            all_ALL = 0,
        }

        public static string NextString(int minString, int maxString, TypeString type)
        {
            string ru_ru = "йцукенгшщзхъэждлорпавыфячсмитьбю";
            string ru_RU = "йцукенгшщзхъэждлорпавыфячсмитьбюЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";
            string en_en = "qwertyuioplkjhgfdsazxcvbnm";
            string en_EN = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
            string all_ALL = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNMйцукенгшщзхъэждлорпавыфячсмитьбюЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮ";
            SVrandom rand = new SVrandom(minString, maxString);
            int randtemp = rand.Next();
            string stringtemp = default;
            if (type == TypeString.ru_ru)
                for (int i = 0; i < randtemp; i++)
                    stringtemp += ru_ru[rand.Next(0, ru_ru.Length)];
            if (type == TypeString.ru_RU)
                for (int i = 0; i < randtemp; i++)
                    stringtemp += ru_RU[rand.Next(0, ru_RU.Length)];
            if (type == TypeString.en_en)
                for (int i = 0; i < randtemp; i++)
                    stringtemp += en_en[rand.Next(0, en_en.Length)];
            if (type == TypeString.en_EN)
                for (int i = 0; i < randtemp; i++)
                    stringtemp += en_EN[rand.Next(0, en_EN.Length)];
            if (type == TypeString.all_ALL)
                for (int i = 0; i < randtemp; i++)
                    stringtemp += all_ALL[rand.Next(0, all_ALL.Length)];
            return stringtemp;
        }

        public static bool NextBool()
        {
            SVrandom rand = new SVrandom(0, 10);
            int randtemp = rand.Next();
            if (randtemp < 5)
                return false;
            else
                return true;
        }

        public static int ATrand(int minValue, int maxValue)
        {
            SVrandom rand = new SVrandom(minValue, maxValue);
            return rand.Next();
        }
    }
    public class SVsort
    {
        private static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public static int[] Bubble(int[] array)
        {
            int temp = default;
            for (int write = 0; write < array.Length; write++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        public static int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }

        public static int[] ShellSort(int[] array)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }
            return array;
        }

        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }
            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

    }
    public class WNETEncryption
    {
        const string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 !@#$%^&*()_+№;%:?*()~";

        public static object Encrypt(object key, object text, int? complexity = 6)
        {
            List<char> alph_ru_ru_list = new List<char>();
            List<string> DoubleCode = new List<string>();
            foreach (char ch in alph)
            {
                alph_ru_ru_list.Add(ch);
            }
            Random rand = new Random(SetKey(key.ToString()));
            string done = "";

            for (int j = 0; j < alph_ru_ru_list.Count; j++)
            {
                for (int i = 0; i < complexity; i++)
                {
                    done += rand.Next(0, 9);
                }
                DoubleCode.Add(done);
                done = "";
            }
            string CriptText = "";
            for (int j = 0; j < text.ToString().Length; j++)
            {
                for (int i = 0; i < alph_ru_ru_list.Count; i++)
                {
                    if (text.ToString()[j] == alph_ru_ru_list[i])
                        CriptText = CriptText += DoubleCode[i];
                }
            }
            return CriptText;
        }
        public static object Decrypt(object key, object text, int? complexity = 6)
        {
            List<char> alph_ru_ru_list = new List<char>();
            List<string> DoubleCode = new List<string>();
            foreach (char ch in alph)
            {
                alph_ru_ru_list.Add(ch);
            }
            Random rand = new Random(SetKey(key.ToString()));
            string done = "";

            for (int j = 0; j < alph_ru_ru_list.Count; j++)
            {
                for (int i = 0; i < complexity; i++)
                {
                    done += rand.Next(0, 9);
                }
                DoubleCode.Add(done);
                done = "";
            }
            string buffer = "";
            List<string> CriptCode = new List<string>();

            foreach (char i in text.ToString())
            {
                buffer = buffer += i;
                if (buffer.Length >= complexity)
                {
                    CriptCode.Add(buffer);
                    buffer = "";
                }
            }

            string CriptText = "";
            for (int j = 0; j < CriptCode.Count; j++)
            {
                for (int i = 0; i < DoubleCode.Count; i++)
                {
                    if (CriptCode[j] == DoubleCode[i])
                        CriptText = CriptText += alph_ru_ru_list[i];
                }
            }
            return CriptText;
        }
        private static int SetKey(string key)
        {
            int dokey = default;
            dokey = key.Length;
            try
            {
                dokey = dokey += Int32.Parse(key);
                dokey = dokey += key.GetHashCode();
            }
            catch
            {
                dokey = dokey += key.GetHashCode();
            }
            dokey = dokey * key.Length;

            int dokeytwo = dokey;
            dokeytwo = (dokey * (key.Length * dokeytwo));
            dokeytwo = dokeytwo - DateTime.Now.Month;

            return dokeytwo;
        }
    }
}
