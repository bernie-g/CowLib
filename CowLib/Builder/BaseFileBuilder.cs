using Newtonsoft.Json;

namespace CowLib.Factory
{
    public abstract class BaseFileFactory<T>
    {
        private string name;
        
        public T builtObject { get; }
        
        public BaseFileFactory(string dragonEntity, T builtObject)
        {
            this.builtObject = builtObject;
            this.name = dragonEntity;
        }
        

        public string getName()
        {
            return this.name;
        }
        
        public abstract void saveFile();
    }
}