using System.Collections.Generic;
using ToDoAPI.Models;

namespace ToDoAPI
{
    public static class Storage
    {
        private static List<ToDo> List = new List<ToDo>();
        public static (ToDo[] toDos, int count) GetAll()
        {
            return (List.ToArray(), List.Count);
        }

        public static bool Add(ToDo toDo)
        {
            if (toDo == null)
            {
                return false;
            }
            List.Add(toDo);
            return true;
        }

    }
}