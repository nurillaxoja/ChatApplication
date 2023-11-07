using PropertyChanged;
using System.ComponentModel;

namespace An.World
{
    /// <summary>
    /// Base view model fires propery changed as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// event fired on child property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, equals) => { };

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

}
