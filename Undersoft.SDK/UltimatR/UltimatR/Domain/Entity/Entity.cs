using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace UltimatR
{
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public class Entity : Identifiable, IEntity, INotifyPropertyChanged
    {
        public Entity()
        {
            CompileValuator();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
