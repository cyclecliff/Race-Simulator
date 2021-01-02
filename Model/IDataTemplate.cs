using System.Collections.Generic;

namespace Model
{
    public interface IDataTemplate
    {
        string Naam { get; set; }

        void AddToList(List<IDataTemplate> list);

        string GetBestDriver(List<IDataTemplate> list);
    }
}