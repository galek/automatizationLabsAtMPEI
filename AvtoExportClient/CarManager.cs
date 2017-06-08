using System;
using System.Collections.Generic;

namespace AvtoExportClient
{
    [Serializable]
    public sealed class CarManager
    {
        [NonSerialized]
        private static volatile CarManager instance;

        [NonSerialized]
        private static object syncRoot = new Object();

        private CarManager()
        {
        }

        public static CarManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CarManager();
                    }
                }

                return instance;
            }
        }

        //[Serializable]
        public List<BaseCar> carListOrdered = new List<BaseCar>();
        public List<BaseCar> carListPreOrder = new List<BaseCar>();
        
    }
}