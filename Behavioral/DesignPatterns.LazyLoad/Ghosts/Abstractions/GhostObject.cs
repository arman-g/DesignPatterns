using DesignPatterns.CommonObjects.Enums;
using System.Collections;

namespace DesignPatterns.LazyLoad.Ghosts.Abstractions
{
    public abstract class GhostObject
    {
        public string CompanyName { get; set; }
        public LoadStatus Status { get; set; }
        public bool IsGhost => Status == LoadStatus.Ghost;
        public bool IsLoaded => Status == LoadStatus.Loaded;

        public GhostObject(string companyName)
        {
            CompanyName = companyName;
        }

        public void MarkLoading()
        {
            Status = LoadStatus.Loading;
        }

        public void MarkLoaded()
        {
            Status = LoadStatus.Loaded;
        }

        public virtual void Load()
        {
            if (!IsGhost) return;
            var dataRow = GetDataRow();
            LoadLine(dataRow);
        }

        private void LoadLine(ArrayList dataRow)
        {
            if (!IsGhost) return;

            MarkLoading();
            DoLoadLine(dataRow);
            MarkLoaded();
        }

        protected abstract void DoLoadLine(ArrayList dataRow);
        protected abstract ArrayList GetDataRow();
    }
}
