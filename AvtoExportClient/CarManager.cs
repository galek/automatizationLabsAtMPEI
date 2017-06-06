using System;
using System.Collections.Generic;

namespace AvtoExportClient
{
    public sealed class CarManager
    {
        private static volatile CarManager instance;
        private static object syncRoot = new Object();

        private CarManager()
        {
            _Test();
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

        public List<BaseCar> carList = new List<BaseCar>();


        private void _Test()
        {
            carList.Add(new VFTS_Base());
            carList.Add(new VFTS_Base());
            carList.Add(new VFTS_Base());
            carList.Add(new VFTS_Base());
        }
    }
}
