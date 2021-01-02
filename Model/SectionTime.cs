using System.Collections.Generic;

namespace Model
{
    public class SectionTime : IDataTemplate
    {
        public string Naam { get; set; }

       
        public void AddToList(List<IDataTemplate> list)
        {
            throw new System.NotImplementedException();
        }

        public string GetBestDriver(List<IDataTemplate> list)
        {
            throw new System.NotImplementedException();
        }
    }
}