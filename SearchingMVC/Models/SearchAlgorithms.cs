using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SearchingMVC.Models;

namespace SearchingMVC.Controllers
{
    public class SearchAlgorithms
    {
        private List<int> _numbers;
        public SearchAlgorithms(List<int> numbers)
        {
            _numbers = numbers;
        }

        public SearchAlgorithms()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "scores.txt");
            _numbers = File.ReadAllLines(filePath).Select(int.Parse).ToList();
        }

        public int LinearSearch(int target)
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                if (_numbers[i] == target)
                    return i;
            }
            return -1;
        }

        public int BinarySearch(int target)
        {
            var sortedNumbers = _numbers.OrderBy(x => x).ToList();
            int left = 0, right = sortedNumbers.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedNumbers[mid] == target)
                    return mid;

                if (sortedNumbers[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        public int InterpolationSearch(int target)
        {
            var sortedNumbers = _numbers.OrderBy(x => x).ToList();
            int low = 0, high = sortedNumbers.Count - 1;

            while (low <= high && target >= sortedNumbers[low] && target <= sortedNumbers[high])
            {
                int pos = low + ((target - sortedNumbers[low]) * (high - low)) /
                    (sortedNumbers[high] - sortedNumbers[low]);

                if (sortedNumbers[pos] == target)
                    return pos;

                if (sortedNumbers[pos] < target)
                    low = pos + 1;
                else
                    high = pos - 1;
            }
            return -1;
        }
    }
}