﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Upperpik
{
    public static class SubstringExt
    {
        public static string After(this string val, string a)
        {
            int posA = val.LastIndexOf(a);
            if (posA == -1)
                return string.Empty;

            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= val.Length)
                return string.Empty;

            return val.Substring(adjustedPosA);
        }

		public static bool isEmpty(this string val)
		{
			if (string.Empty == val)
				return true;
			else
				return false;
		}

		public static string GetNextWord(this string str, string word)
        {
            string afterVal = str.Substring(str.IndexOf(word));

            string[] words = str.Split(' ');
            int len = words.Length;
            int countAfterNext = 0;
            for (int i = 0; i < len; i++)
            {
                if (countAfterNext == 0 && words[i] == word)
                    countAfterNext++;

                else if (countAfterNext > 0)
                    return words[i];              
                    
            }

            return string.Empty;
        }

		public static void GetWords(this string str, List<string> wordList)
		{
			string[] separators = new string[] { ",", ".",/* "!",*/ "\'", " ", "\'s" };

			foreach (string word in str.Split(separators, StringSplitOptions.RemoveEmptyEntries))
			{
				wordList.Add(word);
			}
		}
	}

}