/*

using System.Collections.Generic;
using PalceholderAPI.Models;

namespace PalceholderAPI
{
    public class Storage
    {
        private static List<Posts> postsList = new List<Posts>();
        public static (Posts[] postsArray, int count) GetAll()
        {
            return (postsList.ToArray(), postsList.Count);
        }

        public static bool Add(Posts post)
        {
            if (post == null)
            {
                return false;
            }
            postsList.Add(post);
            return true;
        }
    }
}

*/