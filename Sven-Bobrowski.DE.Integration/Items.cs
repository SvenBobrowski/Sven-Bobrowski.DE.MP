using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sven_Bobrowski.DE.Integration
{
    public class Items : IDisposable
    {
        private Dictionary<int, DataItem> FItems;

        public Items()
        {
            FItems = new Dictionary<int, DataItem>();
        }

        public void Dispose()
        {
            FItems = null;
        }

        public void Clear()
        {
            FItems.Clear();
        }

        public void AddOrSetItem(DataItem pItem)
        {
            if (FItems.ContainsKey(pItem.ID))
            {
                FItems[pItem.ID] = pItem;
            }
            else
            {
                FItems.Add(pItem.ID, pItem);
            }
        }

        public bool TryGetItem(int pId, out DataItem pItem)
        {
            if (FItems.ContainsKey(pId))
            {
                return FItems.TryGetValue(pId, out pItem);
            }

            pItem = null;
            return false;
        }

        public Dictionary<int, DataItem> DataItems
        {
            get
            {
                return FItems;
            }
        }
    }
}

