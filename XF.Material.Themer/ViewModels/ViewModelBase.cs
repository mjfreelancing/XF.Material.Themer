using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XF.Material.Themer.ViewModels
{
  public abstract class ViewModelBase
    : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void SetProperty<TType>(ref TType backingStore, TType value, Action action = null, [CallerMemberName] string propertyName = "")
    {
      if (EqualityComparer<TType>.Default.Equals(backingStore, value))
      {
        return;
      }

      backingStore = value;

      RaisePropertyChanged(propertyName);

      action?.Invoke();
    }

    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
      // null conditional operators are thread safe
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
