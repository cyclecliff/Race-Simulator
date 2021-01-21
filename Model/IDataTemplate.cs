using System.Collections.Generic;

namespace Model
{
    public interface IDataTemplate
    {
        string Name{ get; set; }

        void AddToList(List<IDataTemplate> list);

        string GetBestDriverName(List<IDataTemplate> list);
    }
}